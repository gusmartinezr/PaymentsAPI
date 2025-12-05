namespace Application.DTOs.Generic;

public class ApiResponse<T>
{
    public bool IsSuccess { get; set; } = true;
    public T? Data { get; set; }
    public string DisplayMessage { get; set; } = string.Empty;
    public List<string>? ErrorMessages { get; set; }
}