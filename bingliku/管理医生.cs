﻿using System;
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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }
        string MyConnectionString = "server=localhost;User Id=root;password=123456;Database=bingliku";
        /// <summary>
        /// 显示所有按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            
            MySqlConnection connection = new MySqlConnection(MyConnectionString);
            MySqlCommand cmd;
            connection.Open();
            try
            {
                cmd = connection.CreateCommand();
                cmd.CommandText = "select iduser as id,username as name,sex,idcard as IDcard ,power as quanxian from user ";

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

            dataGridView1.DataSource = ds.Tables[0];
        }
        /// <summary>
        /// 查询按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            string text1 = textBox1.Text.Trim();
            if (text1 == "")
            {
                MessageBox.Show("请输入医生姓名或IDcard");
            }
            else
            {

                long id = 0;
                DataSet ds = new DataSet();
                //输入的为数字是为ID
                
                if (long.TryParse(text1, out id))
                {

                    ds.Clear();
                    MySqlConnection connection = new MySqlConnection(MyConnectionString);
                    MySqlCommand cmd;
                    connection.Open();
                    try
                    {
                        cmd = connection.CreateCommand();
                        cmd.CommandText = "select iduser as id,username as name,sex,idcard as IDcard ,power as quanxian from user where idcard = '" + id + "'";

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

                   
                }
                else//输入为人名时
                {
                    ds.Clear();
                    string name = text1;
                    MySqlConnection connection = new MySqlConnection(MyConnectionString);
                    MySqlCommand cmd;
                    connection.Open();
                    try
                    {
                        cmd = connection.CreateCommand();
                        cmd.CommandText = "select iduser as id,username as name,sex,idcard as IDcard ,power as quanxian from user where username = '" + name + "'";

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

                }
                dataGridView1.DataSource = ds.Tables[0];
            }
        }
        /// <summary>
        /// 删除医生按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            string text1 = textBox2.Text.Trim();
            int id = 0;
            if (text1 == "")
            {
                MessageBox.Show("输入为空");
            }
            else if (int.TryParse(text1, out id) == false)
            {
                MessageBox.Show("请输入数字");
            }
            else
            {
                MySqlConnection connection = new MySqlConnection(MyConnectionString);
                MySqlCommand cmd;
                connection.Open();
                try
                {
                    cmd = connection.CreateCommand();
                    cmd.CommandText = @"DELETE FROM `bingliku`.`user` WHERE `iduser`='"+id+"';";
                    int t = cmd.ExecuteNonQuery();
                    if (t == 0)
                    {
                        MessageBox.Show("不存在该ID");
                    }
                    else
                    {
                        MessageBox.Show("删除成功");
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
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form8 f8 = new Form8();
            if (f8.ShowDialog() == DialogResult.OK)
            {
                f8.Close();
            }
        }
    }
}
