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
    public partial class Form2 : Form
    {
        public int quanxian;
        public string doctor_name;
        private DataSet ds_edit; // 存储修改的数据
        
        public Form2(int p ,string n)
        {
            InitializeComponent();
            quanxian = p;
            doctor_name = n;
            MySqlConnection connection = new MySqlConnection(MyConnectionString);
            MySqlCommand cmd;
            connection.Open();
            ds_edit = new DataSet();
            try
            {
                cmd = connection.CreateCommand();
                
                cmd.CommandText = "select * from bingli where details like '%" +""+ "%'";
                

                MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
                adap.Fill(ds_edit);
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

            ds_edit.Tables[0].Rows.Clear();

            ///只有权限为3的人可启用该控件
            if (quanxian == 3)
                管理医生ToolStripMenuItem.Enabled = true;
            
        }

        string MyConnectionString = "server=localhost;User Id=root;password=123456;Database=bingliku";

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void tuichu_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            //MessageBox.Show(quanxian.ToString());
            this.Hide();
            f1.Show();
        }

        private void idcard_CheckedChanged(object sender, EventArgs e)
        {
            label1.Text = "身份证：";
        }

        private void disease_CheckedChanged(object sender, EventArgs e)
        {
            label1.Text = "病名：";
        }

        private void details_CheckedChanged(object sender, EventArgs e)
        {
            label1.Text = "病情：";
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
                if (label1.Text == "身份证：")
                {
                    cmd.CommandText = "select * from bingli where idcard = '" + txt + "'";
                }
                if (label1.Text == "病名：")
                {
                    cmd.CommandText = "select * from bingli where disease = '" + txt + "'";
                }
                if (label1.Text == "病情：")
                {
                    cmd.CommandText = "select * from bingli where details like '%" + txt + "%'";
                }

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
            //插入数据
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                //blqx == 病例权限
                int blqx = Convert.ToInt32(ds.Tables[0].Rows[i][9]);
                if(quanxian>= blqx)
                {
                    dataGridView1.Rows.Add(ds.Tables[0].Rows[i][0], ds.Tables[0].Rows[i][1],
                        ds.Tables[0].Rows[i][2], ds.Tables[0].Rows[i][3], ds.Tables[0].Rows[i][4],
                    ds.Tables[0].Rows[i][5],ds.Tables[0].Rows[i][6],ds.Tables[0].Rows[i][7],
                    ds.Tables[0].Rows[i][8]);
                }
            }
            if (ds.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("不存在该病例");
            }
            else if(dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("权限不足");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4(quanxian,doctor_name);
            if (f4.ShowDialog() == DialogResult.OK)
            {
                f4.Close();
            }
        }
        /// <summary>
        /// 确认修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            if (ds_edit.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("请修改");
            }
            else
            {
                for (int i = 0; i < ds_edit.Tables[0].Rows.Count; ++i)
                {
                    int bl_id = int.Parse(ds_edit.Tables[0].Rows[i][0].ToString());
                    //UPDATE `bingliku`.`bingli` SET `patient`='1', `sex`='2', `age`='3', `idcard`='4', `disease`='5', `details`='6', `date`='7', `doctor`='8', `power`='9' WHERE `idbingli`='12';
                    /*Class_book.updatat_book(book_id,
                        ds_edit.Tables[0].Rows[i][1].ToString().Trim(),
                        ds_edit.Tables[0].Rows[i][2].ToString().Trim(),
                        ds_edit.Tables[0].Rows[i][3].ToString().Trim(),
                        ds_edit.Tables[0].Rows[i][4].ToString().Trim(),
                        ds_edit.Tables[0].Rows[i][5].ToString().Trim(),
                        ds_edit.Tables[0].Rows[i][6].ToString().Trim(),
                        ds_edit.Tables[0].Rows[i][7].ToString().Trim()

                        );*/
                    MySqlConnection connection = new MySqlConnection(MyConnectionString);
                    MySqlCommand cmd;
                    connection.Open();
                    try
                    {
                        cmd = connection.CreateCommand();

                        cmd.CommandText = "UPDATE `bingliku`.`bingli` SET `patient`='" + ds_edit.Tables[0].Rows[i][1].ToString().Trim() +
                            "', `sex`='" + ds_edit.Tables[0].Rows[i][2].ToString().Trim() +
                            "', `age`='" + ds_edit.Tables[0].Rows[i][3].ToString().Trim() +
                            "', `idcard`='" + ds_edit.Tables[0].Rows[i][4].ToString().Trim() +
                            "', `disease`='" + ds_edit.Tables[0].Rows[i][5].ToString().Trim() +
                            "', `details`='" + ds_edit.Tables[0].Rows[i][6].ToString().Trim() +
                            "', `date`='" + ds_edit.Tables[0].Rows[i][7].ToString().Trim() +
                            "', `doctor`='" + ds_edit.Tables[0].Rows[i][8].ToString().Trim() +
                            "', `power`='" + ds_edit.Tables[0].Rows[i][9].ToString().Trim() +
                            "' WHERE `idbingli`='" + bl_id + "'";


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
                MessageBox.Show("修改成功");
                ds_edit.Tables[0].Rows.Clear();
            }
        }
        /// <summary>
        /// 编辑单元格式 记录改变的行存储在ds_edit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string[] ob = new string[10]{this.dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString(),
                this.dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString(),
                this.dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString(),
                this.dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString(),
                this.dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString(),
                this.dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString(),
                this.dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString(),
                this.dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString(),
                this.dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString(),
                quanxian.ToString()
                 };

            ds_edit.Tables[0].Rows.Add(ob);
        }

        /// <summary>
        /// 菜单--新建病例
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 新建病例ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4(quanxian, doctor_name);
            if (f4.ShowDialog() == DialogResult.OK)
            {
                f4.Close();
            }
        }

        /// <summary>
        /// 菜单---退出登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 退出登录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            //MessageBox.Show(quanxian.ToString());
            this.Hide();
            f1.Show();
        }
    }
}
