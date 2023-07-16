using System.Net;

namespace MentorMate.Zoo.Business.Models.Results
{
    public class BadRequestResult<T> : IResult<T>
    {
        public BadRequestResult(params string[] errorMessages)
        {
            ErrorMessages = errorMessages ?? Enumerable.Empty<string>();
        }

        public HttpStatusCode HttpStatusCode
        {
            get
            {
                return HttpStatusCode.BadRequest;
            }
        }

        public IEnumerable<string> ErrorMessages { get; }
        public T Data { get; }
    }
}
