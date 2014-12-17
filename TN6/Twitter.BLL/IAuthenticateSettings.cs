using System;
namespace Twitter.BLL
{
	public interface IAuthenticateSettings
	{
		string OAuthConsumerKey { get; set; }
		string OAuthConsumerSecret { get; set; }
		string OAuthUrl { get; set; }
	}
}
