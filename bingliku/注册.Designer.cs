namespace bingliku
{
    partial class Form3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.nv = new System.Windows.Forms.RadioButton();
            this.nan = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.yonghu = new System.Windows.Forms.TextBox();
            this.mima1 = new System.Windows.Forms.TextBox();
            this.mima2 = new System.Windows.Forms.TextBox();
            this.idcard = new System.Windows.Forms.TextBox();
            this.zhuce = new System.Windows.Forms.Button();
            this.quxiao = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(23, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "用户名：";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(42, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "密码：";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(3, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "确认密码：";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.nv);
            this.groupBox1.Controls.Add(this.nan);
            this.groupBox1.Location = new System.Drawing.Point(109, 130);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(112, 42);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // nv
            // 
            this.nv.AutoSize = true;
            this.nv.Location = new System.Drawing.Point(65, 15);
            this.nv.Name = "nv";
            this.nv.Size = new System.Drawing.Size(35, 16);
            this.nv.TabIndex = 1;
            this.nv.Text = "女";
            this.nv.UseVisualStyleBackColor = true;
            this.nv.CheckedChanged += new System.EventHandler(this.nv_CheckedChanged);
            // 
            // nan
            // 
            this.nan.AutoSize = true;
            this.nan.Checked = true;
            this.nan.Location = new System.Drawing.Point(6, 15);
            this.nan.Name = "nan";
            this.nan.Size = new System.Drawing.Size(35, 16);
            this.nan.TabIndex = 0;
            this.nan.TabStop = true;
            this.nan.Text = "男";
            this.nan.UseVisualStyleBackColor = true;
            this.nan.CheckedChanged += new System.EventHandler(this.nan_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(43, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 19);
            this.label4.TabIndex = 4;
            this.label4.Text = "性别：";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(25, 188);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 19);
            this.label5.TabIndex = 5;
            this.label5.Text = "身份证：";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // yonghu
            // 
            this.yonghu.Location = new System.Drawing.Point(109, 21);
            this.yonghu.Name = "yonghu";
            this.yonghu.Size = new System.Drawing.Size(149, 21);
            this.yonghu.TabIndex = 6;
            this.yonghu.TextChanged += new System.EventHandler(this.yonghu_TextChanged);
            // 
            // mima1
            // 
            this.mima1.Location = new System.Drawing.Point(109, 60);
            this.mima1.Name = "mima1";
            this.mima1.PasswordChar = '*';
            this.mima1.Size = new System.Drawing.Size(149, 21);
            this.mima1.TabIndex = 7;
            this.mima1.TextChanged += new System.EventHandler(this.mima1_TextChanged);
            // 
            // mima2
            // 
            this.mima2.Location = new System.Drawing.Point(109, 98);
            this.mima2.Name = "mima2";
            this.mima2.PasswordChar = '*';
            this.mima2.Size = new System.Drawing.Size(149, 21);
            this.mima2.TabIndex = 8;
            this.mima2.TextChanged += new System.EventHandler(this.mima2_TextChanged);
            // 
            // idcard
            // 
            this.idcard.Location = new System.Drawing.Point(109, 188);
            this.idcard.Name = "idcard";
            this.idcard.Size = new System.Drawing.Size(149, 21);
            this.idcard.TabIndex = 9;
            this.idcard.TextChanged += new System.EventHandler(this.idcard_TextChanged);
            // 
            // zhuce
            // 
            this.zhuce.Location = new System.Drawing.Point(34, 226);
            this.zhuce.Name = "zhuce";
            this.zhuce.Size = new System.Drawing.Size(81, 25);
            this.zhuce.TabIndex = 10;
            this.zhuce.Text = "注册";
            this.zhuce.UseVisualStyleBackColor = true;
            this.zhuce.Click += new System.EventHandler(this.zhuce_Click);
            // 
            // quxiao
            // 
            this.quxiao.Location = new System.Drawing.Point(174, 226);
            this.quxiao.Name = "quxiao";
            this.quxiao.Size = new System.Drawing.Size(81, 25);
            this.quxiao.TabIndex = 11;
            this.quxiao.Text = "取消";
            this.quxiao.UseVisualStyleBackColor = true;
            this.quxiao.Click += new System.EventHandler(this.quxiao_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 269);
            this.Controls.Add(this.quxiao);
            this.Controls.Add(this.zhuce);
            this.Controls.Add(this.idcard);
            this.Controls.Add(this.mima2);
            this.Controls.Add(this.mima1);
            this.Controls.Add(this.yonghu);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form3";
            this.Text = "病例库管理系统-注册";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form3_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton nv;
        private System.Windows.Forms.RadioButton nan;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox yonghu;
        private System.Windows.Forms.TextBox mima1;
        private System.Windows.Forms.TextBox mima2;
        private System.Windows.Forms.TextBox idcard;
        private System.Windows.Forms.Button zhuce;
        private System.Windows.Forms.Button quxiao;
    }
}