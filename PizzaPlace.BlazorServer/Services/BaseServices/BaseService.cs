using AutoMapper;
using Blazored.Toast.Services;
using Microsoft.EntityFrameworkCore;
using PizzaPlace.BlazorServer.Helpers;

namespace PizzaPlace.BlazorServer.Services.BaseServices
{
    /// <summary>
    /// A base service class that provides common dependencies and utility methods to derived services.
    /// </summary>
    public class BaseService
    {
        protected readonly GlobalEventService _globalEventService;
        protected readonly IMapper _mapper;
        protected readonly IToastService _toastService;

        private static string connString = string.Empty;
        public static string ConnString
        {
            get
            {
                return connString;
            }
            set
            {
                if (string.IsNullOrEmpty(connString))
                    connString = value;
            }
        }

        public BaseService(GlobalEventService globalEventService, IMapper mapper, IToastService toastService)
        {
            
            _globalEventService = globalEventService;
            _mapper = mapper;
            _toastService = toastService;
        }

        protected DataContext CreateDataContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
            optionsBuilder.UseNpgsql(ConnString);

            return new DataContext(optionsBuilder.Options);
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
        protected async Task<OperationResponse> ProcessRequestAsync(Func<DataContext, Task<OperationResponse>> func, bool notifications = false)
        {
            try
            {
                using (var context = CreateDataContext())
                {
                    var response = await func.Invoke(context);

                    if (notifications)
                    {
                        if (response.Result == OperationResult.Ok)
                            _toastService.ShowSuccess(response.Message);

                        if (response.Result == OperationResult.NotFound)
                            _toastService.ShowInfo(response.Message);
                    }

                    return response;
                }
            }
            catch (Exception ex)
            {
                throw ex;
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
        protected async Task<OperationResponse<T>> ProcessRequestAsync<T>(Func<DataContext, Task<OperationResponse<T>>> func, bool notifications = false)
        {
            try
            {
                using (var context = CreateDataContext())
                {

                    var response = await func.Invoke(context);

                    if (notifications)
                    {
                        if (response.Result == OperationResult.Ok)
                            _toastService.ShowSuccess(response.Message);

                        if (response.Result == OperationResult.NotFound)
                            _toastService.ShowInfo(response.Message);
                    }

                    return response;
                }

            }
            catch (Exception ex)
            {
                throw ex;
                _toastService.ShowError("Critical error, please try again later");
                return OperationResponse<T>.Fail();
            }
        }
    }
}
