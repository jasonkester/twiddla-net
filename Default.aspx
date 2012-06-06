<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="APISample._Default" %>
<!DOCTYPE html>
<html>
<head>
    <title>Twiddla API Test</title>
    <style>
    	body
    	{
    		font-family:Arial;
    	}
		textarea
		{
			width:800px;
			height:400px;
		}
    </style>
</head>
<body>
	<h1>Twiddla's API is crazy simple:</h1>
	<ul>
		<li>
			<h2>Create Meeting</h2>
			<form action="Default.aspx" method="post">
				<table>
					<tr>
						<td align="right">
							meetingtitle
						</td>
						<td>
							<input type="text" id="meetingtitle" name="meetingtitle" />
						</td>
					</tr>
					<tr>
						<td align="right">
							meetingpassword
						</td>
						<td>
							<input type="text" id="meetingpassword" name="meetingpassword" />
						</td>
					</tr>
					<tr>
						<td align="right">
							url
						</td>
						<td>
							<input type="text" id="url" name="url" />
						</td>
					</tr>
					<tr>
						<td></td>
						<td>
							<input type="hidden" name="mode" id="mode" value="createmeeting" />
							<input type="submit" value="Create Meeting" />
						</td>
					</tr>
				</table>
			</form>
		</li>
		
		
		
		
		
		<li>
			<h2>Create User</h2>
			<form action="Default.aspx" method="post">
				<table>
					<tr>
						<td align="right">
							newusername
						</td>
						<td>
							<input type="text" id="newusername" name="newusername" />
						</td>
					</tr>
					<tr>
						<td align="right">
							newpassword
						</td>
						<td>
							<input type="text" id="newpassword" name="newpassword" />
						</td>
					</tr>
					<tr>
						<td align="right">
							displayname
						</td>
						<td>
							<input type="text" id="displayname" name="displayname" />
						</td>
					</tr>
					<tr>
						<td align="right">
							email
						</td>
						<td>
							<input type="text" id="email" name="email" />
						</td>
					</tr>
					<tr>
						<td></td>
						<td>
							<input type="hidden" name="mode" id="mode" value="createuser" />
							<input type="submit" value="Create User" />
						</td>
					</tr>
				</table>
			</form>
		</li>
		
		<li>
			<h2>List Active Meetings</h2>
			List my meetings
			<a href="?mode=listactive&format=CSV">as CSV</a>
			or
			<a href="?mode=listactive&format=xml">as XML</a>
		</li>
		
		<li>
			<h2>List Snapshots</h2>
			List all my snapshots
			<a href="?mode=listsnapshots&format=CSV">as CSV</a>
			or
			<a href="?mode=listsnapshots&format=xml">as XML</a>
			
			(add &sessionid=1234 to one of those URLs to only return ones for a particular meeting)
		</li>
		
		<li>
			<h2>... and that's it.</h2>
			More info at <a href="http://www.twiddla.com/API/Reference.aspx">http://www.twiddla.com/API/Reference.aspx</a>
		</li>
		
	</ul>
</body>
</html>
