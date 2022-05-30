using Fixtures;
using Newtonsoft.Json;
using System.Net;
using Tmdb.Core.Results;

namespace Tmdb.Integration.Tests
{
    public class UserTestRequest : BaseClient
    {
        [Trait("Request", "User")]
        [Fact(DisplayName = "É possivel cadastrar Usuario")]
        public async Task When_Possible_To_Register_User()
        {
            var userdto = UserDtoFixtures.UserDtoValid();
            var response = await PostJsonAsync(userdto, $"{hostApi}/api/v1/users/createUser");
            var postResult = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ResultModel>(postResult);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotNull(result);
            Assert.True(result.Success);
        }
    }
}
