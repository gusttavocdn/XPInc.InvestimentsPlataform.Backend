namespace Application.Exceptions;

public class HttpStatusException : Exception
{
	public int StatusCode { get; set; }

	public HttpStatusException(int statusCode, string message) : base(message)
	{
		StatusCode = statusCode;
	}
}