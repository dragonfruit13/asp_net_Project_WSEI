
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace asp_net_Poject_WSEI.Middleware
{
	public class ElapsedTimeMiddleware
	{
		private readonly ILogger _logger;
		private readonly RequestDelegate _next;


		public ElapsedTimeMiddleware(ILogger<ElapsedTimeMiddleware> logger, RequestDelegate next)
		{
			_logger = logger;
			_next = next;
		}

		public async Task Invoke(HttpContext context)
		{
			var sw = new Stopwatch();
			sw.Start();
			await _next(context);
			var isHtml = context.Response.ContentType?.ToLower().Contains("text/html");
			if (context.Response.StatusCode == 200 && isHtml.GetValueOrDefault())
			{
				_logger.LogInformation($"{context.Request.Path} executed in {sw.ElapsedMilliseconds}ms");
			}
		}
	}

	
}