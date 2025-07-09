using Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Domain.Exceptions;

namespace Application.Features.User.Commands.RegisterUser;

public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, int>
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher<Domain.Entities.User> _passwordHasher;

    public RegisterUserCommandHandler(IUserRepository userRepository, IPasswordHasher<Domain.Entities.User> passwordHasher)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
    }
    public async Task<int> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var userExists = await _userRepository.GetByEmailAsync(request.Email);
        if (userExists != null)
            throw new CustomException("User already exists");

        var user = new Domain.Entities.User(request.Email, "");
        user.SetPasswordHash(_passwordHasher.HashPassword(user, request.Password));

        await _userRepository.AddAsync(user);
        return user.Id;
    }
}