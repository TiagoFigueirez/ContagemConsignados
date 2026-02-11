using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace ContagemConsignados.Services
{
    public class BiService
    {
        private readonly string _groupId = "2c7b0243-525d-4aa6-8e1c-abf245a7ecb8";
        private string _datasetId = "62c33c27-23c0-49b8-8beb-e3cc9562b8b5";

        public async Task<string> ExecuteQueryAsybc(string accessToken)
        {
            string url = $"https://api.powerbi.com/v1.0/myorg/groups/{_groupId}/datasets/{_datasetId}/executeQueries";

            using var httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", accessToken);

            var queryBody = new
            {
                queries = new[]
                {
                    new
                    {
                        query = "EVALUATE 'Produtos'"
                    }
                }
            };

            var json = JsonSerializer.Serialize(queryBody);

            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(url,content);

            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());

            return await response.Content.ReadAsStringAsync();

        }
    }
}
