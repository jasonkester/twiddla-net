using System;
using System.Web;
using TwiddlaAPI.Util;

namespace Web.Helpers
{
	public class TwiddlaHelper
	{

		public const string TwiddlaUsername = "YourTwiddlaUsername";
		public const string TwiddlaPassword = "YourTwiddlaPassword";

		/// <summary>
		/// A list of valid response formats, for calls that return data
		/// </summary>
		public enum ResponseFormat
		{
			CSV,
			XML
		}

		/// <summary>
		/// For future expansion:
		/// </summary>
		/// <param name="request"></param>
		/// <returns></returns>
		public static string GetTwiddlaHost(HttpRequest request)
		{
			return "www.twiddla.com";
		}

		/// <summary>
		/// Create a new Twiddla Meeting, returning the SessionID if successful
		/// </summary>
		/// <param name="meetingpassword"></param>
		/// <param name="meetingtitle"></param>
		/// <param name="url">For custom URLs.  Leave blank or null for a standard, numbered, meetingID</param>
		/// <returns></returns>
		/// 
		public static int CreateMeeting(string meetingtitle, string meetingpassword, string url)
		{
			string endpoint = String.Format(@"http://{0}/new.aspx", GetTwiddlaHost(HttpContext.Current.Request));

			APICaller caller = new APICaller(endpoint);
			caller.Add("username", TwiddlaUsername);
			caller.Add("password", TwiddlaPassword);
			caller.Add("meetingtitle", meetingtitle);
			caller.Add("meetingpassword", meetingpassword);
			if (!String.IsNullOrEmpty(url))
			{
				caller.Add("url", url);
			}

			if (caller.Call())
			{
				return caller.IntValue;
			}

			throw caller.LastException;
		}

		/// <summary>
		/// Create a new Twiddla User, returning the UserID if successful
		/// </summary>
		/// <param name="newusername"></param>
		/// <param name="newpassword"></param>
		/// <param name="displayname"></param>
		/// <param name="email"></param>
		/// <returns></returns>
		public static int CreateUser(string newusername, string newpassword, string displayname, string email)
		{
			string endpoint = String.Format(@"http://{0}/API/CreateUser.aspx", GetTwiddlaHost(HttpContext.Current.Request));

			APICaller caller = new APICaller(endpoint);
			caller.Add("username", TwiddlaUsername);
			caller.Add("password", TwiddlaPassword);
			caller.Add("newusername", newusername);
			caller.Add("newpassword", newpassword);
			caller.Add("displayname", displayname);
			caller.Add("email", email);

			if (caller.Call())
			{
				return caller.IntValue;
			}

			throw caller.LastException;
		}

		/// <summary>
		/// List active meetings for this account
		/// </summary>
		/// <param name="format"></param>
		/// <returns></returns>
		public static string ListActive(ResponseFormat format)
		{
			string endpoint = String.Format(@"http://{0}/API/ListActive.aspx", GetTwiddlaHost(HttpContext.Current.Request));

			APICaller caller = new APICaller(endpoint);
			caller.Add("username", TwiddlaUsername);
			caller.Add("password", TwiddlaPassword);
			caller.Add("format", format.ToString().ToLower());

			if (caller.Call())
			{
				return caller.Html;
			}

			throw caller.LastException;
		}

		/// <summary>
		/// List all snapshots for this account
		/// </summary>
		/// <param name="format"></param>
		/// <returns></returns>
		public static string ListSnapshots(ResponseFormat format)
		{
			return ListSnapshots(format, 0);
		}

		/// <summary>
		/// List all snapshots for the supplied sessionID
		/// </summary>
		/// <param name="format"></param>
		/// <param name="sessionID"></param>
		/// <returns></returns>
		public static string ListSnapshots(ResponseFormat format, int sessionID)
		{
			string endpoint = String.Format(@"http://{0}/API/ListSnapshots.aspx", GetTwiddlaHost(HttpContext.Current.Request));

			APICaller caller = new APICaller(endpoint);
			caller.Add("username", TwiddlaUsername);
			caller.Add("password", TwiddlaPassword);
			caller.Add("format", format.ToString().ToLower());
			if (sessionID > 0)
			{
				caller.Add("sessionid", sessionID);
			}

			if (caller.Call())
			{
				return caller.Html;
			}

			throw caller.LastException;
		}
	}


}
