using MobileApp.models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace MobileApp.service
{
    class ApiService
    {
        public static async Task<bool> RegisterUser(string name, string email, string password)
        {
            var User = new Register()
            {
                Name = name,
                Email = email,
                Password = password
            };
            var httpClient = new HttpClient();
            //convert object to json 
            var json = JsonConvert.SerializeObject(User);
            //http server client communication ekata adala wena widihata content eka hada ganna eka karanne.
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            //ita passe karanna tinne end point ekata yawanna
            //methanadi use karana endpoint eka wenna one newtonsoft ekka wada karana ka thama.
            var response = await httpClient.PostAsync(AppSetting.ApiURL+"api/Accounts/Register", content);
            if (!response.IsSuccessStatusCode) return false;
            return true;

        }

        public static async Task<bool> Login(string email, string password)
        {
            var login = new Login()
            {
                Email = email,
                Password = password
            };
            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(login);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(AppSetting.ApiURL+"api/Accounts/Login", content);
            if (!response.IsSuccessStatusCode) return false;

            //ita passe access token eka ganna widiha 
            var jsonResult =await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Token>(jsonResult);
            Preferences.Set("accessToken", result.access_token);
            Preferences.Set("userId", result.user_Id);
            Preferences.Set("userName", result.user_name);
            return true;

        }

        public static async Task<List<Category>>  GetCategories()
        {
            var httpClient = new HttpClient();
            //authorizede can only access
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("accessToken", string.Empty));
            //get eka hinda 
            var response=await httpClient.GetStringAsync(AppSetting.ApiURL + "api/Categories");
            //object ekata convert karanna one. list of category class
            return JsonConvert.DeserializeObject<List<Category>>(response);
        }

        //product id eka dunnahama product eke details ganna hadala tinne
        public static async Task<Products> GetProductById(int productId)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("accessToken", string.Empty));
            var response = await httpClient.GetStringAsync(AppSetting.ApiURL + "api/Products/" + productId);
            return JsonConvert.DeserializeObject<Products>(response);
        }

        public async static Task<List<ProductByCategory>> GetProductsByCategory(int categoryId)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("accessToken", string.Empty));
            var response=await httpClient.GetStringAsync(AppSetting.ApiURL + "api/Products/ProductsByCategory/" + categoryId);
            return JsonConvert.DeserializeObject<List<ProductByCategory>>(response);


        }
        public async static Task<List<PopularProducts>> GetPopularProducts()
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("accessToken", string.Empty));
            var response = await httpClient.GetStringAsync(AppSetting.ApiURL + "api/Products/PopularProducts");
            return JsonConvert.DeserializeObject<List<PopularProducts>>(response);

        }

    }
}
