using AutoMapper;
using BusinessLayer.Interfaces;
using DataAccessLayer;
using RentalSystemModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BusinessLayer
{
    public class UserDetails : IBase<UserLoginModel>
    {
        public OverwatchRentalSystemEntities dbContext => OverwatchRentalSystemEntities.Instance;

        public IEnumerable<UserLoginModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserLoginModel> GetAll(int Id)
        {
            throw new NotImplementedException();
        }

        public int Login(UserLoginModel entity)
        {

            UserLogin user = null;
            bool status = false;
            try
            {
                user = Mapper.Map<UserLogin>(entity);
                status = dbContext.UserLogins.Any(u => u.UserEmail == user.UserEmail && u.UserPassword == user.UserPassword);
                user = dbContext.UserLogins.SingleOrDefault(i => i.UserEmail == user.UserEmail);
                
            }
            catch (Exception e)
            {
                throw e;
            }
            if (status)
            {
                // Creating Session For the Logged In User and Associated Role ID
                HttpContext.Current.Session.Add("UserId", user.Id);
                HttpContext.Current.Session.Add("RoleId", user.RoleId);
                int roleId = user.RoleId;
               
                return roleId;
            }

            else
                return 999;
        }


        

        public UserLoginModel Update(UserLoginModel entity)
        {
            throw new NotImplementedException();
        }

        // Returns Boolean value if User Details have been Inserted Or not
        public bool Insert(UserLoginModel entity)
        {
            UserLogin user = null;
            bool status = false;
            try
            {
                user = Mapper.Map<UserLogin>(entity);
                dbContext.UserLogins.Add(user);
                dbContext.SaveChanges();
                status = true;
            }
            catch (Exception e)
            {

                throw e;
            }
            return status;
        }

    }
}
