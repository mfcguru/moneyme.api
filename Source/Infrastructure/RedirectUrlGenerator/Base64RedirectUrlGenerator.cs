using Microsoft.Extensions.Options;

namespace MoneyMe.Api.Source.Infrastructure.RedirectUrlGenerator
{
    public class Base64RedirectUrlGenerator : IRedirectUrlGenerator
    {
        private readonly IOptions<AppSettings> appSettings;
        public Base64RedirectUrlGenerator(IOptions<AppSettings> appSettings) => this.appSettings = appSettings;

        public string GenerateUrlFromId(int id)
        {
            return $"{appSettings.Value.RedirectUrl}{Convert.ToBase64String(BitConverter.GetBytes(id))}";
        }

        public int GenerateIdFromString(string s)
        {
            return BitConverter.ToInt32(Convert.FromBase64String(s), 0);
        }
    }
}
