using CDPModule1.Client.Services;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;
using System.Net.Http;
using System.Net.Http.Json;
using System.IdentityModel.Tokens.Jwt;

namespace CDPModule1.Client.Services
{
    public interface IApiService
    {
         Task<HttpResponseMessage> GetWithAuthAsync(string uri);
        Task<HttpResponseMessage> PostWithAuthAsync(string uri,object data);

         Task<Guid> GetLoggedInUserId();
    }

    public class ApiService : IApiService
    {
        private readonly ILocalStorageService localStorageService;

        public ApiService(ILocalStorageService localStorageService)
        {
            this.localStorageService = localStorageService;
        }

        public async Task<HttpResponseMessage> GetWithAuthAsync(string uri)
        {
            try
            {
                string token = await GetToken();
                HttpClient httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                httpClient.DefaultRequestHeaders
                .Accept
                .Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                return await httpClient.GetAsync("https://localhost:7031/"+uri);
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<HttpResponseMessage> PostWithAuthAsync(string uri,object data)
        {
            string token = await GetToken();

            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Clear();
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " +token);
            httpClient.DefaultRequestHeaders
            .Accept
            .Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            return await httpClient.PostAsJsonAsync("https://localhost:7031/"+uri,data);
        }

        public async Task<string> GetToken()
        {
           string token = await localStorageService.GetItem<string>("token");
           if(!string.IsNullOrEmpty(token)) { return token; }
            else { return string.Empty; }
        }

        public async Task<Guid> GetLoggedInUserId()
        {
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(await localStorageService.GetItem<string>("token"));
            string Id  =  jwtSecurityToken.Claims.FirstOrDefault(x => x.Type == "Id").Value;
            return new Guid(Id);
        }
    }
}
