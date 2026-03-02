using RegisteWeb.DTO;
using System.Net.Http.Json;

namespace RegisteWeb.Service
{
    public class AuthCustomerApiService
    {
        private readonly HttpClient _httpClient;

        public AuthCustomerApiService(IHttpClientFactory httpClientFactory)
        {
            this._httpClient = httpClientFactory.CreateClient("AUTH");

        }

        public async Task AuthCustomer(LoginCustomerDTO login) {

            var response = await this._httpClient.PostAsJsonAsync("auth/login?useCookies=true", login);
            response.EnsureSuccessStatusCode();
        }

        public async Task RegisterCustomer(CreateLoginCustomerDTO createLogin)
        {
            var response = await this._httpClient.PostAsJsonAsync<CreateLoginCustomerDTO>("auth/register", createLogin);
            response.EnsureSuccessStatusCode();

        }
    }
}
