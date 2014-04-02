namespace OneKey
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button2 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.lbIEVersion = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbScriptDebugger = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbSyncMode = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbNewWindowPopupMsg = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.check = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(7, 115);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(141, 23);
            this.button2.TabIndex = 23;
            this.button2.Text = "IE11兼容性视图设置";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label5.Location = new System.Drawing.Point(202, 140);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 22;
            this.label5.Text = "by.邱士川";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 21;
            this.button1.Text = "一键设置";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lbIEVersion
            // 
            this.lbIEVersion.AutoSize = true;
            this.lbIEVersion.Location = new System.Drawing.Point(136, 39);
            this.lbIEVersion.Name = "lbIEVersion";
            this.lbIEVersion.Size = new System.Drawing.Size(41, 12);
            this.lbIEVersion.TabIndex = 20;
            this.lbIEVersion.Text = "未检查";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 19;
            this.label4.Text = "IE版本：";
            // 
            // lbScriptDebugger
            // 
            this.lbScriptDebugger.AutoSize = true;
            this.lbScriptDebugger.Location = new System.Drawing.Point(136, 87);
            this.lbScriptDebugger.Name = "lbScriptDebugger";
            this.lbScriptDebugger.Size = new System.Drawing.Size(41, 12);
            this.lbScriptDebugger.TabIndex = 18;
            this.lbScriptDebugger.Text = "未检查";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 12);
            this.label3.TabIndex = 17;
            this.label3.Text = "禁用脚本调试及错误";
            // 
            // lbSyncMode
            // 
            this.lbSyncMode.AutoSize = true;
            this.lbSyncMode.Location = new System.Drawing.Point(136, 71);
            this.lbSyncMode.Name = "lbSyncMode";
            this.lbSyncMode.Size = new System.Drawing.Size(41, 12);
            this.lbSyncMode.TabIndex = 16;
            this.lbSyncMode.Text = "未检查";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 15;
            this.label2.Text = "IE页面缓存";
            // 
            // lbNewWindowPopupMsg
            // 
            this.lbNewWindowPopupMsg.AutoSize = true;
            this.lbNewWindowPopupMsg.Location = new System.Drawing.Point(136, 55);
            this.lbNewWindowPopupMsg.Name = "lbNewWindowPopupMsg";
            this.lbNewWindowPopupMsg.Size = new System.Drawing.Size(41, 12);
            this.lbNewWindowPopupMsg.TabIndex = 14;
            this.lbNewWindowPopupMsg.Text = "未检查";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 12);
            this.label1.TabIndex = 13;
            this.label1.Text = "弹出窗口阻止程序";
            // 
            // check
            // 
            this.check.Location = new System.Drawing.Point(138, 8);
            this.check.Name = "check";
            this.check.Size = new System.Drawing.Size(75, 23);
            this.check.TabIndex = 12;
            this.check.Text = "检查";
            this.check.UseVisualStyleBackColor = true;
            this.check.Click += new System.EventHandler(this.check_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 157);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lbIEVersion);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbScriptDebugger);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbSyncMode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbNewWindowPopupMsg);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.check);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IE一键设置";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lbIEVersion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbScriptDebugger;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbSyncMode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbNewWindowPopupMsg;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button check;
    }
}

