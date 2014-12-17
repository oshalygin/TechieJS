using System;
using Twitter.BLL.JsonTypes;

namespace Twitter.BLL
{
	public interface IAuthenticate
	{
		AuthResponse AuthenticateMe(IAuthenticateSettings authenticateSettings);
	}
}
