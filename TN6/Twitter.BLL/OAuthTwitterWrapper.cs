using System.Configuration;
using Microsoft.Practices.Unity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using Twitter.BLL.JsonTypes;


namespace Twitter.BLL
{
	public class OAuthTwitterWrapper : IOAuthTwitterWrapper
    {
		public IAuthenticateSettings AuthenticateSettings { get; set; }
		public ITimeLineSettings TimeLineSettings { get; set; }
		public ISearchSettings SearchSettings { get; set; }

		/// <summary>
		/// The default constructor takes all the settings from the appsettings file
		/// </summary>
		/// 
		///
		
        [InjectionConstructor]
        public OAuthTwitterWrapper()
		{
			string oAuthConsumerKey = ConfigurationManager.AppSettings["oAuthConsumerKey"];
            string oAuthConsumerSecret = ConfigurationManager.AppSettings["oAuthConsumerSecret"];
            string oAuthUrl = ConfigurationManager.AppSettings["oAuthUrl"];
            AuthenticateSettings = new AuthenticateSettings { OAuthConsumerKey = oAuthConsumerKey, OAuthConsumerSecret = oAuthConsumerSecret, OAuthUrl = oAuthUrl };

            //AuthenticateSettings = new AuthenticateSettings { OAuthConsumerKey = "QaM8auViHNQCp1JhB9Mpo6u1F", OAuthConsumerSecret = "15NYd2AKxkL9Vix3xBRUPsKhb0Znxodg019Wv2jCzL3qQBZZ2l", OAuthUrl = "https://api.twitter.com/oauth2/token" };


			string screenname = ConfigurationManager.AppSettings["screenname"];
			string include_rts = ConfigurationManager.AppSettings["include_rts"];
			string exclude_replies = ConfigurationManager.AppSettings["exclude_replies"];
			int count = Convert.ToInt16(ConfigurationManager.AppSettings["count"]);
			string timelineFormat = ConfigurationManager.AppSettings["timelineFormat"];


            TimeLineSettings = new TimeLineSettings
            {
                ScreenName = screenname,
                IncludeRts = include_rts,
                ExcludeReplies = exclude_replies,
                Count = count,
                TimelineFormat = timelineFormat
            };

            //TimeLineSettings = new TimeLineSettings
            //{
            //    ScreenName = "oshalygin",
            //    IncludeRts = "1",
            //    ExcludeReplies = "0",
            //    Count = 7,
            //    TimelineFormat = "https://api.twitter.com/1.1/statuses/user_timeline.json?screen_name={0}&amp;include_rts={1}&amp;exclude_replies={2}&amp;count={3}"
            //};

			string searchFormat = ConfigurationManager.AppSettings["searchFormat"];
			string searchQuery = ConfigurationManager.AppSettings["searchQuery"];
			SearchSettings = new SearchSettings
			{
				SearchFormat = searchFormat,
				SearchQuery = searchQuery
			};
				
		}

		/// <summary>
		/// This allows the authentications settings to be passed in
		/// </summary>
		/// <param name="authenticateSettings"></param>
		public OAuthTwitterWrapper(IAuthenticateSettings authenticateSettings)
		{
			AuthenticateSettings = authenticateSettings;
		}

		/// <summary>
		/// This allows the authentications and timeline settings to be passed in
		/// </summary>
		/// <param name="authenticateSettings"></param>
		/// <param name="timeLineSettings"></param>
		public OAuthTwitterWrapper(IAuthenticateSettings authenticateSettings, ITimeLineSettings timeLineSettings)
		{
			AuthenticateSettings = authenticateSettings;
			TimeLineSettings = timeLineSettings;
		}

		/// <summary>
		/// This allows the authentications, timeline and search settings to be passed in
		/// </summary>
		/// <param name="authenticateSettings"></param>
		/// <param name="timeLineSettings"></param>
		/// <param name="searchSettings"></param>
		public OAuthTwitterWrapper(IAuthenticateSettings authenticateSettings, ITimeLineSettings timeLineSettings, ISearchSettings searchSettings)
		{
			AuthenticateSettings = authenticateSettings;
			TimeLineSettings = timeLineSettings;
			SearchSettings = searchSettings;
		}

        public string GetMyTimeline()
        {

        


			var timeLineJson = string.Empty;
			IAuthenticate authenticate = new Authenticate();

            

			AuthResponse twitAuthResponse = authenticate.AuthenticateMe(AuthenticateSettings);

            // Do the timeline
			var utility = new Utility();
			timeLineJson = utility.RequstJson(TimeLineSettings.TimelineUrl, twitAuthResponse.TokenType, twitAuthResponse.AccessToken);
            
            return timeLineJson;
        }

		public string GetSearch()
		{
			var searchJson = string.Empty;
			IAuthenticate authenticate = new Authenticate();
			AuthResponse twitAuthResponse = authenticate.AuthenticateMe(AuthenticateSettings);

			// Do the timeline
			var utility = new Utility();
			searchJson = utility.RequstJson(SearchSettings.SearchUrl, twitAuthResponse.TokenType, twitAuthResponse.AccessToken);

			return searchJson;
		}
    }
}
