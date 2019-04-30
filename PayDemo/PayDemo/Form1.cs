﻿
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PayDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // 软件名称自定义，scimence修改为您自己的开发者名称
            SciPay.PayTool.Init("PayDemo", "scimence", PayResult);          // 初始化
        }

        // 支付结果回调处理逻辑
        private void PayResult(string productName, string moneyYuan, string orderId, string reserve)
        {
            MessageBox.Show("支付成功：" + productName + ", " + moneyYuan + ", " + orderId + ", " + reserve);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SciPay.PayTool.Pay("商品1", "0.01", "00001", "reserve");   // 调用支付
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            string url = "https://www.scimence.club/PayFor/SDK.aspx";
            System.Diagnostics.Process.Start(url);
        }
    }
}