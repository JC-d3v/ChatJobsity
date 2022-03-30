using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using WebChatApi.Entities;

namespace WebChatApi.Controllers
{
	[ApiController]
	[Route("api/messages")]
	public class MessagesController : ControllerBase
	{
		private readonly ApplicationDbContext context;

		public MessagesController(ApplicationDbContext context)
		{
			this.context = context;
		}

		[HttpGet]
		public async Task<ActionResult<List<Message>>> Get()
		{
			return await context.Messages.ToListAsync();
		}

		[HttpGet("{chatroomId}")]
		public async Task<ActionResult<List<MessageResponse>>> Get(int chatroomId)
		{
			return await context.Messages.Where(x=>x.ChatroomId==chatroomId)
                .Select(Message => new MessageResponse
                {
					MessageId=Message.MessageId,
					Text=Message.Text,
					Time=Message.Time,
					User=Message.User.Name,
					ChatRoom=Message.ChatRoom.Name
                }).ToListAsync();
        }

		[HttpPost]
		public async Task<ActionResult<MessageResponse>> Post(Message message)
		{
			var accessToken = Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");
			var handler = new JwtSecurityTokenHandler();

			var jsonToken = handler.ReadToken(accessToken);

			var tokenS = jsonToken as JwtSecurityToken;
			message.UserId = Convert.ToInt32( tokenS.Claims.First(claim => claim.Type == "Id").Value);
			message.Time = DateTime.Now;
			if (!message.Text.StartsWith("/"))
			{
				context.Messages.Add(message);

				await context.SaveChangesAsync();
				return Ok();
			}
			else
			{
				if (message.Text.StartsWith("/stock="))
                {
					message.Text = message.Text.Substring(7);
					var stockData = GetQuoteValues(message.Text);
					return new MessageResponse() {
						User="StockBot",
						ChatRoom="",
						Text= string.Format($"{stockData[0]} quote is ${stockData[6]} per share"),
						Time = DateTime.Now
					};
					var result=string.Format($"{stockData[0]} quote is ${stockData[6]} per share");
				}
				else
						{ }
				return Ok();
				//TODO: Process Command.
			}
		}

		private static List<string> GetQuoteValues(string stockCode)
		{
			string url = $"https://stooq.com/q/l/?s={stockCode}&f=sd2t2ohlcv&h&e=csv";

			string fileList = GetCSVData(url);
			string[] tempStr;

			fileList = fileList.Replace('\r', '|').Replace("\n", string.Empty);

			tempStr = fileList.Split('|');

			List<string> values = tempStr[1].Split(',').ToList();

			return values;
		}
		private static string GetCSVData(string url)
		{
			HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
			HttpWebResponse resp = (HttpWebResponse)req.GetResponse();

			StreamReader sr = new StreamReader(resp.GetResponseStream());
			string results = sr.ReadToEnd();
			sr.Close();

			return results;
		}
	}
}
