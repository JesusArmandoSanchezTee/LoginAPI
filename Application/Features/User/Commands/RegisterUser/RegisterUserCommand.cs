using MediatR;

namespace Application.Features.User.Commands.RegisterUser;

public record RegisterUserCommand(string Email, string Password) : IRequest<int>;