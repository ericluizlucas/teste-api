using System.Net;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

public static class ResponseHelper
{
    public static JsonResult Ok(object objReturn)
    {
        ResponseDefault resp = new ResponseDefault(objReturn);
        return new JsonSuccessResult(resp);
    }
    public static JsonResult Ok<T>(T objReturn)
    {
        var serializedObject = JsonConvert.SerializeObject(objReturn);
        ResponseDefault resp = new ResponseDefault(JsonConvert.DeserializeObject<T>(serializedObject));
        return new JsonSuccessResult(resp);
    }
    public static JsonResult Error(string txtmessage, HttpStatusCode statusCode)
    {
        ResponseError resp = new ResponseError(txtmessage);
        return new JsonErrorResult(resp, statusCode);
    }
}
