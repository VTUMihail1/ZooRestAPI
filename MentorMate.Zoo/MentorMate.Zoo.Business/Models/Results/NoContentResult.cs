using System.Net;

namespace MentorMate.Zoo.Business.Models.Results
{
    public class NoContentResult<T> : IResult<T>
    {
        public HttpStatusCode HttpStatusCode
        {
            get
            {
                return HttpStatusCode.NoContent;
            }
        }

        public IEnumerable<string> ErrorMessages
        {
            get
            {
                return Enumerable.Empty<string>();
            }
        }

        public T Data { get; }
    }
}
