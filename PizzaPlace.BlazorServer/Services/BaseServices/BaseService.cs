using AutoMapper;
using Blazored.Toast.Services;
using PizzaPlace.BlazorServer.Helpers;

namespace PizzaPlace.BlazorServer.Services.BaseServices
{
    /// <summary>
    /// A base service class that provides common dependencies and utility methods to derived services.
    /// </summary>
    public class BaseService
    {
        protected readonly DataContext _context;
        protected readonly GlobalEventService _globalEventService;
        protected readonly IMapper _mapper;
        protected readonly IToastService _toastService;

        public BaseService(DataContext dataContext, GlobalEventService globalEventService, IMapper mapper, IToastService toastService)
        {
            _context = dataContext;
            _globalEventService = globalEventService;
            _mapper = mapper;
            _toastService = toastService;
        }


        /// <summary>
        /// Executes the provided asynchronous function and handles potential errors by sending 
        /// notifications and returning appropriate <see cref="OperationResponse"/>.
        /// </summary>
        /// <param name="func">The asynchronous function to be invoked.</param>
        /// <param name="notifications">Flag to determine if toast notifications should be displayed based on the operation's result. Defaults to false.</param>
        /// <returns>An instance of <see cref="OperationResponse"/> indicating the outcome of the operation.</returns>
        /// <remarks>
        /// The method will handle errors by displaying a "Critical error, please try again later" toast notification 
        /// and returning an <see cref="OperationResponse"/> with a Fail result.
        /// If the provided function succeeds, additional toast notifications might be shown based on the result and 
        /// the notifications parameter.
        /// </remarks>
        protected async Task<OperationResponse> ProcessRequestAsync(Func<Task<OperationResponse>> func, bool notifications = false)
        {
            try
            {
                var response = await func.Invoke();

                if(notifications)
                {
                    if(response.Result == OperationResult.Ok)
                        _toastService.ShowSuccess(response.Message);

                    if(response.Result == OperationResult.NotFound)
                        _toastService.ShowInfo(response.Message);
                }

                return response;

            }
            catch
            {
                _toastService.ShowError("Critical error, please try again later");
                return OperationResponse.Fail();
            }
        }


        /// <summary>
        /// Executes the provided asynchronous function returning a generic result and handles potential 
        /// errors by sending notifications and returning appropriate <see cref="OperationResponse{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type of the result encapsulated in the operation response.</typeparam>
        /// <param name="func">The asynchronous function to be invoked, returning a generic result.</param>
        /// <param name="notifications">Flag to determine if toast notifications should be displayed based on the operation's result. Defaults to false.</param>
        /// <returns>An instance of <see cref="OperationResponse{T}"/> indicating the outcome of the operation and containing the result of type <typeparamref name="T"/>.</returns>
        /// <remarks>
        /// The method will handle errors by displaying a "Critical error, please try again later" toast notification 
        /// and returning an <see cref="OperationResponse{T}"/> with a Fail result.
        /// If the provided function succeeds, additional toast notifications might be shown based on the result and 
        /// the notifications parameter.
        /// </remarks>
        protected async Task<OperationResponse<T>> ProcessRequestAsync<T>(Func<Task<OperationResponse<T>>> func, bool notifications = false)
        {
            try
            {
                var response = await func.Invoke();

                if (notifications)
                {
                    if (response.Result == OperationResult.Ok)
                        _toastService.ShowSuccess(response.Message);

                    if (response.Result == OperationResult.NotFound)
                        _toastService.ShowInfo(response.Message);
                }

                return response;

            }
            catch
            {
                _toastService.ShowError("Critical error, please try again later");
                return OperationResponse<T>.Fail();
            }
        }
    }
}
