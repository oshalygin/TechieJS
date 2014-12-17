﻿using System;
namespace Twitter.BLL
{
	public interface ITimeLineSettings
	{
		int Count { get; set; }
		string IncludeRts { get; set; }
		string ScreenName { get; set; }
		string TimelineFormat { get; set; }
		string TimelineUrl { get; }
	}
}
