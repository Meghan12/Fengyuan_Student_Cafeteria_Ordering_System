﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Fengyuan_Student_Cafeteria_Ordering_System
{
    public partial class cafteria_manage : Form
    {
        public cafteria_manage()
        {
            InitializeComponent();
        }

        private void toolStripContainer1_ContentPanel_Load(object sender, EventArgs e)
        {

        }

        private void cafteria_manage_Load(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dingdan_lst.SelectedItems.Count > 0)
            {
                ListViewItem selected_item = dingdan_lst.SelectedItems[0];
                dingdan dd = new(selected_item);
                dd.Show();
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab.Name == "dingdan")// 默认显示全部订单
            {
                DataBind_dingdan_info();
            }

        }
        protected void DataBind_dingdan_info(int i = 0)//i表示不同的订单状态，根据订单状态展示相应信息
        {
            string sqlstr = "select * from 订单 where 窗口号 ='window1' ;";//需绑定登录部分数据，暂设为1
            DataTable dt = data_work.DataQuery(sqlstr);
            dingdan_lst.Items.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                ListViewItem myitem = new ListViewItem(dr["订单号"].ToString());
                myitem.SubItems.Add(dr["餐食号"].ToString());
                myitem.SubItems.Add(dr["窗口号"].ToString());
                dingdan_lst.Items.Add(myitem);
            }
            dingdan_lst.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

        }



        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "全部订单")
            {
                DataBind_dingdan_info();

            }
            else if (comboBox1.Text == "新订单")
            {
                DataBind_dingdan_info();

            }
            else if (comboBox1.Text == "售后单")
            {
                DataBind_dingdan_info();

            }
            else if (comboBox1.Text == "已接餐")
            {
                DataBind_dingdan_info();

            }

        }
    }
}
