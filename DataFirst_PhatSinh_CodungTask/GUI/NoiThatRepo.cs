using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GUI
{
    public class NoiThatRepo
    {
        private const string URL = "https://localhost:44327/";
        private HttpClient client;
        private HttpResponseMessage respon;
        public NoiThatRepo()
        {
            client = new HttpClient();
            client.BaseAddress =new Uri(URL) ;
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task<List<ChiTietHoaDon>> GetAllChiTiet()
        {
            var result = await client.GetAsync("api/ChiTietHoaDons");
            var json = await result.Content.ReadAsStringAsync();
            var list = JsonConvert.DeserializeObject<List<ChiTietHoaDon>>(json);
            return list;
        }
        public async Task<List<HoaDon>> GetAllHoaDon()
        {
            var result =await client.GetAsync("api/HoaDons");
            var json = await result.Content.ReadAsStringAsync();
            var list = JsonConvert.DeserializeObject<List<HoaDon>>(json);
            return list;
        }
        public async Task<List<SanPham>> GetAllSanPham()
        {
            var result = await client.GetAsync("api/SanPhams");
            var json = await result.Content.ReadAsStringAsync();
            var list = JsonConvert.DeserializeObject<List<SanPham>>(json);
            return list;
        }
        public void AddHoaDOn(HoaDon hd)
        {
            var json = JsonConvert.SerializeObject(hd);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            client.PostAsync("api/HoaDons", content);
        }
        public void AddChiTiet(ChiTietHoaDon ct)
        {
            var json = JsonConvert.SerializeObject(ct);
            var buffer = Encoding.UTF8.GetBytes(json);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.PostAsync("api/ChiTietHoaDons", byteContent);
        }
    }
}
