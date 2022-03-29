using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace WebChatApi.Auth
{
    public class Tokens
    {
        public static async Task<string> GenerateJwt(ClaimsIdentity user, IJwtFactory jwtFactory, string userName, JwtIssuerOptions jwtOptions, JsonSerializerSettings serializerSettings)
        {
            var response = new
            {
                id = user.Claims.Single(c => c.Type == "Id").Value,
                auth_token = await jwtFactory.GenerateEncodedToken(userName, user),
            };

            return JsonConvert.SerializeObject(response, serializerSettings);
        }
    }
}