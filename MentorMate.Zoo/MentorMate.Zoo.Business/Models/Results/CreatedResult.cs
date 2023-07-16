using System.Net;

namespace MentorMate.Zoo.Business.Models.Results
{
    public class CreatedResult<T> : IResult<T>
    {
        public CreatedResult(T data)
        {
            Data = data;
        }

        public HttpStatusCode HttpStatusCode
        {
            get
            {
                return HttpStatusCode.Created;
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
