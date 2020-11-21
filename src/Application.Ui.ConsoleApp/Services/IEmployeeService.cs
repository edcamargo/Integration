using System.Net.Http;
using System.Threading.Tasks;

namespace Application.Ui.ConsoleApp.Services
{
    public interface IEmployeeService
    {
        Task<HttpResponseMessage> PostAsync(object data);
        Task<object> GetAsync();
    }
}
