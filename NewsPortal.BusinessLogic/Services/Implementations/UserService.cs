using NewsPortal.BusinessLogic.Services.Interfaces;
using NewsPortal.Model.Domain;
using NewsPortal.DAL.Dto;
using Repositories.Interfaces;
using System.Linq;
using System.Threading.Tasks;
using System;
using NewsPortal.BusinessLogic.Services.Infrastructure;
using NewsPortal.Model;

namespace NewsPortal.BusinessLogic.Services.Implementations
{
    public class UserService : BaseService<UserDto, User, IUserRepository>, IUserService
    {
        public UserService(IUnitOfWork<WebApiContext> unitOfWork) :base(unitOfWork)
        {

        }
        public override async Task<UserDto> UpdateAsync(UserDto dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));
            var originalEntity = await GetByIdAsync(dto.Id);
            if (originalEntity == null) throw new NullReferenceException(nameof(originalEntity));
            originalEntity = MapForUpdateHelper.UserUpdateMap(dto, originalEntity);
            return await base.UpdateAsync(originalEntity);
            
        }
        public async Task<UserDto> GetByEmailAsync(string email)
        {
            var user = await _crudRepository.GetByCriteriaAsync( x=>x.Email==email);
            return user.SingleOrDefault();
        }
    }
}
