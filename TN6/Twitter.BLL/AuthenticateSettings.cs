﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Twitter.BLL
{
	public class AuthenticateSettings : IAuthenticateSettings
	{
		public string OAuthConsumerKey { get; set; }
		public string OAuthConsumerSecret { get; set; }
		public string OAuthUrl { get; set; }
	}
}
