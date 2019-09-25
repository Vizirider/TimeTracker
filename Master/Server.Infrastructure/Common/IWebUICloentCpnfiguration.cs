using System;

namespace Server.Infrastructure.Common
{
    public interface IWebUICloentCpnfiguration
    {
        string GetWepApiAddress();

        Uri GetWebApiUri();
    }
}