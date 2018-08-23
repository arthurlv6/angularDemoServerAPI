using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Entities;
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
            return user == "Name";
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
            return user == "Title";
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
