namespace ProjectManagementSystem.Domain.Abstractions;

public class DataResult<TData>
{
    private DataResult(bool isSuccess, Error error, TData? data = default)
    {
        if
        (
            (isSuccess && (error != Error.None || data is null)) ||
            (!isSuccess && (error == Error.None || data is not null))
        )
        {
            throw new ArgumentException("Invalid error", nameof(error));
        }

        Data = data;
        IsSuccess = isSuccess;
        Error = error;
    }

    public bool HasValue => Data != null;
    public TData? Data { get; private set; }
    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;
    public Error Error { get; }

    public static DataResult<TData> Success(TData data) => new (true, Error.None, data);
    public static DataResult<TData> Failure(Error error) => new(false, error);
}


