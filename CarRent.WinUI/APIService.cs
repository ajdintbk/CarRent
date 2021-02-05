using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CarRent.Model;

namespace CarRent.WinUI
{
    public class APIService
    {
        private string _route = null;
        public static User loggedUser { get; set; }
        public static string username { get; set; }
        public static string password { get; set; }
        public APIService(string route)
        {
            _route = route;
        }

        public async Task<T> Get<T>(object search = null)
        {

            var query = "";
            if (search != null)
            {
                query = await search?.ToQueryString();
            }
            try
            {
                return await $"{Properties.Settings.Default.APIurl}/{_route}?{query}"
                   .WithBasicAuth(username, password).GetJsonAsync<T>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Status", MessageBoxButtons.OK,MessageBoxIcon.Error);
                throw;

            }

        }

        public async Task<T> GetById<T>(object id)
        {
            try
            {
                var url = $"{Properties.Settings.Default.APIurl}/{_route}/{id}";

                return await url.WithBasicAuth(username, password).GetJsonAsync<T>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Status", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
            
        }

        public async Task<T> Insert<T>(object request)
        {
            try
            {
                var url = $"{Properties.Settings.Default.APIurl}/{_route}";

                return await url.WithBasicAuth(username, password).PostJsonAsync(request).ReceiveJson<T>();

            }
            catch (Exception)
            {
                MessageBox.Show("Error");
                throw;
            }
        }

        public async Task<T> Update<T>(object id, object request)
        {

            try
            {
                var url = $"{Properties.Settings.Default.APIurl}/{_route}/{id}";

                return await url.WithBasicAuth(username, password).PutJsonAsync(request).ReceiveJson<T>();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Status", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        public async Task Delete(object id)
        {
            try
            {
                var url = $"{Properties.Settings.Default.APIurl}/{_route}/{id}";

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

                MessageBox.Show(stringBuilder.ToString(), "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
