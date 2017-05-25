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
    public partial class Form3 : Form
    {
        string sex = "男";
        public Form3()
        {
            InitializeComponent();
        }

        string MyConnectionString = "server=localhost;User Id=root;password=123456;Database=bingliku";

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void quxiao_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            this.Hide();
            f1.Show();
        }

        private void nan_CheckedChanged(object sender, EventArgs e)
        {
            if (nan.Checked == true)
                sex = "男";
            else if(nv.Checked == true)
                sex = "女";
        }

        private void nv_CheckedChanged(object sender, EventArgs e)
        {
            if (nan.Checked == true)
                sex = "男";
            else if (nv.Checked == true)
                sex = "女";
        }

        private void zhuce_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(sex);
            string yonghuming = yonghu.Text;
            string password1 = mima1.Text;
            string password2 = mima2.Text;
            string IdCard = idcard.Text;
            DataSet ds = new DataSet();

            MySqlConnection connection = new MySqlConnection(MyConnectionString);
            MySqlCommand cmd;
            connection.Open();
            try
            {
                cmd = connection.CreateCommand();
                cmd.CommandText = "select * from user where username = '" + yonghuming + "'";

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

            if (yonghuming == "")
            {
                MessageBox.Show("用户名不能为空，请重新输入！");
                yonghu.Text = "";
                mima1.Text = "";
                mima2.Text = "";
                idcard.Text = "";
            }
            else if (password1 == "" || password2 == "")
            {
                MessageBox.Show("密码不能为空，请重新输入！");
                yonghu.Text = "";
                mima1.Text = "";
                mima2.Text = "";
                idcard.Text = "";
            }
            else if (password1!=password2 )
            {
                MessageBox.Show("密码不一致，请重新输入！");
                yonghu.Text = "";
                mima1.Text = "";
                mima2.Text = "";
                idcard.Text = "";
            }
            else if (IdCard == "")
            {
                MessageBox.Show("身份证不能为空，请重新输入！");
                yonghu.Text = "";
                mima1.Text = "";
                mima2.Text = "";
                idcard.Text = "";
            }
            else
            {
                int n = ds.Tables[0].Rows.Count;
                if (n != 0)
                {
                    MessageBox.Show("用户名已存在，请重新输入！");
                    yonghu.Text = "";
                    mima1.Text = "";
                    mima2.Text = "";
                    idcard.Text = "";
                }
                else
                {
                    InsertMessage(yonghuming, password1, IdCard);
                    Form2 f2 = new Form2(1,yonghuming);
                    this.Hide();
                    f2.Show();
                }
            }
        }

        public void InsertMessage(string yonghuming,string password,string IdCard)
        {
            int n = getmaxid()+1;
            //MessageBox.Show(n.ToString());
            MySqlConnection connection = new MySqlConnection(MyConnectionString);
            MySqlCommand cmd;
            connection.Open();
            try
            {
                cmd = connection.CreateCommand();
                cmd.CommandText = @"insert into user(iduser,username,password,sex,idcard,power)
                  values('" + n + "','" + yonghuming + "','" + password + "','" + sex + "','" + IdCard + "',1)";
                cmd.ExecuteNonQuery();
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
        }

        public int getmaxid()
        {
            DataSet ds = new DataSet();

            MySqlConnection connection = new MySqlConnection(MyConnectionString);
            MySqlCommand cmd;
            connection.Open();
            try
            {
                cmd = connection.CreateCommand();
                cmd.CommandText = "select * from user";

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

            string strmax = ds.Tables[0].Rows[0][0].ToString();
            int max = Convert.ToInt32(strmax);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                string str = ds.Tables[0].Rows[i][0].ToString();
                int s = Convert.ToInt32(str);
                if (s > max)
                    max = s;
            }
            return max;
        }
    }
}
