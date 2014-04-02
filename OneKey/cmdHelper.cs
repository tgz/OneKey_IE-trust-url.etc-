using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Regedit
{
    class cmdHelper
    {
        public void executeCommand(string strFile, string args)
        {
            //参照：
            //http://blog.csdn.net/zhoufoxcn/article/details/1682130
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo = new System.Diagnostics.ProcessStartInfo();
            p.StartInfo.FileName = strFile;
            p.StartInfo.Arguments = args;
            p.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.CreateNoWindow = true;//不显示CMD窗口
            //p.StartInfo.Verb = "RunAs";
            p.Start();
            //System.IO.StreamReader reader = p.StandardOutput;//截取输出流
            //string line = reader.ReadLine();//每次读取一行
            //while (!reader.EndOfStream)
            //{
            //tbResult.AppendText(line + " ");
            //line = reader.ReadLine();
            //}
            //p.WaitForExit();//等待程序执行完退出进程
            
            //p.Close();//关闭进程
            //reader.Close();//关闭流
        }
        public void excuteCMDCommand(string comm)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
           
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/c C:\\Windows\\System32\\cmd.exe";
            startInfo.RedirectStandardInput = true;
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardError = true;
            startInfo.UseShellExecute = false;
            startInfo.CreateNoWindow = true;
            //提示以管理员身份运行
            //startInfo.Verb = "RunAs";
            Process process = new Process();
            process.StartInfo = startInfo;
            process.Start();
            process.StandardInput.WriteLine(comm);
            process.StandardInput.WriteLine("exit");
            //string strRst = process.StandardOutput.ReadToEnd();
            //获取后执行返回的值
            //System.IO.StreamReader reader = p.StandardOutput;//截取输出流
            //string line = reader.ReadLine();//每次读取一行

            //process.WaitForExit();
        }
            //dosCommand Dos命令语句  
        public string Execute(string dosCommand)  
        {  
            return Execute(dosCommand,1000);  
        }  
        /// <summary>  
        /// 执行DOS命令，返回DOS命令的输出  
        /// </summary>  
        /// <param name="dosCommand">dos命令</param>  
        /// <param name="milliseconds">等待命令执行的时间（单位：毫秒），  
        /// 如果设定为0，则无限等待</param>  
        /// <returns>返回DOS命令的输出</returns>  
        public  string Execute(string command, int seconds)  
        {  
            string output = ""; //输出字符串  
            if (command != null && !command.Equals(""))  
            {  
                Process process = new Process();//创建进程对象  
                ProcessStartInfo startInfo = new ProcessStartInfo();  
                startInfo.FileName = "cmd.exe";//设定需要执行的命令  
                startInfo.Arguments = "/C " + command;//“/C”表示执行完命令后马上退出  
                startInfo.UseShellExecute = false;//不使用系统外壳程序启动  
                startInfo.RedirectStandardInput = false;//不重定向输入  
                startInfo.RedirectStandardOutput = true; //重定向输出  
                startInfo.CreateNoWindow = true;//不创建窗口  
                process.StartInfo = startInfo;  
                try  
                {  
                    if (process.Start())//开始进程  
                    {  
                        if (seconds == 0)  
                        {  
                            process.WaitForExit();//这里无限等待进程结束  
                        }  
                        else  
                        {  
                            process.WaitForExit(seconds); //等待进程结束，等待时间为指定的毫秒  
                        }  
                        output = process.StandardOutput.ReadToEnd();//读取进程的输出  
                    }  
                }  
                catch  
                {  
                }
                finally
                {
                    if (process != null)
                        process.Close();
                }
            }
            return output;
        } 
    }
}
