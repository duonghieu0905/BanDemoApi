using Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client_Appilication
{
    public partial class Form1 : Form
    {
        private const string URL = "https://localhost:44370/";
        static HttpClient client;
        public Form1()
        {
            InitializeComponent();
            client = new HttpClient();
            client.BaseAddress = new Uri(URL);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            dtpBirthDate.CustomFormat = "yyyy-MM-dd";
        }
        private void btnGetAll_Click(object sender, EventArgs e)
        {
            var response = client.GetAsync("api/customer/getcustomers").Result;
            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;
                List<Customer> listCustomer = JsonConvert.DeserializeObject<List<Customer>>(data);
                for (int i = 0; i < 10; i++)
                {
                    MessageBox.Show(listCustomer[i].Name + " - " + listCustomer[i].NumberPhone);
                }
            }
            else
            {
                MessageBox.Show(response.StatusCode + response.ReasonPhrase);
            }
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string contentString = "{ \"Id\": 0, " +
                "\"Name\": " + "\"" + txtName.Text + "\", " +
                "\"NumberPhone\": " + "\"" + txtNumberPhone.Text + "\", " +
                "\"Email\": " + "\"" + txtEmail.Text + "\", " +
                "\"Points\": " + "0" + ", " +
                "\"BirthDate\": " + "\"" + dtpBirthDate.Value + "\", " +
                "\"IdentifyNumber\": " + "\"" + txtIdentify.Text + "\", " +
                "\"Address\": " + "\"" + txtAddress.Text + "\" }";
            var content = new StringContent(contentString, Encoding.UTF8, "application/json");

            var response = client.PostAsync("api/customer/addcustomer", content).Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync();
                MessageBox.Show(result.Result);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string contentString = "{ \"Id\": 0, " +
                "\"Name\": " + "\"" + txtName.Text + "\", " +
                "\"NumberPhone\": " + "\"" + txtNumberPhone.Text + "\", " +
                "\"Email\": " + "\"" + txtEmail.Text + "\", " +
                "\"Points\": " + "0" + ", " +
                "\"BirthDate\": " + "\"" + dtpBirthDate.Value + "\", " +
                "\"IdentifyNumber\": " + "\"" + txtIdentify.Text + "\", " +
                "\"Address\": " + "\"" + txtAddress.Text + "\" }";
            var content = new StringContent(contentString, Encoding.UTF8, "application/json");

            var response = client.PostAsync("api/customer/updatecustomer", content).Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync();
                MessageBox.Show(result.Result);
            }
        }
    }
}
