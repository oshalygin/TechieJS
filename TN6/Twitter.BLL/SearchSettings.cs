using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Twitter.BLL
{
	public class SearchSettings : ISearchSettings
	{
		public string SearchFormat { get; set; }
		public string SearchQuery { get; set; }
		public string SearchUrl {
			get { return string.Format(SearchFormat, SearchQuery); }  
		}
	}
}
