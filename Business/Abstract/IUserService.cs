using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        List<OperationClaim> GetClaims(User user);
        User GetByMail(string email);
        IDataResult<List<User>> GetAll();
        IDataResult<User> GetUserByMail(string email);
        IDataResult<User> GetUserById(int id);
        IResult Add(User user);
        IResult Update(UserForUpdateDto userForUpdateDto);
        IResult Delete(User user);
    }
}
