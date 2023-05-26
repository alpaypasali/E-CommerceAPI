﻿using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class EfUserDal : EfEntityRepositoryBase<User, PasaliDbContext>, IUserDal
    {

        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new PasaliDbContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                                 on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.Id == user.UserId
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();

            }
        }
        public UserDTO GetDTO(Expression<Func<User, bool>> filter)
        {
            using (var context = new PasaliDbContext())
            {
                var result = from user in context.Users.Where(filter)
                             select new UserDTO { Id = user.UserId, FirstName = user.FirstName, LastName = user.LastName, Email = user.Email };
                return result.SingleOrDefault();
            }
        }
    }
}
