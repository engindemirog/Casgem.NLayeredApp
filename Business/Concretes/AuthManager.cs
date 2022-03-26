using Business.Abstracts;
using Business.Dtos;
using Core.CrossCuttingConcerns.Exceptions;
using Core.CrossCuttingConcerns.Security.Entities;
using Core.CrossCuttingConcerns.Security.Hashing;
using Core.CrossCuttingConcerns.Security.Jwt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        public User Register(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new User
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            _userService.Add(user);
            return user;
        }

        public User Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByMail(userForLoginDto.Email);
            if (userToCheck == null)
            {
                throw new BusinessException("Kullanıcı bulunamadı");
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                throw new BusinessException("Parola hatası");
            }

            return userToCheck;
        }

        public void UserExists(string email)
        {
            if (_userService.GetByMail(email) != null)
            {
                throw new BusinessException("Kullanıcı zaten mevcut");
            }
        }

        public AccessToken CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims);
            return accessToken;
        }
    }
}
