using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtermaUser.Api.Controllers.Base
{
    [ApiController]
    [Route("/api/[controller]")]
    public class BaseController : Controller
    {
        public Dictionary<string, object> RequestBody { get; private set; }

        public BaseController()
        {

        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Request.EnableBuffering();
            SetRequestBodyAsync(Request.Body).Wait();
            base.OnActionExecuting(context);
        }

        private async Task SetRequestBodyAsync(Stream body)
        {
            if (body != null)
            {
                try
                {

                    Request.Body.Seek(0, SeekOrigin.Begin);

                    using (var reader = new StreamReader(Request.Body, Encoding.ASCII))
                    {
                        var requestBody = await reader.ReadToEndAsync();
                        Request.Body.Seek(0, SeekOrigin.Begin);
                        RequestBody = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, object>>(requestBody);
                    }

                }
                catch
                {
                    Console.WriteLine("Error to cast request body");
                }

            }
        }

        protected int GetUserId()
        {
            var currentUser = HttpContext.User;
            return int.Parse(currentUser.Claims.FirstOrDefault(c => c.Type == "Id").Value);
        }
    }
}
