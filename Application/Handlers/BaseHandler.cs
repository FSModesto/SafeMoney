using Application.ViewModel.Response.User;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel.DataAnnotations;
using System.Net;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace Application.Handlers
{
    public class BaseHandler
    {
        private readonly IServiceProvider _serviceProvider;
        public BaseHandler(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public static BaseResponse<T> SuccessResponse<T>
            (T data,
            string? message = "Operação realizada com sucesso.",
            HttpStatusCode code = HttpStatusCode.OK)
        {
            return new BaseResponse<T>()
            {
                Data = data,
                Message = message,
                StatusCode = code
            };
        }

        public static BaseResponse<T> SuccessResponse<T>(string message, HttpStatusCode code = HttpStatusCode.OK)
        {
            return new BaseResponse<T>()
            {
                Message = message,
                StatusCode = code
            };
        }

        public static BaseResponse<T> ErrorResponse<T>
            (List<FluentValidation.Results.ValidationFailure> errors,
            string? message = "Erro ao processar a requisição.",
            HttpStatusCode code = HttpStatusCode.BadRequest)
        {
            var responseErrors = new List<ValidationErrorsResponse>();
            foreach (var error in errors)
                responseErrors.Add(new ValidationErrorsResponse()
                {
                    ErrorMessage = error.ErrorMessage,
                    PropertyName = error.PropertyName
                });

            return new BaseResponse<T>()
            {
                Errors = responseErrors,
                Message = message,
                StatusCode = code
            };
        }

        public static BaseResponse<T> ErrorResponse<T>(string message, HttpStatusCode code = HttpStatusCode.BadRequest)
        {
            return new BaseResponse<T>()
            {
                Message = message,
                StatusCode = code
            };
        }

        public ValidationResult ValidateRequest<T>(T request)
        {
            IValidator<T>? validator = _serviceProvider.GetService<IValidator<T>>();
            ArgumentNullException.ThrowIfNull(validator);
            return validator.Validate(request);
        }
    }
}
