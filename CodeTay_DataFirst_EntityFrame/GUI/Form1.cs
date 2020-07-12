using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccess;
using Newtonsoft.Json;

namespace GUI
{
    public partial class Form1 : Form
    {
        private const string URL = "https://localhost:44323/";
        private static HttpClient client;
        public Form1()
        {
            InitializeComponent();
            client = new HttpClient();
            client.BaseAddress = new Uri(URL);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }
        private void LoadToList()
        {
            var getsinhvien = client.GetAsync("api/QuanLiDiem/GetSinhVien").Result;
            if (getsinhvien.IsSuccessStatusCode)
            {
                var data = getsinhvien.Content.ReadAsStringAsync().Result;
                List<SinhVien> list = JsonConvert.DeserializeObject<List<SinhVien>>(data);
                comboBox1.DataSource = list;
                comboBox1.DisplayMember = "SinhVienID";
            }
            else
            {
                MessageBox.Show(getsinhvien.StatusCode + getsinhvien.ReasonPhrase);
            }
            
        }
        private void LoadToGridView()
        {
            var value = "api/QuanLiDiem/GetBangDiem?id=" + comboBox1.Text.ToString();
            var getbangdiem = client.GetAsync(value).Result;
            if (getbangdiem.IsSuccessStatusCode)
            {
                var data = getbangdiem.Content.ReadAsStringAsync().Result;
                List<BangDiem> list = JsonConvert.DeserializeObject<List<BangDiem>>(data);
                dataGridView1.DataSource = list;
            }
            else
            {
                MessageBox.Show(getbangdiem.StatusCode + getbangdiem.ReasonPhrase);
            }
        }
        private void LoadToText()
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            if (dataGridView1.SelectedRows[0].Cells[2].Value== null)
                textBox3.Text = "";
            else
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            if (dataGridView1.SelectedRows[0].Cells[3].Value == null)
                textBox4.Text = "";
            else
                textBox4.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            if (dataGridView1.SelectedRows[0].Cells[4].Value == null)
                textBox5.Text = "";
            else
                textBox5.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadToList();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
          LoadToGridView();
        }

        private void dataGridView1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if(dataGridView1.SelectedRows.Count>0)
            LoadToText();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BangDiem bd = new BangDiem { SinhVienID =Int32.Parse(textBox1.Text.ToString()) , MonHocID =Int32.Parse(textBox2.Text.ToString()) , TK = Double.Parse(textBox3.Text.ToString()), GK = Double.Parse(textBox4.Text.ToString()), CK =Double.Parse( textBox5.Text.ToString()) };
            var bangdiem = JsonConvert.SerializeObject(bd);
            var content = new StringContent(bangdiem, Encoding.UTF8, "application/json");
            var respone = client.PostAsync("api/QuanLiDiem/PostBangDiem", content).Result;
            if (respone.IsSuccessStatusCode)
            {
                var result = respone.Content.ReadAsStringAsync();
                MessageBox.Show(result.Result);
            }
        }
    }
}
