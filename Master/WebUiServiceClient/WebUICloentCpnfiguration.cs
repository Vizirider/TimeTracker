using System;
using Server.Infrastructure.Common;

namespace WebUiServiceClient
{
    public class WebUICloentCpnfiguration : IWebUICloentCpnfiguration
    {
        public string GetWepApiAddress()
        {
            return "http://localhost:61600/";
        }

        public Uri GetWebApiUri()
        {
            return new Uri(GetWepApiAddress());
        }
    }
}