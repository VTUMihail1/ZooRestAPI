using MentorMate.Zoo.Business.Models.Results;

namespace MentorMate.Zoo.Business.Factories
{
    public interface IResultFactory
    {
        IResult<T> GetBadRequestResult<T>(params string[] errorMessages);
        IResult<T> GetNotFoundResult<T>(params string[] errorMessages);
        IResult<T> GetNoContentResult<T>();
        IResult<T> GetOkResult<T>(T data);
        IResult<T> GetCreatedResult<T>(T data);
    }
}