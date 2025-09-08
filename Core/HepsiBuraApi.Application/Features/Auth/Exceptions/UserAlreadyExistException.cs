using HepsiBuraApi.Application.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HepsiBuraApi.Application.Features.Auth.Exceptions
{
    public class UserAlreadyExistException:BaseException
    {
        public UserAlreadyExistException():base("Kullanıcı zaten var.")
        {
        }
    }

    public class EmailOrPasswordShouldNotBeInvalid : BaseException
    {
        public EmailOrPasswordShouldNotBeInvalid() : base("Kullanıcı Adı veya şifre hatalı.")
        {
        }
    }

}
