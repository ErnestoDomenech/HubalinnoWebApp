using BaseLibrary.DTOs;
using BaseLibrary.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLibrary.Repositories.Contracts
{
    public interface IUserAccont
    {
    //    Task<bool> RegisterUser(string userName, string password, string role);
    //    Task<bool> LoginUser(string userName, string password);
    //    Task<bool> LogoutUser(string userName);
    //    Task<bool> ChangePassword(string userName, string oldPassword, string newPassword);
    //    Task<bool> ResetPassword(string userName, string newPassword);
    //    Task<bool> DeleteUser(string userName);

        Task<GeneralResponse>CreateAsync(Register user);
        Task<LoginResponse> SignInAsync(Login user);
    }
}
