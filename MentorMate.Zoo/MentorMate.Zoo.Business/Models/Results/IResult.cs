using System.Net;

namespace MentorMate.Zoo.Business.Models.Results
{
    public interface IResult<T>
    {
        public HttpStatusCode HttpStatusCode { get; }
        public IEnumerable<string> ErrorMessages { get; }
        public T Data { get; }
    }
}
