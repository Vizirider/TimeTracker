using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Net.Http.Headers;
using Server.Infrastructure.Dto;
using Server.Infrastructure.Dto.Requests.Role;

namespace BusinessLogicLayer.Role
{
    using System.Linq;

    using DataAccessLayer;

    using Server.Infrastructure.Enums;

    public class RoleLogic
    {
        public Role GetRole(Roles role)
        {
            using (var db = new TimeTrackerModelContainer())
            {
                var result =  db.Role.FirstOrDefault(x => x.Key.Equals(role.ToString()));

                if (result == null)
                {
                    throw new Exception("Nincs elérhető role");
                }
                return result;
            }
        }

        public bool IsPermmision(int userId, string  key)
        {
            bool flag = false;
            string resultKey = string.Empty;

            using (var db = new TimeTrackerModelContainer())
            {
                var result= from u in db.User
                    join ro in db.Role on u.RoleId equals ro.Id
                    join ppeerr in db.Permission on u.RoleId equals ppeerr.Id
                    where u.Id == userId
                    select ppeerr.Key;

                resultKey = result.First().ToString();
            }

            if (key.Equals(resultKey))
            {
                flag = true;
            }

            return flag;
        }

        public Role GetRoleTypeId(string userEmail)
        {
            Role role;

            using (var db = new TimeTrackerModelContainer())
            {
                var user = db.User.First(x => x.Email == userEmail);
                role = db.Role.First(x => x.Id == user.RoleId);
            }

            return role;
        }

        public List<RoleDto> GetAllRole()
        {
            List<RoleDto> role = new List<RoleDto>();

            using (var db = new TimeTrackerModelContainer())
            {
                var result = db.Role.AsEnumerable().ToList();

                foreach (var list in result)
                {
                    role.Add(new RoleDto
                    {
                        Id = list.Id,
                        Key = list.Key,
                        RoleTypeId = list.RoleTypeId
                    });
                }
            }

            return role;
        }

        public bool EditRole(long id, string key, RoleTypeEnum role)
        {

            bool flag = false;
            Role newRole;

            using (var db = new TimeTrackerModelContainer())
            {
                newRole = db.Role.First(x => x.Id == id);
                newRole.Id = id;
                newRole.Key = key;
                newRole.RoleTypeId = role;

                db.Entry(newRole).State = EntityState.Modified;
                db.SaveChanges();

                flag = true;
            }

            return flag;
        }

        public bool DelelteRole(long id)
        {
            bool flag = false;
            Role deleteRole;

            using (var db = new TimeTrackerModelContainer())
            {
                deleteRole = db.Role.First(x => x.Id == id);
                db.Role.Remove(deleteRole);
                db.SaveChanges();

                flag = true;
            }

            return flag;
        }

        public Role AddRole(Rolerequest request)
        {
            Role role = new Role
            {
                Key = request.Key,
                RoleTypeId = request.RoleTypeId
            };

            using (var db = new TimeTrackerModelContainer())
            {
                db.Role.Add(role);
                db.SaveChanges();
            }

            return role;
        }

        public Role GetRoleById(long id)
        {
            Role role;

            using (var db = new TimeTrackerModelContainer())
            {
                role = db.Role.First(x => x.Id == id);
            }

            return role;
        }
    }
}
