namespace OrderCompany.Shared.Dtos;

public class ErrorDto
{
    public List<string> Errors { get; private set; }


    public ErrorDto()
    {
        Errors = new List<string>();
    }

    public ErrorDto(string error)
    {
        Errors.Add(error);
    }

    public ErrorDto(List<string> errors)
    {
        Errors = errors;
    }
}