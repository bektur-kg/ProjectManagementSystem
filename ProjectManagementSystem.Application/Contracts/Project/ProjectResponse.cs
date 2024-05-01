namespace ProjectManagementSystem.Application.Contracts.Project;

public record ProjectResponse
{
    public long Id { get; set; }
    public required string Title { get; set; }
    public required string CustomerCompanyTitle { get; set; }
    public required string ExecutorCompanyTitle { get; set; }
    //todo: add other properties
}

