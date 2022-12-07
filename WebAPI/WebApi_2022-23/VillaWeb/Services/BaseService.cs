using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using VillaWeb.Models;
using VillaWeb.Services.IServices;
using static VillaWeb.Utility;

namespace VillaWeb.Services
{
    public class BaseService : IBaseService
    {
        public IHttpClientFactory httpClient;
        public ApiResponse ResponseModel { get; set; }
        public BaseService(IHttpClientFactory clientFactory)
        {
            ResponseModel = new ApiResponse();
            httpClient = clientFactory;
        }


        //generička metoda za pozivanje API-ja
        public async Task<T> SendAsync<T>(ApiRequest apiRequest)
        {
            try
            {
                var client = httpClient.CreateClient("VillaAPI");

                //kreiranje zahtjeva
                HttpRequestMessage message = new HttpRequestMessage();
                message.Headers.Add("Accept", "application/json");
                message.RequestUri = new Uri(apiRequest.Url);
                //ako ima podataka dodaj ih u zahtjev
                if (apiRequest.Data != null)
                {
                    message.Content = new StringContent(JsonConvert.SerializeObject(apiRequest.Data), Encoding.UTF8, "application/json");
                }
                //definiraju tip zahtjeva
                switch (apiRequest.ApiType)
                {
                    case ApiType.POST:
                        message.Method = HttpMethod.Post;
                        break;
                    case ApiType.PUT:
                        message.Method = HttpMethod.Put;
                        break;
                    case ApiType.DELETE:
                        message.Method = HttpMethod.Delete;
                        break;
                    default:
                        message.Method = HttpMethod.Get;
                        break;

                }

                HttpResponseMessage apiResponse = null;
                apiResponse = await client.SendAsync(message);
                var apiContent = await apiResponse.Content.ReadAsStringAsync();
                try
                {
                    ApiResponse ApiResponse = JsonConvert.DeserializeObject<ApiResponse>(apiContent);
                    if (ApiResponse != null && (apiResponse.StatusCode == System.Net.HttpStatusCode.BadRequest
                        || apiResponse.StatusCode == System.Net.HttpStatusCode.NotFound))
                    {
                        ApiResponse.StatusCode = System.Net.HttpStatusCode.BadRequest;
                        ApiResponse.IsSuccess = false;
                        var res = JsonConvert.SerializeObject(ApiResponse);
                        var returnObj = JsonConvert.DeserializeObject<T>(res);
                        return returnObj;
                    }
                }
                catch (Exception e)
                {
                    var exceptionResponse = JsonConvert.DeserializeObject<T>(apiContent);
                    return exceptionResponse;
                }
                var APIResponse = JsonConvert.DeserializeObject<T>(apiContent);
                return APIResponse;
            }
            catch (Exception ex)
            {
                //u slučaju greške kreiraj odgovor s greškom
                var dto = new ApiResponse();
                dto.ErrorMessages.Add(ex.Message);
                dto.IsSuccess = false;
                //serijaliziraj ga u json
                var res = JsonConvert.SerializeObject(dto);
                //pretvori ga u odgovarajući tip
                var apiResponse = JsonConvert.DeserializeObject<T>(res);
                return apiResponse;
                
            }
        }
    }
}
