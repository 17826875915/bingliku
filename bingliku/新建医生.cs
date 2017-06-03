using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace bingliku
{
    public partial class Form8 : Form
    {
        string sex = "男";
        string MyConnectionString = "server=localhost;User Id=root;password=123456;Database=bingliku";
        public Form8()
        {
            InitializeComponent();
        }

        private void zhuce_Click(object sender, EventArgs e)
        {
            string yonghuming = yonghu.Text;
            string password1 = mima1.Text;
            string password2 = mima2.Text;
            string IdCard = idcard.Text;

            string quanxian = comboBox1.Text.Trim();
            int int_qx = 0;
            if (quanxian == "1-普通医生")
            {
                int_qx = 1;
            }
            else if (quanxian  == "2-专家主任")
            {
                int_qx = 2;
            }
            
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
            else if (password1 != password2)
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
                    InsertMessage(yonghuming, password1, IdCard,int_qx);
                    
                }
            }
        }
        public void InsertMessage(string yonghuming, string password, string IdCard ,int qx)
        {
            int n = getmaxid() + 1;
            //MessageBox.Show(n.ToString());
            MySqlConnection connection = new MySqlConnection(MyConnectionString);
            MySqlCommand cmd;
            connection.Open();
            try
            {
                cmd = connection.CreateCommand();
                cmd.CommandText = @"insert into user(iduser,username,password,sex,idcard,power)
                  values('" + n + "','" + yonghuming + "','" + password + "','" + sex + "','" + IdCard + "'," + qx + ")";
                if (cmd.ExecuteNonQuery() != 0)
                {
                    MessageBox.Show("新增成功");
                }
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
        private void nan_CheckedChanged(object sender, EventArgs e)
        {
            if (nan.Checked == true)
                sex = "男";
            else if (nv.Checked == true)
                sex = "女";
        }

        private void nv_CheckedChanged(object sender, EventArgs e)
        {
            if (nan.Checked == true)
                sex = "男";
            else if (nv.Checked == true)
                sex = "女";
        }
        /// <summary>
        /// 取消按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void quxiao_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
