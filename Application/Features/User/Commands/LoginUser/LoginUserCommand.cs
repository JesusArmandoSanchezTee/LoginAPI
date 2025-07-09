using MediatR;

namespace Application.Features.User.Commands.LoginUser;

public record LoginUserCommand(string Email, string Password) : IRequest<string>;