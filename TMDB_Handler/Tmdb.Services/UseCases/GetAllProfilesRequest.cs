using Tmdb.Core.Utils;

namespace Tmdb.Services.UseCases
{
    public class GetAllProfilesRequest : CommandBase
    {
        public GetAllProfilesRequest(int userId)
        {
            UserId = userId;
        }

        public int UserId { get; set; }
    }
}
