using System.Collections.Generic;

namespace Api.Errors
{
    public class ApiValidationError : ApiResponse
    {
        public ApiValidationError() 
               : base(400)
        {
        }
        public IEnumerable<string> Errors { get; set; }
    }
}