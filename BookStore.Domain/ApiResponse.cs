using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain
{
    public class ApiResponse
    {
        public static object OkResponse(object? responseMessage)
        {
            return new OkObjectResult(new
            {
                statusCode = (int)HttpStatusCode.OK,
                data = responseMessage
            });
        }

        public static OkResult OkResponse()
        {
            return new OkResult();
        }

        public static BadRequestObjectResult BadResponse(string message)
        {
            return new BadRequestObjectResult(new
            {
                statusCode = (int)HttpStatusCode.BadRequest,
                data = new { status = "failure", message = new List<string> { message }, error = "Bad Request" }

            });
        }

        public static BadRequestObjectResult BadResponse(object data)
        {
            return new BadRequestObjectResult(new
            {
                statusCode = (int)HttpStatusCode.BadRequest,
                data = data
            });
        }

        public static BadRequestObjectResult BadResponse(ModelStateDictionary message)
        {
            return new BadRequestObjectResult(new
            {
                statusCode = (int)HttpStatusCode.BadRequest,
                data = new { status = "failure", message = GetErrorListFromModelState(message), error = "Model validation error" }
            });
        }

        public static List<string> GetErrorListFromModelState(ModelStateDictionary modelState)
        {
            var query = from state in modelState.Values
                        from error in state.Errors
                        select error.ErrorMessage;

            var errorList = query.ToList();
            return errorList;
        }

        public static ConflictObjectResult ConflictResponse()
        {
            return new ConflictObjectResult(new
            {
                statusCode = (int)HttpStatusCode.Conflict,
                data = new { status = "failure", message = new List<string> { "Data already exists" }, error = "Conflict Response" }
            });
        }

        public static NotFoundObjectResult NotFoundResponse()
        {
            return new NotFoundObjectResult(new
            {
                statusCode = (int)HttpStatusCode.NotFound,
                data = new { status = "failure", message = new List<string> { "No Data found" }, error = "Not Found Response" }
            });
        }

        public static object ExceptionResponse(string message, object? innerException)
        {
            return new BadRequestObjectResult(new
            {
                statusCode = (int)HttpStatusCode.ExpectationFailed,
                data = new { status = "failure", message = new List<string> { message }, error = innerException }
            });
        }

        private static Dictionary<string, string> Headers()
        {
            var headers = new Dictionary<string, string>();
            //headers.Add("Content-Type", "application/json");
            headers.Add("Access-Control-Allow-Headers", "Content-Type");
            headers.Add("Access-Control-Allow-Origin", "*");
            headers.Add("Access-Control-Allow-Methods", "OPTIONS,POST,GET,PUT,DELETE,PATCH,UPDATE");
            return headers;
        }
    }
}
