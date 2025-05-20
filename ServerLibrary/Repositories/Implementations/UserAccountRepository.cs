using BaseLibrary.DTOs;
using BaseLibrary.Responses;
using Microsoft.Extensions.Options;
using ServerLibrary.Data;
using ServerLibrary.Repositories.Contracts;
using ServerLibrary.Helpers;
using Microsoft.EntityFrameworkCore;
using BaseLibrary.Entities;

namespace ServerLibrary.Repositories.Implementations
{
    internal class UserAccountRepository(IOptions<JwtSection>config, AppDbContext appDbContext): IUserAccont
    {
        public async Task<GeneralResponse> CreateAsync(Register user)
        {
            if (user is null)
                return new GeneralResponse(false, "User cannot be null");

            var checkUser = await FindUserByEmail(user.Email!);
            if (checkUser is not null)
                return new GeneralResponse(false, "User already exists");

            // Saving Student
            var student = await AddToDatabase(new Student()
            {
                UserName = user.UserName,
                Email = user.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(user.Password),
                Role = user.Role
            });

            // Return success response
            return new GeneralResponse(true, "User created successfully");
        }

        private async Task<T> AddToDatabase<T>(T model)
        {
            var result = appDbContext.Add(model!);
            await appDbContext.SaveChangesAsync();
            return (T)result.Entity;
        }

        private async Task<Student?> FindUserByEmail(string email)
        {
            return await appDbContext.Students.FirstOrDefaultAsync(s => s.Email!.ToLower()!.Equals(email!.ToLower()));
        }

        public Task<LoginResponse> SignInAsync(Login user)
        {
            throw new NotImplementedException();
        }

    }
}
