using Microsoft.AspNetCore.Components.Authorization;
using RegisteWeb.DTO;
using System.Linq.Expressions;
using System.Net.Http.Json;
using System.Security.Claims;

namespace RegisteWeb.Service
{
    public class AuthCustomerApiService : AuthenticationStateProvider
    {
        private readonly HttpClient _httpClient;
        private bool authenticated = false;

        public AuthCustomerApiService(IHttpClientFactory httpClientFactory)
        {
            this._httpClient = httpClientFactory.CreateClient("AUTH");

        }

        public async override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var customerClaims = new ClaimsPrincipal();
            var response = await _httpClient.GetAsync("auth/manage/info");

            this.authenticated = false;

            if (response.IsSuccessStatusCode)
            {
                var info = await response.Content.ReadFromJsonAsync<ResponsePersonInformationDTO>();
                Claim[] claims =
               [
                    new Claim (ClaimTypes.Name , info.Email),
                    new Claim (ClaimTypes.Email , info.Email)
                ];

                var identity = new ClaimsIdentity(claims, "Cookies");
                customerClaims = new ClaimsPrincipal(identity);
                this.authenticated = true;

            }

            return new AuthenticationState(customerClaims);
        }

        public async Task AuthCustomer(LoginCustomerDTO login)
        {

            var response = await this._httpClient.PostAsJsonAsync("auth/login?useCookies=true", login);
            response.EnsureSuccessStatusCode();

            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }

        public async Task RegisterCustomer(CreateLoginCustomerDTO createLogin)
        {
            var response = await this._httpClient.PostAsJsonAsync<CreateLoginCustomerDTO>("auth/register", createLogin);
            response.EnsureSuccessStatusCode();

        }

        public async Task LogoutAsync()
        {
            var response = await this._httpClient.PostAsync("auth/logout",null);
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());

        }

        public async Task<bool> VerificationAuthenticated()
        {
            await GetAuthenticationStateAsync();
            return this.authenticated;
        }
    }
}
