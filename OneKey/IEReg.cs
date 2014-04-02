using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Text;
namespace Regedit
{
    class IEReg
    {
        //RegHelper regHelper=new RegHelper();
        //返回IE版本
        public string readIEVersion() {
            RegistryKey localMachine = Registry.LocalMachine;
            return localMachine.OpenSubKey("Software\\Microsoft\\Internet Explorer").GetValue("Version").ToString();
        }
        public void setTrustMode()
        { 
            
        }
        //在注册表添加信任站点
        public  void addTrustSite(string url)
        {
            RegistryKey currentUser = Registry.CurrentUser;//HKEY_CURRENT_USER

            string[] parts = url.Split(new char[] { '/' });//将URL拆分，提取协议和url地址
            string protocol = parts[0].Substring(0, parts[0].Length - 1);//采用的协议：http/https

            ///////////判断是普通URL还是IP，普通URL在Domains节点下操作，IP在Ranges节点下操作////////////////
            if (isIP(parts[2]))
            {
                string domainsKeyLocation = "Software\\Microsoft\\Windows\\CurrentVersion\\Internet Settings\\ZoneMap\\Ranges";
                RegistryKey ranges = currentUser.OpenSubKey(domainsKeyLocation, true);

                bool has = false;//标识IP是否已经添加
                List<string> numbers = new List<string>();//用来存放Range编号
                //循环所有的range节点，如果要添加的IP已经存在则不操作，否则添加
                foreach (string u in ranges.GetSubKeyNames())
                {
                    numbers.Add(u.Substring("Range".Length));//截取Range1后面的数字1
                    RegistryKey range = ranges.OpenSubKey(u, true);//以可写的权限打开子节点

                    //如果该IP地址已经存在
                    if (range.GetValue(":Range").Equals(parts[2]))
                    {
                        has = true;
                        if (range.GetValue(protocol) != null) break;//如果协议也正确说明IP已经是信任节点
                        range.SetValue(protocol, 2, RegistryValueKind.DWord);//添加协议对应的值
                    }
                }
                //如果该IP没有在信任列表则重新添加
                if (!has)
                {
                    RegistryKey range = ranges.CreateSubKey("Range" + findMinNumber(numbers));
                    range.SetValue(":Range", parts[2], RegistryValueKind.String);
                    range.SetValue(protocol, 2, RegistryValueKind.DWord);
                }
            }
            /////////////如果不是IP则在Domains节点下操作///////////////
            else
            {
                string domainsKeyLocation = "Software\\Microsoft\\Windows\\CurrentVersion\\Internet Settings\\ZoneMap\\Domains";
                RegistryKey domains = currentUser.OpenSubKey(domainsKeyLocation, true);

                string[] urls = parts[2].Split(new char[] { '.' }, 2);
                string head = urls[0];//url头部：www/go ...
                string tail = urls[1];//url尾部
                RegistryKey node = domains.OpenSubKey(tail, true);

                //URL没有添加过
                if (node == null)
                {
                    node = domains.CreateSubKey(tail);
                    RegistryKey pnode = node.CreateSubKey(head);
                    pnode.SetValue(protocol, 2, RegistryValueKind.DWord);//添加协议对应的值
                }
                else
                {
                    RegistryKey pnode = node.OpenSubKey(head, true);
                    //如果协议节点不存在
                    if (pnode == null)
                    {
                        pnode = node.CreateSubKey(head);
                        pnode.SetValue(protocol, 2, RegistryValueKind.DWord);//添加协议对应的值
                    }
                }
            }
        }

        //在注册表删除信任站点
        public  void deleteTrustSite(string url)
        {
            RegistryKey currentUser = Registry.CurrentUser;//HKEY_CURRENT_USER

            string[] parts = url.Split(new char[] { '/' });//将URL拆分，提取协议和url地址
            string protocol = parts[0].Substring(0, parts[0].Length - 1);//采用的协议：http/https

            //判断是普通URL还是IP，普通URL在Domains节点下操作，IP在Ranges节点下操作
            if (isIP(parts[2]))
            {
                string domainsKeyLocation = "Software\\Microsoft\\Windows\\CurrentVersion\\Internet Settings\\ZoneMap\\Ranges";
                RegistryKey ranges = currentUser.OpenSubKey(domainsKeyLocation, true);

                //循环所有的range节点，如果要添加的IP已经存在则不操作，否则添加
                foreach (string u in ranges.GetSubKeyNames())
                {
                    RegistryKey range = ranges.OpenSubKey(u, true);//以可写的权限打开子节点

                    //如果该IP地址已经存在
                    if (range.GetValue(":Range").Equals(parts[2]))
                    {
                        if (range.GetValue(protocol) != null) range.DeleteValue(protocol);//如果协议节点存在则先删除
                        if (range.GetValueNames().Length == 1) ranges.DeleteSubKey(u);//只剩下“:Range”则将该节点删除
                    }
                }
            }
            /////////////如果不是IP则在Domains节点下操作///////////////
            else
            {
                string domainsKeyLocation = "Software\\Microsoft\\Windows\\CurrentVersion\\Internet Settings\\ZoneMap\\Domains";
                RegistryKey domains = currentUser.OpenSubKey(domainsKeyLocation, true);

                string[] urls = parts[2].Split(new char[] { '.' }, 2);//使用'.'将字符串分成两部分
                string head = urls[0];//url头部：www/go ...
                string tail = urls[1];//url尾部

                RegistryKey node = domains.OpenSubKey(tail);
                RegistryKey pnode = node.OpenSubKey(head);
                if (pnode != null) node.DeleteSubKey(head);//删除协议节点
                if (node.GetSubKeyNames().Length == 0) domains.DeleteSubKey(tail);//如果没有协议节点则删除该URL节点
            }
        }

        /// <summary>
        /// 判断一个字符串是否是由数字组成
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static bool isNumber(string value)
        {
            int v = 0;
            foreach (char c in value)
            {
                v = (int)c;
                if (v < 48 || v > 57) return false;
            }
            return true;
        }

        /// <summary>
        /// 判断字符串是否是IP地址
        /// </summary>
        /// <param name="url">如10.120.1.1</param>
        /// <returns></returns>
        private static bool isIP(string url)
        {
            string[] separatedURLs = url.Split(new char[] { '.' });
            foreach (string str in separatedURLs)
            {
                if (!isNumber(str)) return false;//有一个不是数字则该URL不是IP
            }
            return true;
        }

        /// <summary>
        /// 获取数字列表里从小到大排列最先却少的那个数字，比如numbers里包含2，3时返回1
        /// </summary>
        /// <param name="numbers">已经使用的数字列表</param>
        /// <returns></returns>
        private static string findMinNumber(List<string> numbers)
        {
            for (int i = 1; i <= numbers.Count; i++)
            {
                if (numbers.IndexOf(i.ToString()) == -1) return i.ToString();
            }
            return (numbers.Count + 1).ToString();
        }
    }
}
