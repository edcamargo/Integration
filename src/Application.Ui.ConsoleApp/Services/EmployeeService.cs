using Newtonsoft.Json;
using System.Configuration;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Application.Ui.ConsoleApp.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly string _url = ConfigurationManager.AppSettings["URL"].ToString();
        private static readonly HttpClient _httpClient = new HttpClient();

        public async Task<object> GetAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync(_url);

            string returno = null;
            if (response.IsSuccessStatusCode)
            {
                returno = await response.Content.ReadAsStringAsync();
            }

            _httpClient.Dispose();

            var ret = JsonConvert.DeserializeObject(returno);

            return ret;
        }

        public async Task<HttpResponseMessage> PostAsync(object data)
        {
            var json = JsonConvert.SerializeObject(data);

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, _url)
            {
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };

            // Quando precisar passar token no Header
            //_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("", "VARIAVEL_TOKEN");

            var response = await _httpClient.SendAsync(request);

            _httpClient.Dispose();

            return response;
        }
    }
}
