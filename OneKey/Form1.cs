using Regedit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OneKey
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        RegHelper regHelper = new RegHelper();
        ConfigHelper configHelper = new ConfigHelper();
        IEReg ieReg = new IEReg();
        cmdHelper cmdHelper = new cmdHelper();

        private void check_Click(object sender, EventArgs e)
        {
            check_All();
        }
        private void check_All()
        {
            popupMsg();
            syncMode();
            scriptDebugger();
            readIEVer();

        }
        //检查弹出窗口阻止程序是否关闭
        public void popupMsg()
        {
            if (regHelper.CheckRgeValue("hkcu", "Software\\Microsoft\\Internet Explorer\\New Windows", "PopupMgr", "0"))
            {
                lbNewWindowPopupMsg.Text = "OK(已禁用)";
                lbNewWindowPopupMsg.ForeColor = Color.Green;
            }
            else
            {
                lbNewWindowPopupMsg.Text = "NO，已启用";
                lbNewWindowPopupMsg.ForeColor = Color.Red;
            }
        }
        //检查最新版本网页
        public void syncMode()
        {
            if (regHelper.CheckRgeValue("hkcu", "Software\\Microsoft\\Windows\\CurrentVersion\\Internet Settings", "SyncMode5", "3"))
            {
                lbSyncMode.Text = "每次刷新";
                lbSyncMode.ForeColor = Color.Green;
            }
            else
            {
                lbSyncMode.Text = "未知";
                lbSyncMode.ForeColor = Color.Red;
            }
        }
        //禁用脚本调试，不显示每一个脚本错误
        public void scriptDebugger()
        {
            bool disableScirptDebugger = regHelper.CheckRgeValue("hkcu", "Software\\Microsoft\\Internet Explorer\\Main", "Disable Script Debugger", "yes");
            bool disableScirptDebuggerIE = regHelper.CheckRgeValue("hkcu", "Software\\Microsoft\\Internet Explorer\\Main", "DisableScriptDebuggerIE", "yes");
            bool errorShowEveryone = regHelper.CheckRgeValue("hkcu", "Software\\Microsoft\\Internet Explorer\\Main", "Error Dlg Displayed On Every Error", "no");
            if (disableScirptDebugger && disableScirptDebuggerIE && errorShowEveryone)
            {
                lbScriptDebugger.Text = "已禁用";
                lbScriptDebugger.ForeColor = Color.Green;
            }
            else
            {
                lbScriptDebugger.Text = "启用用";
                lbScriptDebugger.ForeColor = Color.Red;
            }
        }
        //获取IE版本
        public void readIEVer()
        {
            string version = ieReg.readIEVersion();
            string[] ver = version.Split(new char[] { '.' }, 3);
            int main = Convert.ToInt32(ver[0]);
            if (main < 9)//IE9以下版本
            {
                lbIEVersion.Text = main.ToString();
            }
            else if (main == 9)
            {
                int subkey = Convert.ToInt32(ver[1]);
                //9.00表示IE9
                if (subkey < 10)
                    lbIEVersion.Text = main.ToString();
                //9.10：IE10，9.11：IE11
                else
                    lbIEVersion.Text = ver[1].ToString();
            }
            else
            {
                lbIEVersion.Text = "未知";
            }


        }
        //读取Config站点
        public void readAddress()
        {
            string[] add = configHelper.readAddress();
            for (int i = 0; i < add.Length; i++)
            {
                MessageBox.Show(add[i].ToString());
            }
        }
        //添加可信站点
        public void setTrustAddress()
        {
            string[] address = configHelper.readAddress();
            int addressCount = address.Length;
            for (int i = 0; i < addressCount; i++)
            {
                ieReg.addTrustSite(address[i]);

            }
            //MessageBox.Show("成功添加可信站点");
        }
        //执行CMD命令，导入注册表信息
        public void importReg()
        {
            string comm = "regedit /s " + System.Environment.CurrentDirectory.ToString() + "\\IE.reg";
            cmdHelper.executeCommand("cmd.exe", comm);
        }
        public void importReg2()
        {

            string comm = "regedit /s " + System.Environment.CurrentDirectory.ToString() + "\\IE.reg";
            // cmdHelper.excuteCMDCommand(comm);
            //string comm = "ipconfig";
            cmdHelper.Execute(comm, 0);

        }
        public void importReg3()
        {
            //打开REG文件导入注册表信息
            System.Diagnostics.Process.Start("IE.reg");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            setTrustAddress();
            importReg2();
            MessageBox.Show("设置成功！请重新打开浏览器");
        }

        private void button2_Click(object sender, EventArgs e)
        {

            IEHelp ieHelp = new IEHelp();
            ieHelp.Show();
        }


    }
}
