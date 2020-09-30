using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using HoarderApp.Models;

namespace HoarderApp.API
{
    public class RestService
    {
        HttpClient _client;

        public RestService()
        {
            _client = new HttpClient();
        }

        public async Task<AccountDetails> SignIn(string uri, AccountDetails attempt)
        {
            AccountDetails userInDb = null;
            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri + "AccountDetails/" + attempt.Username + "/" + attempt.Password);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    userInDb = JsonConvert.DeserializeObject<AccountDetails>(content);
                }
            }
            catch (Exception ex) { Debug.WriteLine("\tERROR {0}", ex.Message); }
            return userInDb;
        }

        public async Task<AccountDetails> GetUserFromDB(string uri)
        {
            AccountDetails userInDb = null;
            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    userInDb = JsonConvert.DeserializeObject<AccountDetails>(content);
                }
                
            }catch(Exception ex) { Debug.WriteLine("\tERROR {0}", ex.Message); }
            return userInDb;
        }
    }
}
