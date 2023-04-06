using Microsoft.AspNetCore.Mvc;
using System.Net;

public class JsonSuccessResult : JsonResult
{
    private readonly HttpStatusCode _statusCode;

    public JsonSuccessResult(object json) : this(json, HttpStatusCode.OK)
    {
    }

    public JsonSuccessResult(object json, HttpStatusCode statusCode) : base(json)
    {
        _statusCode = HttpStatusCode.OK;
    }

    public override void ExecuteResult(ActionContext context)
    {
        context.HttpContext.Response.StatusCode = (int)_statusCode;
        base.ExecuteResult(context);
    }

    public override Task ExecuteResultAsync(ActionContext context)
    {
        context.HttpContext.Response.StatusCode = (int)_statusCode;
        return base.ExecuteResultAsync(context);
    }
}