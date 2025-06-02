using SchoolManagement.Web.Host.ResponseUtils;

public static class Wrapper
{
    // Success (200 OK)
    public static IResult Success(dynamic? data = null, string message = "Success")
    {
        return Results.Ok(new JsonResponse
        {
            IsSuccess = true,
            ResponseData = data,
            Message = message,
            StatusCode = StatusCodes.Status200OK
        });
    }

    // Created (201)
    public static IResult Created(dynamic? data, string message = "Resource created successfully")
    {
        return Results.Created("", new JsonResponse
        {
            IsSuccess = true,
            ResponseData = data,
            Message = message,
            StatusCode = StatusCodes.Status201Created
        });
    }

    // No Content (204)
    public static IResult NoContent(string message = "No content available")
    {
        return Results.Ok(new JsonResponse
        {
            IsSuccess = true,
            ResponseData = null,
            Message = message,
            StatusCode = StatusCodes.Status204NoContent
        });
    }

    // Bad Request (400)
    public static IResult BadRequest(string message = "Invalid request", dynamic? errors = null)
    {
        return Results.BadRequest(new JsonResponse
        {
            IsSuccess = false,
            ResponseData = errors,
            Message = message,
            StatusCode = StatusCodes.Status400BadRequest
        });
    }

    // Unauthorized (401)
    public static IResult Unauthorized(string message = "Unauthorized access")
    {
        return Results.Json(new JsonResponse
        {
            IsSuccess = false,
            ResponseData = null,
            Message = message,
            StatusCode = StatusCodes.Status401Unauthorized
        }, statusCode: StatusCodes.Status401Unauthorized);
    }

    // Forbidden (403)
    public static IResult Forbidden(string message = "Forbidden access")
    {
        return Results.Json(new JsonResponse
        {
            IsSuccess = false,
            ResponseData = null,
            Message = message,
            StatusCode = StatusCodes.Status403Forbidden
        }, statusCode: StatusCodes.Status403Forbidden);
    }

    // Not Found (404)
    public static IResult NotFound(string message = "Resource not found")
    {
        return Results.NotFound(new JsonResponse
        {
            IsSuccess = false,
            ResponseData = null,
            Message = message,
            StatusCode = StatusCodes.Status404NotFound
        });
    }

    // Conflict (409)
    public static IResult Conflict(string message = "Conflict occurred")
    {
        return Results.Conflict(new JsonResponse
        {
            IsSuccess = false,
            ResponseData = null,
            Message = message,
            StatusCode = StatusCodes.Status409Conflict
        });
    }

    // Internal Server Error (500)
    public static IResult InternalError(string message = "An error occurred while processing your request")
    {
        return Results.Json(new JsonResponse
        {
            IsSuccess = false,
            ResponseData = null,
            Message = message,
            StatusCode = StatusCodes.Status500InternalServerError
        }, statusCode: StatusCodes.Status500InternalServerError);
    }

    // Custom Status Code
    public static IResult CustomResponse(dynamic? data, string message, int statusCode, bool isSuccess)
    {
        return Results.Json(new JsonResponse
        {
            IsSuccess = isSuccess,
            ResponseData = data,
            Message = message,
            StatusCode = statusCode
        }, statusCode: statusCode);
    }
}