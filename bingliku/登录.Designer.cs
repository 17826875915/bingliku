﻿namespace bingliku
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.yonghu = new System.Windows.Forms.TextBox();
            this.mima = new System.Windows.Forms.TextBox();
            this.denglu = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(99, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "用户名:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(118, 155);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "密码:";
            // 
            // yonghu
            // 
            this.yonghu.Location = new System.Drawing.Point(178, 101);
            this.yonghu.Name = "yonghu";
            this.yonghu.Size = new System.Drawing.Size(142, 21);
            this.yonghu.TabIndex = 2;
            // 
            // mima
            // 
            this.mima.Location = new System.Drawing.Point(178, 153);
            this.mima.Name = "mima";
            this.mima.PasswordChar = '*';
            this.mima.Size = new System.Drawing.Size(142, 21);
            this.mima.TabIndex = 3;
            // 
            // denglu
            // 
            this.denglu.Location = new System.Drawing.Point(178, 215);
            this.denglu.Name = "denglu";
            this.denglu.Size = new System.Drawing.Size(81, 28);
            this.denglu.TabIndex = 4;
            this.denglu.Text = "登录";
            this.denglu.UseVisualStyleBackColor = true;
            this.denglu.Click += new System.EventHandler(this.denglu_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::bingliku.Properties.Resources.bg;
            this.ClientSize = new System.Drawing.Size(450, 339);
            this.Controls.Add(this.denglu);
            this.Controls.Add(this.mima);
            this.Controls.Add(this.yonghu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form1";
            this.Text = "病例库管理系统登录";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox yonghu;
        private System.Windows.Forms.TextBox mima;
        private System.Windows.Forms.Button denglu;
    }
}

