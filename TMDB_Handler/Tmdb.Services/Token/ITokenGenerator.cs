namespace Tmdb.Services.Token
{
    public interface ITokenGenerator
    {
        string GenerateToken(string userName);
    }
}
