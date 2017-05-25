using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace bingliku
{
    public partial class Form1 : Form
    {
        public int power;
        public Form1()
        {
            InitializeComponent();
        }

        string MyConnectionString = "server=localhost;User Id=root;password=123456;Database=bingliku";

        private void denglu_Click(object sender, EventArgs e)
        {
            string yonghuming = yonghu.Text.Trim();
            string password = mima.Text.Trim();
            DataSet ds = new DataSet();

            MySqlConnection connection = new MySqlConnection(MyConnectionString);
            MySqlCommand cmd;
            connection.Open();
            try
            {
                cmd = connection.CreateCommand();
                cmd.CommandText ="select password,power from user where username = '" + yonghuming + "'";
                
                MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
                adap.Fill(ds);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            int n= ds.Tables[0].Rows.Count;
            if (yonghuming == "")
            {
                MessageBox.Show("用户名不能为空，请重新输入！");
                yonghu.Text = "";
                mima.Text = "";
            }
            else if (password == "")
            {
                MessageBox.Show("密码不能为空，请重新输入！");
                yonghu.Text = "";
                mima.Text = "";
            }
            else if (n == 0)
            {
                MessageBox.Show("用户不存在，请重新输入！");
                yonghu.Text = "";
                mima.Text = "";
            }
            else if (n == 1)
            {
                string temp = ds.Tables[0].Rows[0][0].ToString();
                string power1 = ds.Tables[0].Rows[0][1].ToString();
                power = Convert.ToInt32(power1);
                //MessageBox.Show(temp);
                if (password == temp)
                {
                    //MessageBox.Show(power.ToString());
                    Form2 f2 = new Form2(power,yonghuming);
                    this.Hide();
                    f2.Show();
                }
                else if (password != temp)
                {
                    MessageBox.Show("密码错误，请重新输入！");
                    mima.Text = "";
                }
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void zhuce_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            this.Hide();
            f3.Show();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
