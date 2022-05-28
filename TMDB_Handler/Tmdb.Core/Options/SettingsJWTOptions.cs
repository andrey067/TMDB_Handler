namespace Tmdb.Core.Options
{
    public class SettingsJWTOptions
    {
        public const string AppJwtSettings = "AppJwtSettings";
        public string SecretKey { get; set; }
        public int HoursToExpire { get; set; }
    }
}
