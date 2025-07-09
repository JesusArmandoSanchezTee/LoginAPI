using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _ctx;
    public UserRepository(ApplicationDbContext ctx) => _ctx = ctx;

    public async Task AddAsync(User user)
    {
        await _ctx.Users.AddAsync(user);
        await _ctx.SaveChangesAsync();
    }
    public Task<User?> GetByEmailAsync(string email) =>
        _ctx.Users.SingleOrDefaultAsync(u => u.Email == email);
}