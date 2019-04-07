using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingSystem.Common.Interfaces;
using BookingSystem.Queries.Queries.UserQueries.Views;
using BookingSystem.ReadPersistence;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem.Queries.Queries.UserQueries.Queries
{
    public class UserDetailsQuery : IQuery<UserView>
    {
        public int UserId { get; }

        public UserDetailsQuery(int userId)
        {
            UserId = userId;
        }
    }

    public class UserDetailsQueryHandler : IQueryHandler<UserDetailsQuery, UserView>
    {
        private readonly BookingReadContext _dataContext;

        public UserDetailsQueryHandler(BookingReadContext dataContext)
        {
            _dataContext = dataContext;
        }

        public Task<UserView> ExecuteAsync(UserDetailsQuery query)
        {
            var users = (from user in _dataContext.Users
                where user.UserId == query.UserId
                join userRoles in _dataContext.UserRoles on user.UserId equals userRoles.UserId
                join role in _dataContext.Roles on userRoles.RoleId equals role.RoleId into roles
                from role in roles.DefaultIfEmpty()
                select new { user, roleName = role.Name }).ToList();
            var userView =
                (from user in users
                    group user.roleName by user.user
                    into gr
                    select new UserView()
                    {
                        UserId = gr.Key.UserId,
                        Email = gr.Key.Email,
                        FirstName = gr.Key.FirstName,
                        SecondName = gr.Key.SecondName,
                        Roles = gr
                    }).FirstOrDefault();
            return Task.FromResult(userView);
        }
    }
}
