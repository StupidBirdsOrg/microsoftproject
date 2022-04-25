namespace MyMicroservice;
public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private IHostEnvironment _environment;

    public ExceptionMiddleware(RequestDelegate next, IHostEnvironment environment)
    {
        _next = next;
        _environment = environment;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next.Invoke(context);
        }
        catch (Exception e)
        {
            await HandleException(context, e);
        }
    }

    private async Task HandleException(HttpContext context, Exception e)
    {
        context.Response.StatusCode = 500;
        context.Response.ContentType = "text/json;charset=utf-8;";
        var response = new BaseResult();
        response.Status = ResultStatus.Failure;
        response.Msg = _environment.IsDevelopment()?e.Message:"Failure";
        await context.Response.WriteAsync(System.Text.Json.JsonSerializer.Serialize(response));
    }
}