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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        string MyConnectionString = "server=localhost;User Id=root;password=123456;Database=bingliku";

        private void Form6_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void chaxun_Click(object sender, EventArgs e)
        {
            string txt = textBox1.Text.Trim();
            DataSet ds = new DataSet();
            dataGridView1.Rows.Clear();

            MySqlConnection connection = new MySqlConnection(MyConnectionString);
            MySqlCommand cmd;
            connection.Open();
            try
            {
                cmd = connection.CreateCommand();
                cmd.CommandText = "select * from bingli where idcard = '" + txt + "'";

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

            if (ds.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("没有病例！");
            }
            else
            {
                dataGridView1.DataSource = ds.Tables[0];
            }
        }
    }
}
