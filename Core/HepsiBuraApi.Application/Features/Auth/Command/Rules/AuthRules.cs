using HepsiBuraApi.Application.Bases;
using HepsiBuraApi.Application.Features.Auth.Exceptions;
using HepsiBuraApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HepsiBuraApi.Application.Features.Auth.Command.Rules
{
    public class AuthRules:BaseRules
    {
        public Task UserShouldNotBeExist(User? user)
        {
            if (user != null) throw new UserAlreadyExistException();
            return Task.CompletedTask;

        }

        public Task EmailOrPasswordShouldNotBeInvalid(User? user, bool checkPassword)
        {
            if (user == null || !checkPassword) throw new UserAlreadyExistException();
            return Task.CompletedTask;
        }
    }
}
