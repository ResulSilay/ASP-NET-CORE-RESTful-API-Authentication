using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;
using TierApp.Core.Util.Result;

namespace TierApp.API.Helper
{
    public class ObjectActionResult : IActionResult
    {
        private bool Success { get; set; }
        private HttpStatusCode StatusCode { get; set; }
        private dynamic Data { get; set; }

        public ObjectActionResult(bool success, HttpStatusCode statusCode, dynamic data)
        {
            this.Success = success;
            this.StatusCode = statusCode;
            this.Data = data;
        }

        public async Task ExecuteResultAsync(ActionContext context)
        {
            var objectResult = new ObjectResult(new ResultWrapper { Success = this.Success, StatusCode = this.StatusCode, Data = this.Data })
            {
                StatusCode = (int)StatusCode
            };

            await objectResult.ExecuteResultAsync(context);
        }
    }
}