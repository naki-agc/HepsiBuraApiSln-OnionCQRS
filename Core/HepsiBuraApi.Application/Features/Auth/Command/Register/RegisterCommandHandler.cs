using HepsiBuraApi.Application.Bases;
using HepsiBuraApi.Application.Features.Auth.Command.Rules;
using HepsiBuraApi.Application.Features.Products.Rules;
using HepsiBuraApi.Application.Interface.AutoMapper;
using HepsiBuraApi.Application.Interface.UnitOfWorks;
using HepsiBuraApi.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;

namespace HepsiBuraApi.Application.Features.Auth.Command.Register
{
    public class RegisterCommandHandler : BaseHandler, IRequestHandler<RegisterCommandRequest, Unit>
    {
        private readonly AuthRules authrules;
        private readonly UserManager<User> userManager;
        private readonly RoleManager<Role> roleManager;

        public RegisterCommandHandler(AuthRules authRules, UserManager<User> userManager, RoleManager<Role> roleManager, IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
            : base(mapper, unitOfWork, httpContextAccessor)
        {
            this.authrules = authRules;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public async Task<Unit> Handle(RegisterCommandRequest request, CancellationToken cancellationToken)
        {
            await authrules.UserShouldNotBeExist(await userManager.FindByEmailAsync(request.Email));
            User user = _mapper.Map<User, RegisterCommandRequest>(request);
            user.UserName = request.Email;
            user.SecurityStamp = Guid.NewGuid().ToString(); // Güvenlik damgası ekleniyorÖrneğin aynı isimde mükerrer kullanıcı eklenmesin diye milisaniyelerle buna bakılıyor.
            //butona ilk basan değişir ikinci oda onu gncellemeye çalışırsa patlar.bunu yapınca securityStamp değişir ve sorun çözülür.

            IdentityResult result = await userManager.CreateAsync(user, request.Password);
            if (result.Succeeded)
            {
                if (!await roleManager.RoleExistsAsync("User")) // User rolü yoksa oluştur
                {
                    await roleManager.CreateAsync(new Role 
                    {
                        Id = Guid.NewGuid(),
                        Name = "User" ,
                        NormalizedName= "USER",
                        ConcurrencyStamp= Guid.NewGuid().ToString()

                    });
                }
                await userManager.AddToRoleAsync(user, "User"); // Yeni kullanıcıya User rolünü ekle

            }
            return Unit.Value;
        }
    }
}
