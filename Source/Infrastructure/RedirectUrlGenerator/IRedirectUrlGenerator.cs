namespace MoneyMe.Api.Source.Infrastructure.RedirectUrlGenerator
{
    public interface IRedirectUrlGenerator
    {
        string GenerateUrlFromId(int id);
        int GenerateIdFromString(string s);
    }
}
