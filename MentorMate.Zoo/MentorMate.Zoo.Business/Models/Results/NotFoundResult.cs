using System.Net;

namespace MentorMate.Zoo.Business.Models.Results
{
    public class NotFoundResult<T> : IResult<T>
    {
        public NotFoundResult(params string[] errorMessages)
        {
            ErrorMessages = errorMessages ?? Enumerable.Empty<string>();
        }

        public HttpStatusCode HttpStatusCode
        {
            get
            {
                return HttpStatusCode.NotFound;
            }
        }

        public IEnumerable<string> ErrorMessages { get; set; }
        public T Data { get; }
    }
}
