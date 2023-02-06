using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using mustafarbackend.Modules.Users.Entities;
using Mustafarbackend.Modules.Users.Dtos;
using Mustafarbackend.Modules.Users.Interfaces.Services.User;
using Mustafarbackend.Repository;
using AutoMapper;
using Mustafarbackend.Modules.Users.Models;
using Mustafarbackend.Utils.Functions;

namespace Mustafarbackend.Modules.Users.Services
{
    public class UserService : IUserService
    {
        private IRepository<UserEntity> _repository;
        private readonly IMapper _mapper;

        public UserService(IRepository<UserEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> Delete(Guid id)
        {
            var userExists = await _repository.SelectAsync(id);

            if (userExists == null)
            {
                throw new ArgumentNullException("user not exists");
            }

            return await _repository.DeleteAsync(id);
        }

        public async Task<UserDto> Get(Guid id)
        {
            UserEntity entity = await _repository.SelectAsync(id);
            return entity is not null ? _mapper.Map<UserDto>(entity) : null;
        }

        public async Task<IEnumerable<UserDto>> GetAll()
        {
            IEnumerable<UserEntity> listEntity = await _repository.SelectAsync();
            return _mapper.Map<IEnumerable<UserDto>>(listEntity);
        }

        public async Task<UserDtoCreateResult> Post(UserDtoCreate user)
        {
            UserModel model = _mapper.Map<UserModel>(user);
            UserEntity entity = _mapper.Map<UserEntity>(model);
            entity.Password = PasswordHashed.HashPassword(user.Password);
            UserEntity result = await _repository.InsertAsync(entity);

            return _mapper.Map<UserDtoCreateResult>(result);
        }

        public async Task<UserDtoUpdateResult> Put(UserDtoUpdate user)
        {
            var userExists = await _repository.SelectAsync(user.Id);

            if (userExists == null)
            {
                throw new ArgumentNullException("user not exists");
            }

            UserModel model = _mapper.Map<UserModel>(user);
            UserEntity entity = _mapper.Map<UserEntity>(model);

            entity.Password = userExists.Password;

            UserEntity result = await _repository.UpdateAsync(entity);

            return _mapper.Map<UserDtoUpdateResult>(result);
        }
    }
}