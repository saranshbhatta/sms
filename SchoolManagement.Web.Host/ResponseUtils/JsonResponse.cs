namespace SchoolManagement.Web.Host.ResponseUtils;

public class JsonResponse
{
    public bool IsSuccess { get; set; }
    public dynamic? ResponseData { get; set; }
    public string Message { get; set; }
    public int StatusCode { get; set; }
}