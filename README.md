# ResultHandling# Result Handling

[![NuGet](https://img.shields.io/nuget/v/ResultWrapper)](https://www.nuget.org/packages/ResultWrapper)
[![License](https://img.shields.io/github/license/YogeshKarpe/ResultHandling)](https://github.com/YogeshKarpe/ResultHandling/blob/main/LICENSE)

## Overview

**Result Handling** is a lightweight library for implementing the `Result<T>` pattern in .NET applications. It simplifies error handling and response management in ASP.NET Core APIs by providing a clean and consistent way to represent operation results with HTTP status codes, error messages, and seamless integration with `ActionResult`.

## Features

- **Generic and Non-Generic Results**: Supports both `Result<T>` (for operations returning a value) and `Result` (for operations without a return value).
- **Error Handling**: Includes error messages and HTTP status codes for failed operations.
- **ASP.NET Core Integration**: Provides extension methods to convert results into `IActionResult` for clean API responses.
- **.NET 8 Support**: Fully compatible with .NET 8 and C# 12.

## Installation

You can install the library via NuGet:
```bash
dotnet add package ResultWrapper
```
Or add the following to your `.csproj` file: 
```xml
<PackageReference Include="ResultWrapper" Version="1.0.0" />
```
## Usage

### 1. Using `Result<T>`

For operations that return a value:

```csharp
using ResultHandling.Models;

public Result<string> GetGreeting(bool isSuccess)
{
    if (isSuccess)
    {
        return Result<string>.Success("Hello, World!");
    }

    return Result<string>.Failure("An error occurred.", 400);
}
```

### 2. Using `Result`

For operations that do not return a value:

```csharp
using ResultHandling.Models;

public Result PerformOperation(bool isSuccess)
{
    if (isSuccess)
    {
        return Result.Success();
    }

    return Result.Failure("Operation failed.", 500);
}
```

### 3. Converting to `IActionResult` in ASP.NET Core

Use the provided extension methods to convert `Result` or `Result<T>` into `IActionResult`:

```csharp
using Microsoft.AspNetCore.Mvc;
using ResultHandling.Models;
using ResultHandling.Extensions;

[ApiController]
[Route("api/[controller]")]
public class ExampleController : ControllerBase
{
    [HttpGet]
    public IActionResult GetExample(bool isSuccess)
    {
        var result = isSuccess
            ? Result<string>.Success("Data retrieved successfully.")
            : Result<string>.Failure("Failed to retrieve data.", 404);

        return result.ToActionResult();
    }
}
```

### 4. Handling Errors

You can include multiple error messages for failed operations:

```csharp
var errors = new List<string> { "Error 1", "Error 2" };
var result = Result<string>.Failure(errors, 400);
```

## Metadata

- **Authors**: Yogesh Karpe
- **Company**: YogeshKarpe
- **Repository**: [GitHub Repository](https://github.com/YogeshKarpe/ResultHandling)

## License

This project is licensed under the MIT License. See the [LICENSE](https://github.com/YogeshKarpe/ResultHandling/blob/main/LICENSE) file for details.

## Contributing

Contributions are welcome! Feel free to open issues or submit pull requests to improve the library.

---

Happy coding!
