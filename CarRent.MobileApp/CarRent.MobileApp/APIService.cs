using CarRent.Model;
using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CarRent.MobileApp
{
    public class APIService
    {
        private string _route = null;
        public static int UserId { get; set; }
        public static string Role { get; set; }
        public static string username { get; set; }
        public static string password { get; set; }

#if DEBUG
        string _apiUrl = "http://localhost:51823/api";
#endif
#if RELEASE
        string _apiUrl = "https://mywebsite.com/api/";
#endif

        public APIService(string route)
        {
            _route = route;
        }
        public async Task<T> Get<T>(object search = null)
        {
            try
            {
                var query = "";
                if (search != null)
                {
                    query = await search?.ToQueryString();
                }

                return await $"{_apiUrl}/{_route}?{query}"
                   .WithBasicAuth(username, password).GetJsonAsync<T>();
            }
            catch (FlurlHttpException ex)
            {
                if(ex.Call.Response.StatusCode == 401)
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Not authorized!", "OK");
                }
                throw;
            }
        }

        public async Task<T> CheckAvailibility<T>(object search)
        {
            try
            {
                var query = "";
                if (search != null)
                {
                    query = await search?.ToQueryString();
                }

                return await $"{_apiUrl}/{_route}?{query}"
                   .WithBasicAuth(username, password).GetJsonAsync<T>();
            }
            catch (FlurlHttpException ex)
            {
                if (ex.Call.Response.StatusCode == 401)
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Request failed", "OK");
                }
                throw;
            }
        }

        public async Task Login(string username, string password)
        {
            try
            {
                var request = new Model.Requests.User.UserLoginRequest
                {
                    Username = username,
                    Password = password
                };
                var url = $"http://localhost:51823/api/User/Login";
                await url.PostJsonAsync(request); ;
                await Application.Current.MainPage.DisplayAlert("Status", "Welcome", "OK");
            }
            catch (FlurlHttpException ex)
            {
                if (ex.Call.Response.StatusCode == 401)
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Request failed", "OK");
                }
                throw;
            }
        }

        public async Task<T> GetById<T>(object id)
        {
            var url = $"{_apiUrl}/{_route}/{id}";

            return await url.WithBasicAuth(username, password).GetJsonAsync<T>();
        }

        public async Task<T> Insert<T>(object request)
        {
            var url = $"{_apiUrl}/{_route}";

            return await url.WithBasicAuth(username, password).PostJsonAsync(request).ReceiveJson<T>();
        }

        public async Task<T> Update<T>(object id, object request)
        {
            var url = $"{_apiUrl}/{_route}/{id}";

            return await url.WithBasicAuth(username, password).PutJsonAsync(request).ReceiveJson<T>();
        }

        public async Task Delete(object id)
        {
            try
            {
                var url = $"{_apiUrl}/{_route}/{id}";

                await url.WithBasicAuth(username, password).DeleteAsync();
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }
                await Application.Current.MainPage.DisplayAlert("Greska", stringBuilder.ToString(), "OK");
            }

        }
    }
}
