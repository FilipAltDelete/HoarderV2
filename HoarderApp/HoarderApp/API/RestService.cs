using System;
using System.Collections.Generic;
using System.Linq;
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
            //string debugURL = "http://10.0.0.6:5000/api/accountdetails/Petar/123";
            string localUri = Constants.apiURLLocal;
            AccountDetails userInDb = null;
            try
            {
                //HttpResponseMessage response = await _client.GetAsync(uri + "AccountDetails/" + attempt.Username + "/" + attempt.Password);
                HttpResponseMessage response = await _client.GetAsync(localUri + "AccountDetails/" + attempt.Username + "/" + attempt.Password);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    userInDb = JsonConvert.DeserializeObject<AccountDetails>(content);
                }
            }
            catch (Exception ex) { Debug.WriteLine("\tERROR {0}", ex.Message); }
            return userInDb;
        }

        public async Task<List<CollectionDTO>> GetCollections(string uri, AccountDetails user)
        {
            string localUri = Constants.apiURLLocal;

            List<CollectionDTO> col = new List<CollectionDTO>();
            try
            {
                HttpResponseMessage response = await _client.GetAsync(localUri + "UserCollections/" + user.Id);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    col = JsonConvert.DeserializeObject<List<CollectionDTO>>(content);

                }
            }
            catch (Exception ex) { Debug.WriteLine("\tERROR {0}", ex.Message); }
            return col;

        }

        public async Task<List<ItemDTO>>GetItemsFromDB(CollectionDTO collection)
        {
            string localUri = Constants.apiURLLocal;

            List<ItemDTO> items = new List<ItemDTO>();
            try
            {
                
                HttpResponseMessage response = await _client.GetAsync(localUri + "Item/collection/" + collection.Id);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    items = JsonConvert.DeserializeObject<List<ItemDTO>>(content);

                }
                
            }
            catch (Exception ex) { Debug.WriteLine("\tERROR {0}", ex.Message); }
            return items;
        }

        public async Task<List<ImageDTO>> GetImages(ItemDTO item)
        {
            string localUri = Constants.apiURLLocal;

            List<ImageDTO> items = new List<ImageDTO>();
            try
            {

                HttpResponseMessage response = await _client.GetAsync(localUri + "Image/itemid/" + item.Id);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    items = JsonConvert.DeserializeObject<List<ImageDTO>>(content);

                }

            }
            catch (Exception ex) { Debug.WriteLine("\tERROR {0}", ex.Message); }
            return items;
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
