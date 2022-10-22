using System;
using PBL4.UserLogins.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace PBL4.UserLogins
{
    public class UserLoginAppService : CrudAppService<UserLogin, UserLoginDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateUserLoginDto, CreateUpdateUserLoginDto>, IUserLoginAppService
    {
        private readonly IUserLoginRepository _userLoginRepository;
        public UserLoginAppService(IUserLoginRepository userLoginRepository) : base(userLoginRepository)
        {
            _userLoginRepository = userLoginRepository;
        }
    }
}