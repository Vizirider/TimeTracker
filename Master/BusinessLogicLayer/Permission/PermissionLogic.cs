using Server.Infrastructure.Dto;
using Server.Infrastructure.Dto.Requests.Permission;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using GalaSoft.MvvmLight.Helpers;

namespace BusinessLogicLayer.Permission
{
    using DataAccessLayer;

    public class PermissionLogic
    {
        public List<PermissionDto> GetAllPermission()
        {
            List<PermissionDto> PermissionList = new List<PermissionDto>();

            using (var db = new TimeTrackerModelContainer())
            {
                var resultList = db.Permission.AsEnumerable().ToList();

                foreach (var list in resultList)
                {
                    PermissionList.Add(new PermissionDto()
                    {
                        Id = list.Id,
                        Key = list.Key,
                        PermissionTypeId = list.PermissionTypeId
                    });
                }
            }

            return PermissionList;
        }

        public Permission AddPermission(PermissionRequest request)
        {
            Permission newPermission = new Permission
            {
                Id = request.Id,
                Key = request.Key,
                PermissionTypeId = request.PermissionTypeId
            };

            using (var db = new TimeTrackerModelContainer())
            {
                db.Permission.Add(newPermission);
                db.SaveChanges();
            }

            return newPermission;
        }

        public bool EditPermission(long id, string key, PermissionTypeEnum permissionType)
        {
            bool flag = false;
            Permission permission = new Permission
            {
                Id = id,
                Key = key,
                PermissionTypeId = permissionType

            };

            using (var db = new TimeTrackerModelContainer())
            {
                var result = db.Permission.First(x => x.Id == id);
                var s = db.Set<Permission>().Local.FirstOrDefault(x => x.Id == id);

                if (s != null)
                {
                    db.Entry(s).State = EntityState.Detached;
                }

                if (result.Id == id)
                {

                    db.Entry(permission).State = EntityState.Modified;

                    db.SaveChanges();

                    flag = true;
                }
            }

            return flag;
        }


        public bool DeletePermission(long id)
        {
            bool flag = false;

            using (var db = new TimeTrackerModelContainer())
            {
                var deletePermission = db.Permission.First(x => x.Id == id);
                db.Permission.Remove(deletePermission);

                db.SaveChanges();
                flag = true;
            }

            return flag;
        }

        public Permission GetPermissionById(long id)
        {
            Permission permission;

            using (var db = new TimeTrackerModelContainer())
            {
                permission = db.Permission.First(x => x.Id == id);
            }

            return permission;
        }
    }
}