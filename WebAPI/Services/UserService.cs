using Microsoft.AspNetCore.Identity;
using Repositories.Context.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Services
{
    public interface IUserService
    {
        List<IUserOperation> Operations();
    }
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userMgr;

        public UserService(UserManager<ApplicationUser> userMgr)
        {
            _userMgr = userMgr;
        }
        public List<IUserOperation> Operations()
        {
            var list = new List<IUserOperation>();
            list.Add(new UpdateName(_userMgr));
            list.Add(new UpdateTitle(_userMgr));
            list.Add(new UpdatePhone(_userMgr));
            list.Add(new UpdateRole(_userMgr));
            return list;
        }
    }
    public class UpdateName : IUserOperation
    {
        private readonly UserManager<ApplicationUser> _userMgr;

        public UpdateName(UserManager<ApplicationUser> userMgr)
        {
            _userMgr = userMgr;
        }
        public bool IsMatch(string user)
        {
            return user == "name";
        }

        public async Task UpdateUser(UserIdAndValue user)
        {
            try
            {
                var existingUser = await _userMgr.FindByIdAsync(user.Id);
                existingUser.Name = user.Value;
                var result = await _userMgr.UpdateAsync(existingUser);
                Console.Write(result);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                throw;
            }

        }
    }
    public class UpdateTitle : IUserOperation
    {
        private readonly UserManager<ApplicationUser> _userMgr;

        public UpdateTitle(UserManager<ApplicationUser> userMgr)
        {
            _userMgr = userMgr;
        }
        public bool IsMatch(string user)
        {
            return user == "title";
        }
        public async Task UpdateUser(UserIdAndValue user)
        {
            try
            {
                var existingUser = await _userMgr.FindByIdAsync(user.Id);
                existingUser.JobTitle = user.Value;
                await _userMgr.UpdateAsync(existingUser);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                throw;
            }
        }
    }

    public class UpdatePhone : IUserOperation
    {
        private readonly UserManager<ApplicationUser> _userMgr;

        public UpdatePhone(UserManager<ApplicationUser> userMgr)
        {
            _userMgr = userMgr;
        }
        public bool IsMatch(string user)
        {
            return user == "phone";
        }
        public async Task UpdateUser(UserIdAndValue user)
        {
            try
            {
                var existingUser = await _userMgr.FindByIdAsync(user.Id);
                existingUser.PhoneNumber = user.Value;
                await _userMgr.UpdateAsync(existingUser);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                throw;
            }
        }
    }
    public class UpdateRole : IUserOperation
    {
        private readonly UserManager<ApplicationUser> _userMgr;

        public UpdateRole(UserManager<ApplicationUser> userMgr)
        {
            _userMgr = userMgr;
        }
        public bool IsMatch(string type)
        {
            return type != "phone" && type != "name" && type!="title";
        }
        public async Task UpdateUser(UserIdAndValue user)
        {
            try
            {
                var existingUser = await _userMgr.FindByIdAsync(user.Id);
                var userRoles = await _userMgr.GetRolesAsync(existingUser);
                if (user.Value == "on")
                {
                    var existingRole= userRoles.FirstOrDefault(d => d == user.Type);
                    if (existingRole == null)
                        userRoles.Insert(0, user.Type);
                }
                else
                {
                    var existingRole = userRoles.FirstOrDefault(d => d == user.Type);
                    if (existingRole != null)
                        userRoles.Remove(user.Type);
                }
                await _userMgr.UpdateAsync(existingUser);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                throw;
            }
        }
    }
    public interface IUserOperation
    {
        Boolean IsMatch(string user);
        Task UpdateUser(UserIdAndValue user);
    }
    public class UserIdAndValue
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
    }

}
