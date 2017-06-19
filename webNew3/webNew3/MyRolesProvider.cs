using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using webNew3.Models;

namespace webNew3
{
    public class MyRolesProvider : RoleProvider
    {
        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            string[] rolesArray;
            if (!string.IsNullOrEmpty(username))
            {
                BookDbContext bookDbContext = new BookDbContext();
                User user = bookDbContext.Users.FirstOrDefault(x => x.Email == username);
                if (user != null)
                {
                    string role = user.Role;
                    rolesArray = new string[1] { role };
                    return rolesArray;
                }
                
            }
            rolesArray = new string[1]{ "" };
            return rolesArray;
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}