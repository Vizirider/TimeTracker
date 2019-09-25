using System;
using System.Net;
using GalaSoft.MvvmLight.Ioc;
using Server.Infrastructure.Common;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebUiServiceClient.Common
{
    class HttpServices
    {
        private IWebUICloentCpnfiguration _webUICloentCpnfiguration;

        private IWebUICloentCpnfiguration WebUICloentCpnfiguration => _webUICloentCpnfiguration ?? (_webUICloentCpnfiguration = SimpleIoc.Default.GetInstance<IWebUICloentCpnfiguration>());

        public async Task<T> Get<T>(string uri) where T : class
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = WebUICloentCpnfiguration.GetWebApiUri();

                //HTTP GET
                var response = await client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<T>();

                    return result;
                }
            }

            return null;
        }

        public async Task<Result> Post<Result, Request>(string uri, Request request) where Result : class  where Request : class
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = WebUICloentCpnfiguration.GetWebApiUri();

                //HTTP POST
                var result = await client.PostAsJsonAsync<Request>(uri, request);

                if (result.IsSuccessStatusCode)
                {
                    var dto = await result.Content.ReadAsAsync<Result>();
                    return dto;
                }
            }

            return null;
        }

        public async Task<Boolean> Delete(string uri)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = WebUICloentCpnfiguration.GetWebApiUri();

                //HTTP GET
                var response = await client.DeleteAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
            }

            return false;
        }

        public async Task<Boolean> Put<Request>(string uri, Request request) where Request: class
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = WebUICloentCpnfiguration.GetWebApiUri();

                //HTTP GET
                var response = await client.PutAsJsonAsync<Request>(uri, request);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
            }

            return false;
        }

    }
}
