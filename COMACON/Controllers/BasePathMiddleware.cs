public class BasePathMiddleware
{
    private readonly RequestDelegate _next;

    public BasePathMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var path = context.Request.Path.Value;

        //Locate the string "api/Endpoint" in the path.
        if (path.Contains("api/Endpoint"))
        {
            //If the string is found, remove all characters before it.
            path = path.Substring(path.IndexOf("api/Endpoint"));
        }

        // Check if the path starts with "/app" and adjust the request path
        //if (path.StartsWith("/app"))
        //{
        //    context.Request.Path = path.Substring(4); // Remove "/app" from the path
        //}

        await _next(context);
    }
}