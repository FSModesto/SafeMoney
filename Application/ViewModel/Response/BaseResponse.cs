using System.Net;

namespace Application.ViewModel.Response
{
    public class BaseResponse<T>
    {
        public T? Data { get; set; }
        public List<ValidationErrorsResponse>? Errors { get; set; }
        public string? Message { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
}
