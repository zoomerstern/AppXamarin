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
        //Получаем токен
        public async Task<payload> GetToken(string login, string password)
        {
            HttpClient client = GetClient();
            var result = await client.GetStringAsync(Url + "api/token/index?login=" + login + "&password=" + password);//(Url + "api/token/index?login=\"" + login + "\"&password=\"" + password+ "\"");
            return JsonSerializer.Deserialize <payload>(result, options);
        }

        // получаем пользователя
        public async Task<User> GetUser(string token)
        {
            HttpClient client = GetClient();
            string result = await client.GetStringAsync(Url+"api/user/get-profile?Bearer="+token);
            return JsonSerializer.Deserialize<User>(result, options);
        }


    }
}
