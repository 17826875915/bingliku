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
    public partial class Form4 : Form
    {
        public string doctor_name ;
        public int quanxian;
        public Form4()
        {
            InitializeComponent();
        }
        string MyConnectionString = "server=localhost;User Id=root;password=123456;Database=bingliku";
        public Form4(int p , string n)
        {

            InitializeComponent();
            quanxian = p;
            doctor_name = n;


            textBox7.Text = doctor_name;
            string time = System.DateTime.Now.Year + "-"
                + System.DateTime.Now.Month + "-"
                + System.DateTime.Now.Day;
            textBox6.Text = time;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text.Trim();
            string sex = comboBox2.Text.Trim();
            string bingming = textBox3.Text.Trim();
            string details = textBox4.Text.Trim();
            string data = textBox6.Text.Trim();
            string doctor = textBox7.Text.Trim();
            string qx = comboBox1.Text.Trim();
            
            int age;
            if (int.TryParse(textBox2.Text.Trim(), out age) == false)
            {
                MessageBox.Show("请输入正确的年龄");
            }
            else
            {
                int idcard;
                if (int.TryParse(textBox5.Text.Trim(), out idcard) == false)
                {
                    MessageBox.Show("请输入正确的身份证");
                }
                else
                { 
                    if(name == "" || sex == "" || qx == "" || idcard == 0 || age == 0 || details == "" || doctor == "" || bingming == "" )
                    {
                         MessageBox.Show("请输入完整");
                    }
                    else
                    {
                        int id = getmaxid() + 1;
                        MySqlConnection connection = new MySqlConnection(MyConnectionString);
                        MySqlCommand cmd;
                        connection.Open();
                        try
                        {
                            cmd = connection.CreateCommand();
                            cmd.CommandText = @"INSERT INTO `bingliku`.`bingli` (`idbingli`, `patient`, `sex`, `age`, `idcard`, `disease`, `details`, `date`, `doctor`, `power`) VALUES 
                                    ('" + id +
                                        "', '" + name +
                                        "', '" + sex +
                                        "', '" + age +
                                        "', '" + idcard +
                                        "', '" + bingming +
                                        "', '" + details +
                                        "', '" + data +
                                        "', '" + doctor +
                                        "', '" + qx + "');";
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
                cmd.CommandText = "select * from bingli";

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
