using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Regedit
{
    class RegHelper
    {
        /// <summary>
        /// 查询某一节点下的某一个键是否是查询的值
        /// </summary>
        /// <param name="rootPath">hkcu/hklm/hku/hkcc/hkcr</param>
        /// <param name="subPath"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool CheckRgeValue(string rootPath, string subPath,string key,string value)
        {
            RegistryKey regKey;
          
            bool _exit=false;
            
            #region 设置根节点
            switch (rootPath)
            {
                case "hkcu":
                    regKey = Registry.CurrentUser;
                    break;
                case "hklm":
                    regKey = Registry.LocalMachine;
                    break;
                case "hku":
                    regKey = Registry.Users;
                    break;
                case "hkcc":
                    regKey = Registry.CurrentConfig;
                    break;
                case "hkcr":
                    regKey = Registry.ClassesRoot;
                    break;
                default:
                    return false;

            } 
            #endregion
            RegistryKey subKey=regKey.OpenSubKey(subPath);
            string valueGet = subKey.GetValue(key).ToString();
            #region 当发现实际值与预期值不同时：
            if (value == valueGet)
                _exit = true;
            //else
            //    MessageBox.Show("键：" + key + "值" + valueGet); 
            #endregion
            return _exit;
        }
        /// <summary>
        /// 向指定目录下写入key/value
        /// </summary>
        /// <param name="rootPath">hkcu/hklm/hku/hkcc/hkcr</param>
        /// <param name="subPath"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool setRegValueDWord(string rootPath, string subPath, string key, string value)
        {
            RegistryKey regKey;
            #region 设置根节点
            switch (rootPath)
            {
                case "hkcu":
                    regKey = Registry.CurrentUser;
                    break;
                case "hklm":
                    regKey = Registry.LocalMachine;
                    break;
                case "hku":
                    regKey = Registry.Users;
                    break;
                case "hkcc":
                    regKey = Registry.CurrentConfig;
                    break;
                case "hkcr":
                    regKey = Registry.ClassesRoot;
                    break;
                default:
                    return false;

            }
            #endregion
            RegistryKey subKey = regKey.OpenSubKey(subPath);
            subKey.SetValue(key, value,RegistryValueKind.DWord);
            return true;            
        }
    }
}
