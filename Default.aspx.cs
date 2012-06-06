using System;
using Web.Helpers;


namespace APISample
{
	public partial class _Default : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			switch (Request["mode"])
			{
				case "createmeeting":
					CreateMeeting();
					break;

				case "createuser":
					CreateUser();
					break;

				case "listactive":
					ListActive();
					break;

				case "listsnapshots":
					ListSnapshots();
					break;

			}
		}

		private void Log(string message)
		{
			Response.Write(message + "<br/>");
		}

		private void CreateMeeting()
		{
			string meetingtitle = Request.Form["meetingtitle"];
			string meetingpassword = Request.Form["meetingpassword"];
			string url = Request.Form["url"];

			Log("Calling API...");
			try
			{
				int meetingID = TwiddlaHelper.CreateMeeting(meetingtitle, meetingpassword, url);
				Log("Success! API returned: " + meetingID);
			}
			catch (Exception e)
			{
				Log("Failed: " + e.Message);
			}
		}

		private void CreateUser()
		{
			string newusername = Request.Form["newusername"];
			string newpassword = Request.Form["newpassword"];
			string displayname = Request.Form["displayname"];
			string email = Request.Form["email"];

			Log("Calling API...");
			try
			{
				int userID = TwiddlaHelper.CreateUser(newusername, newpassword, displayname, email);
				Log("Success! API returned: " + userID);
			}
			catch (Exception e)
			{
				Log("Failed: " + e.Message);
			}
		}

		private void ListActive()
		{
			TwiddlaHelper.ResponseFormat format = TwiddlaHelper.ResponseFormat.CSV;
			if (Request["format"] == "xml")
			{
				format = TwiddlaHelper.ResponseFormat.XML;
			}

			Log("Calling API...");
			try
			{
				string html = TwiddlaHelper.ListActive(format);
				Log("Success! API returned: <br/><textarea>" + html + "</textarea>");
			}
			catch (Exception e)
			{
				Log("Failed: " + e.Message);
			}
		}

		private void ListSnapshots()
		{
			TwiddlaHelper.ResponseFormat format = TwiddlaHelper.ResponseFormat.CSV;
			if (Request["format"] == "xml")
			{
				format = TwiddlaHelper.ResponseFormat.XML;
			}

			Log("Calling API...");
			try
			{
				string html = TwiddlaHelper.ListSnapshots(format);
				Log("Success! API returned: <br/><textarea>" + html + "</textarea>");
			}
			catch (Exception e)
			{
				Log("Failed: " + e.Message);
			}
		}

	}
}
