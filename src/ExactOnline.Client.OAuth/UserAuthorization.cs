using DotNetOpenAuth.OAuth2;
using Newtonsoft.Json;

namespace ExactOnline.Client.OAuth
{
	public class UserAuthorization
	{
		public string AccessToken
		{
			get { return AuthorizationState.AccessToken; }
		}

		public string RefreshToken { get; set; }

        [JsonConverter(typeof(AuthorizationStateConverter))]
        public IAuthorizationState AuthorizationState { get; set; }
	}
}