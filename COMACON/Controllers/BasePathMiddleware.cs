using System.Text.RegularExpressions;
using Serilog;

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

        Log.Logger.Information("Context Request Path Value: " + context.Request.Path.Value);
        if (path.StartsWith("/null"))
        {
            // Remove the leading /null from the path
            context.Request.Path = path.Substring(5);
        }
        else if (path.StartsWith("/core"))
        {
            string pattern = @"^/core/.*/api/Endpoint$";
            if (Regex.IsMatch(path, pattern))
            {
                string[] strings = path.Split('/');
                // Remove the leading /core from the path as well as the next 1 segment.
                context.Request.Path = path.Substring(path.IndexOf(strings[1] + "/" + strings[2]) + (strings[0].Length + 1 + strings[1].Length));
            }
        }

        Log.Logger.Information("New Context Request Path Value: " + context.Request.Path.Value);

        await _next(context);
    }
}