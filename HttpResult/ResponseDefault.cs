public class ResponseDefault
{
    public object Result { get; set; }

    public ResponseDefault(object data)
    {
        Result = data;
    }
}
