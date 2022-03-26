using Business.Dtos;
using Core.CrossCuttingConcerns.Security.Entities;
using Core.CrossCuttingConcerns.Security.Jwt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IAuthService
    {
        User Register(UserForRegisterDto userForRegisterDto, string password);
        User Login(UserForLoginDto userForLoginDto);
        void UserExists(string email);
        AccessToken CreateAccessToken(User user);
    }
}
