
using System.Collections.Generic;

namespace ResultHandling.Models;

public class Result<T>
{
    public bool IsSuccess { get; }
    public List<string> Errors { get; }
    public int StatusCode { get; }
    public T Value { get; }

    private Result(T value)
    {
        IsSuccess = true;
        Value = value;
        StatusCode = 200;
    }

    private Result(List<string> errors, int statusCode)
    {
        IsSuccess = false;
        Errors = errors;
        StatusCode = statusCode;
    }

    public static Result<T> Success(T value) => new Result<T>(value);
    public static Result<T> Failure(string error, int statusCode = 400) =>
        new Result<T>(new List<string> { error }, statusCode);
    public static Result<T> Failure(List<string> errors, int statusCode = 400) =>
        new Result<T>(errors, statusCode);
}
