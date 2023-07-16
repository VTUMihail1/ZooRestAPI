using System.Net;

namespace MentorMate.Zoo.Business.Models.Results
{
    public class OkResult<T> : IResult<T>
    {
        public OkResult(T data)
        {
            Data = data;
        }

        public HttpStatusCode HttpStatusCode
        {
            get
            {
                return HttpStatusCode.OK;
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
