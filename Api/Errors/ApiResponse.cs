using System;

namespace Api.Errors
{
    public class ApiResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDafaultMessage(statusCode);
        }

        private string GetDafaultMessage(int statusCode)
        {
            return statusCode switch
            {
                400 => "Bad Request",
                401 => "Unauthorized",
                404 => "Not Found",
                500 => "Internal Server Error",
                _ => null
            };
        }


    }
}