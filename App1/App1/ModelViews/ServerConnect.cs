using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;
using App1.Model;

namespace App1.ModelViews
{
    public class ServerConnect
    {
        const string Url = "https://api.my-advo.cat/"; // обращайте внимание на конечный слеш
        // настройки для десериализации для нечувствительности к регистру символов
        JsonSerializerOptions options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        };
        // настройка клиента
        private HttpClient GetClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            return client;
        }

        // получаем пользователя
        public async Task<User> GetUser()
        {
            HttpClient client = GetClient();
            string result = await client.GetStringAsync(Url+"api / token /");
            return JsonSerializer.Deserialize<User>(result, options);
        }

        // добавляем пользователя
        public async Task<User> Add(User friend)
        {
            HttpClient client = GetClient();
            var response = await client.PostAsync(Url+ "/api/user/",
                new StringContent(
                    JsonSerializer.Serialize(friend),
                    Encoding.UTF8, "application/json"));

            if (response.StatusCode != HttpStatusCode.OK)
                return null;

            return JsonSerializer.Deserialize<User>(
                await response.Content.ReadAsStringAsync(), options);
        }
        
    }
}
