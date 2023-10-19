
namespace PizzaPlace.BlazorServer.Helpers;

/// <summary>
/// Represents the response of an operation without any additional data.
/// </summary>
public class OperationResponse
{

    /// <summary>
    /// Gets the result of the operation.
    /// </summary>
    public OperationResult Result { get; private set; }


    /// <summary>
    /// Gets a message that provides additional information about the operation result.
    /// </summary>
    public string Message { get; private set; } = string.Empty;


    /// <summary>
    /// Initializes a new instance of the <see cref="OperationResponse"/> class.
    /// </summary>
    /// <param name="result">The result of the operation.</param>
    /// <param name="message">An optional message providing additional details about the result.</param>
    public OperationResponse(OperationResult result, string message = "")
    {
        Result = result;
        Message = message;
    }

    /// <summary>
    /// Creates a new instance of the <see cref="OperationResponse"/> class with a result of Ok.
    /// </summary>
    /// <param name="message">An optional message providing additional details about the result. Defaults to "Success".</param>
    /// <returns>An operation response with the specified message.</returns>
    public static OperationResponse Ok(string message = "Success") => new OperationResponse(OperationResult.Ok, message);

    /// <summary>
    /// Creates a new instance of the <see cref="OperationResponse"/> class with a result of Fail.
    /// </summary>
    /// <param name="message">An optional message providing additional details about the result. Defaults to "Success".</param>
    /// <returns>An operation response with the specified message.</returns>
    public static OperationResponse Fail(string message = "Fail") => new OperationResponse(OperationResult.Fail, message);

    /// <summary>
    /// Creates a new instance of the <see cref="OperationResponse"/> class with a result of NotFound.
    /// </summary>
    /// <param name="message">An optional message providing additional details about the result. Defaults to "Success".</param>
    /// <returns>An operation response with the specified message.</returns>
    public static OperationResponse NotFound(string message = "Not Found") => new OperationResponse(OperationResult.NotFound);

}

/// <summary>
/// Represents the response of an operation with additional data of type <typeparamref name="T"/>.
/// </summary>
/// <typeparam name="T">The type of data associated with the operation response.</typeparam>
public class OperationResponse<T> : OperationResponse
{

    /// <summary>
    /// Gets the data associated with the operation response.
    /// </summary>
    public T Data { get; private set; }


    /// <summary>
    /// Initializes a new instance of the <see cref="OperationResponse{T}"/> class.
    /// </summary>
    /// <param name="result">The result of the operation.</param>
    /// <param name="data">The data associated with the operation response.</param>
    /// <param name="message">An optional message providing additional details about the result.</param>
    public OperationResponse(OperationResult result, string message = "", T data = default) : base (result, message)
    {
        Data = data;
    }


    /// <summary>
    /// Generates an <see cref="OperationResponse{T}"/> based on the T being null.
    /// </summary>
    /// <param name="data">The data to be associated with the operation response.</param>
    /// <param name="success_message">The message to be used if the operation was successful. Defaults to "Success".</param>
    /// <param name="not_found_message">The message to be used if the data is null (indicating a not found scenario). Defaults to "Not Found".</param>
    /// <returns>
    /// An <see cref="OperationResponse{T}"/> with a result of <see cref="OperationResult.NotFound"/> if the data is null,
    /// otherwise an <see cref="OperationResponse{T}"/> with a result of <see cref="OperationResult.Ok"/> and the provided data.
    /// </returns>
    /// <remarks>
    /// This method simplifies the generation of operation responses by automatically determining the result based on the presence of the data.
    /// </remarks>
    public static OperationResponse<T> CreateDataResponse(T data, string success_message = "Success", string not_found_message = "Not Found", string fail_message = "Fail")
    {
            if (data is null)
                return OperationResponse<T>.NotFound(not_found_message);

            return OperationResponse<T>.Ok(data, success_message);
    }

    /// <summary>
    /// Creates a new instance of the <see cref="OperationResponse{T}"/> class with a result of Ok.
    /// </summary>
    /// <param name="data">The data associated with the operation response.</param>
    /// <param name="message">An optional message providing additional details about the result. Defaults to "Success".</param>
    /// <returns>An operation response with the specified data and message.</returns>
    public static OperationResponse<T> Ok(T data, string message = "Success") => new OperationResponse<T>(OperationResult.Ok, message, data);

    /// <summary>
    /// Creates a new instance of the <see cref="OperationResponse{T}"/> class with a result of Fail.
    /// </summary>
    /// <param name="message">An optional message providing additional details about the result. Defaults to "Fail".</param>
    /// <param name="data">The data associated with the operation response. Defaults to default value of T.</param>
    /// <returns>An operation response with the specified data and message.</returns>
    public static OperationResponse<T> Fail(string message = "Fail", T data = default) => new OperationResponse<T>(OperationResult.Fail, message, data);

    /// <summary>
    /// Creates a new instance of the <see cref="OperationResponse{T}"/> class with a result of NotFound.
    /// </summary>
    /// <param name="message">An optional message providing additional details about the result. Defaults to "Not Found".</param>
    /// <returns>An operation response with the specified message and default data.</returns>
    public static new OperationResponse<T> NotFound(string message = "Not Found") => new OperationResponse<T>(OperationResult.NotFound);


}
