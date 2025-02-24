using Application.Interfaces;
using Application.ViewModel.Request;
using Application.ViewModel.Response;
using AutoMapper;
using Domain.Entities;
using Domain.Helpers;
using Domain.Interfaces;
using Domain.Interfaces.Services;
using Microsoft.Extensions.Configuration;

namespace Application.Handlers
{
    public class UserHandler : BaseHandler, IUserHandler
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _repository;
        private readonly ITokenService _tokenService;
        private readonly ISendEmailService _sendEmailService;
        private readonly string _apiUrl;

        public UserHandler(
            IUserRepository repository,
            IMapper mapper,
            ITokenService tokenService,
            ISendEmailService sendEmailService,
            IServiceProvider serviceProvider,
            IConfiguration configuration) : base(serviceProvider)
        {
            _repository = repository;
            _mapper = mapper;
            _tokenService = tokenService;
            _sendEmailService = sendEmailService;
            _apiUrl = configuration.GetValue<string>("SafeMoneyAPI:URL");
        }

        public async Task<BaseResponse<CreateUserResponse>> CreateUser(CreateUserRequest request)
        {
            //Valida request
            var validation = ValidateRequest(request);
            if (!validation.IsValid)
                return ErrorResponse<CreateUserResponse>(validation.Errors);

            //mapeia
            var newUser = _mapper.Map<User>(request);

            //gera uma senha random
            var randomPassword = StringHelpers.GenerateRandomString();
            newUser.Password = randomPassword;

            //cria e adiciona no banco de dados
            var createdUser = await _repository.Add(newUser);
            if (createdUser.Id == null)
                return ErrorResponse<CreateUserResponse>("Ocorreu um erro inesperado ao tentar criar o usuário");

            //tempo de expirar o token e criação do token
            var expiration = TimeSpan.FromHours(1);
            var token = _tokenService.CreateToken(createdUser, expiration);
            if (token == null)
                return ErrorResponse<CreateUserResponse>("O token informado é inválido ou está expirado.");

            //email
            var resetLink = $"{_apiUrl}/novasenha?token={token}\n";
            var subject = "Redefinição de senha para acessar SafeMoney.";
            var message = $"Caro usuário,\n" +
                $"\nClique aqui para definir sua senha: {resetLink}\n" +
                $"\nSafe Money";

            var sendEmailLink = await _sendEmailService.SendEmail(request.Email, subject, message);
            if (!sendEmailLink)
            {
                await _repository.Remove(createdUser);
                return ErrorResponse<CreateUserResponse>("Tivemos um problema com seu e-mail e não conseguimos concluir o seu cadastro.");
            }

            var response = _mapper.Map<CreateUserResponse>(createdUser);
            return SuccessResponse(response);
        }
    }
}
