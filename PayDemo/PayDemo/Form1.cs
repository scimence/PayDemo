
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

            // 软件名称自定义，scimence修改为您自己的支付宝收款账号
            PayTool.Init("PayDemo", "scimence", PayResult);          // 初始化
        }

        // 支付结果回调处理逻辑
        private void PayResult(string productName, string moneyYuan, string orderId, string reserve)
        {
            MessageBox.Show("支付成功：" + productName + ", " + moneyYuan + ", " + orderId + ", " + reserve);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PayTool.Pay("商品1", "0.01", "00001", "reserve");   // 调用支付
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            string url = "http://scimence.gitee.io/url/QRPay.html";
            System.Diagnostics.Process.Start(url);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Random rnd = new Random(DateTime.Now.Second);
            int N = rnd.Next(1, 100);

            string productName = "商品" + N;
            string moneyYuan = (0.01 * N) + "";
            string orderId = "订单：" + N;
            string reserve = "xxx"+N;

            PayTool.Pay(productName, moneyYuan, orderId, reserve);   // 调用支付
        }
    }
}
