
using Microsoft.AspNetCore.Mvc;
using ResultHandling.Models;

namespace ResultHandling.Extensions;

public static class ResultExtensions
{
    public static IActionResult ToActionResult<T>(this Result<T> result)
    {
        if (result.IsSuccess)
        {
            return new OkObjectResult(result.Value);
        }

        return new ObjectResult(new
        {
            errors = result.Errors
        })
        {
            StatusCode = result.StatusCode
        };
    }

    public static IActionResult ToActionResult(this Result result)
    {
        if (result.IsSuccess)
        {
            return new OkResult();
        }

        return new ObjectResult(new
        {
            errors = result.Errors
        })
        {
            StatusCode = result.StatusCode
        };
    }
}
