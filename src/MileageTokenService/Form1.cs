using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MileageTokenService
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var companyInfo = MileageTokenService.Properties.Settings.Default.CompanyInfo;
            var serializedObj = JsonConvert.DeserializeObject(companyInfo);

            this.comboBox1.DataSource = serializedObj;
            this.comboBox1.DisplayMember = "Name";

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            JObject companyInfo = ((JObject)this.comboBox1.SelectedItem);
            string CompanyName = companyInfo.SelectToken("Name").ToString();
            string CompanyAddress = companyInfo.SelectToken("Address").ToString();
            this.Text = $"{CompanyName} Mileage token Service - {CompanyAddress}";
            this.lblTokenAddress.Text = $"{CompanyName} Token Contract Address";
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtTokenContractAddress.Text))
            {
                //deploy token with information
            }
        }
    }
}
