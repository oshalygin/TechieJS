using System;
namespace Twitter.BLL
{
	public interface IOAuthTwitterWrapper
	{
		string GetMyTimeline();
		string GetSearch();
	}
}
