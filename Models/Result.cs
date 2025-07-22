
using System.Collections.Generic;

namespace ResultHandling.Models;

public class Result
{
    public bool IsSuccess { get; }
    public List<string> Errors { get; }
    public int StatusCode { get; }

    private Result(bool isSuccess, List<string> errors, int statusCode)
    {
        IsSuccess = isSuccess;
        Errors = errors;
        StatusCode = statusCode;
    }

    public static Result Success() => new Result(true, null, 200);
    public static Result Failure(string error, int statusCode = 400) =>
        new Result(false, new List<string> { error }, statusCode);
    public static Result Failure(List<string> errors, int statusCode = 400) =>
        new Result(false, errors, statusCode);
}
