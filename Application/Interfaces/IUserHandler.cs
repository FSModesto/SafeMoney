using Application.ViewModel.Request;
using Application.ViewModel.Response;

namespace Application.Interfaces
{
    public interface IUserHandler
    {
        Task<BaseResponse<CreateUserResponse>> CreateUser(CreateUserRequest request);
        Task<BaseResponse<ResetPasswordEmailResponse>> NewPasswordEmail(ResetPasswordEmailRequest request);
        Task<BaseResponse<LoginResponse>> LoginUser(LoginRequest request);
    }
}
