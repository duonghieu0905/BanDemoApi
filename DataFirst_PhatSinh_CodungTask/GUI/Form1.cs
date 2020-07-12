using DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class Form1 : Form
    {
        private NoiThatRepo nt = new NoiThatRepo();
        public Form1()
        {
            InitializeComponent();
            LoadSanPham();
            LoadChiTiet();
        }
        private async void LoadSanPham()
        {
            
            dataGridView1.DataSource = await nt.GetAllSanPham();
        }
        private async void LoadChiTiet()
        {
            dataGridView2.DataSource = await nt.GetAllChiTiet();
        }
        private void AddChiTiet()
        {
            HoaDon hd = new HoaDon { HoaDonID = Int32.Parse(textBox1.Text.ToString()), ChiTietHoaDons = null, NgayLapHoaDon = DateTime.Now };
            nt.AddHoaDOn(hd);
            ChiTietHoaDon ct = new ChiTietHoaDon { HoaDon = null, HoaDonID = Int32.Parse(textBox1.Text.ToString()), SanPham = null, SanPhamID = Int32.Parse(textBox2.Text.ToString()), SoLuongID=Int32.Parse(textBox5.Text.ToString()),ThanhTien=Int32.Parse(textBox5.Text.ToString())*Double.Parse(textBox4.Text.ToString())};
            nt.AddChiTiet(ct);
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddChiTiet();
        }
    }
}
