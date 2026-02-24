using RegisteWeb.DTO;
using System.Net.Http.Json;

namespace RegisteWeb.Service
{
    public class CustomerApiService
    {
        private readonly HttpClient _httpClient;

        public CustomerApiService(IHttpClientFactory httpClient)
        {

            this._httpClient = httpClient.CreateClient("API");

        }

        public async Task<PaginationResponseDTO<ResponseCustomerDTO>> GetCustomer(int skip, int take)
        {
            try
            {
                var response = await _httpClient.GetAsync($"customer?skip={skip}&take={take}");
                response.EnsureSuccessStatusCode();

                return await response.Content
                    .ReadFromJsonAsync<PaginationResponseDTO<ResponseCustomerDTO>>()
                    ?? new PaginationResponseDTO<ResponseCustomerDTO>();
            }
            catch (Exception ex)
            {
                throw new Exception("Communication error.", ex);
            }

        }

        public async Task DeleteCustomer(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"customer/{id}");
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                throw new Exception("Communication error.", ex);
            }
        }
        public async Task UpdateCustomer(int id, UpdateCustomerDTO dto)
        {
            try
            {
                var response = await _httpClient.PatchAsJsonAsync<UpdateCustomerDTO>($"customer/{id}", new UpdateCustomerDTO(dto.Name, dto.Description, DateTime.Now));
                response.EnsureSuccessStatusCode();

            }
            catch (Exception ex)
            {
                throw new Exception("Communication error.", ex);
            }
        }

        public async Task<ResponseCustomerDTO?> PostCustomer(CreateCustomerDTO create)
        {
            try
            {
                var response = await this._httpClient.PostAsJsonAsync<CreateCustomerDTO>("customer", create);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<ResponseCustomerDTO>();
            }
            catch (Exception ex)
            {
                throw new Exception("Communication error.", ex);
            }

        }
    }
}
