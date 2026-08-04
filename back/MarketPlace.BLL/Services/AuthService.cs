using MarketPlace.BLL.Mapperly;
using MarketPlace.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarketPlace.BLL.Services
{
    public class AuthService
    {
        private readonly MapperProfile _mapper;
        private AuthRepository _repository;

        public AuthService(MapperProfile mapper, AuthRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<ServiceResponse> GetUserByIdAsync(string id)
        {
            var res = await _repository.GetUserByIdAsync(id);
            var dto = _mapper.UserToUserDto(res);
            if (res != null)
            {
                return ServiceResponse.Success($"Користувача з Id {res.Id} знайдено", dto);
            }
            return ServiceResponse.Failure($"Користувача з Id {res.Id} не знайдено");
        }
        public async Task<ServiceResponse> GetAllUsersAsync()
        {
            var res = await _repository.GetUsersAsync();
            if (res != null) return ServiceResponse.Success($"Знайдено {res.Count()} користувачів", _mapper.UsersToUserDtos(res));
            return ServiceResponse.Failure("Невдалося знайти користувачів");
        }

    }
}
