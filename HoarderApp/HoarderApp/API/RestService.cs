using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using HoarderApp.Models;
using System.Text;
namespace HoarderApp.API
{
    public class RestService
    {
        HttpClient _client;
        string localUri = Constants.apiURLLocal;
        

        public RestService()
        {
            _client = new HttpClient();
        }

        public async Task<AccountDetails> SignIn(string uri, AccountDetails attempt)
        {
            //string debugURL = "http://10.0.0.6:5000/api/accountdetails/Petar/123";
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
            catch (Exception ex) { Debug.WriteLine("\tERROR {Sign in error}", ex.Message); }
            return userInDb;
        }

        public async Task<List<CollectionDTO>> GetCollections(AccountDetails user)
        {

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
            catch (Exception ex) { Debug.WriteLine("\tERROR {Can't get collections from backend}", ex.Message); }
            return col;

        }

        public async Task<List<ItemDTO>>GetItemsFromDB(CollectionDTO collection)
        {

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
            catch (Exception ex) { Debug.WriteLine("\tERROR {Can't get items from backend}", ex.Message); }
            return items;
        }

        public async Task<List<string>> GetImages(Item item)
        {

            List<string> items = new List<string>();
            try
            {

                HttpResponseMessage response = await _client.GetAsync(localUri + "Image/Item/" + item.Id);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    items = JsonConvert.DeserializeObject<List<string>>(content);

                }

            }
            catch (Exception ex) { Debug.WriteLine("\tERROR {Can't get item specific images from backend}", ex.Message); }
            return items;
        }
        
        public async Task<List<ImageDTO>> GetAllImages(CollectionDTO collection)
        {

            List<ImageDTO> images = new List<ImageDTO>();
            try
            {

                HttpResponseMessage response = await _client.GetAsync(localUri + "Image/collectionId/" + collection.Id);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    images = JsonConvert.DeserializeObject<List<ImageDTO>>(content);

                }

            }
            catch (Exception ex) { Debug.WriteLine("\tERROR {Can't get collection specific item images from backend}", ex.Message); }
            return images;
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
                
            }catch(Exception ex) { Debug.WriteLine("\tERROR {Can't get user from backend}", ex.Message); }
            return userInDb;
        }
        public async void DeleteItem(int id)
        {
            
           HttpResponseMessage response = await _client.DeleteAsync(localUri + "item/" + id);

            Console.WriteLine(response);

        }
        public Task<HttpResponseMessage> PostNewColldectionToDB(CollectionDTO collection)
        {
            //localUri
            string json = JsonConvert.SerializeObject(collection, Formatting.Indented);
            HttpClient httpClient = new HttpClient();     
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
                
            return _client.PostAsync(localUri+"UserCollections", content);
        }
        public Task<HttpResponseMessage> PostNewItemToDB(ItemDTO item)
        {
            //localUri
            string json = JsonConvert.SerializeObject(item, Formatting.Indented);
            HttpClient httpClient = new HttpClient();
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            return _client.PostAsync(localUri + "item", content);
        }

        public async Task<List<UserProfile>> GetUsers(string uri, AccountDetails user)
        {

            List<UserProfile> usr = new List<UserProfile>();
            try
            {
                HttpResponseMessage response = await _client.GetAsync(localUri + "UserProfile/");
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    usr = JsonConvert.DeserializeObject<List<UserProfile>>(content);

                }
            }
            catch (Exception ex) { Debug.WriteLine("\tERROR {0}", ex.Message); }
            return usr;

        }
    }
}
