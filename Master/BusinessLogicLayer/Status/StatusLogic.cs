using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Server.Infrastructure.Dto;
using Server.Infrastructure.Dto.Requests.Status;
using Server.Infrastructure.Enums;

namespace BusinessLogicLayer.Status
{
    using DataAccessLayer;

    public class StatusLogic
    {
        public Status GetStatus(States status)
        {
            using (var db = new TimeTrackerModelContainer())
            {
                return db.Status.First(x => x.Name.Equals(status.ToString()));
            }
        }

        public List<StatusDto> GetAllStatus()
        {
            List<StatusDto> statusList = new List<StatusDto>();

            using (var db = new TimeTrackerModelContainer())
            {
                var list = db.Status.AsEnumerable().ToList();

                foreach (var tempList in list)
                {
                    statusList.Add(new StatusDto
                    {
                        Name = tempList.Name,
                        StateTypeId = tempList.StateTypeId,
                        Id = tempList.Id
                           
                    });
                }
            }

            return statusList;
        }

        public Status AddStatus(StatusRequest request)
        {
            Status newStatus = new Status
            {
                Name = request.Name,
                StateTypeId = (StateEnum) request.status
            };

            using (var db = new TimeTrackerModelContainer())
            {
                db.Status.Add(newStatus);
                db.SaveChanges();
            }

            return newStatus;
        }

        public Status EditStatus(StatusRequest request)
        {
            Status newStatus = new Status();
            
            using (var db = new TimeTrackerModelContainer())
            {
                var result = db.Status.First(x => x.Id == request.Id);
                newStatus.Id = request.Id;
                newStatus.Name = request.Name;
                newStatus.StateTypeId = request.status;

                var s = db.Set<Status>().Local.FirstOrDefault(x => x.Id == request.Id);

                if (s != null)
                {
                    db.Entry(s).State = EntityState.Detached;
                }

                if (result.Id == request.Id)
                {

                    db.Entry(newStatus).State = EntityState.Modified;

                    db.SaveChanges();
                }
            }

            return newStatus;
        }

        public Status GetStatusById(long id)
        {
            Status status;

            using (var db = new TimeTrackerModelContainer())
            {
                status = db.Status.First(x => x.Id == id);
            }

            return status;
        }

        public bool DeleteStatus(long id)
        {
            bool flag = false;
           
            using (var db = new TimeTrackerModelContainer())
            {
                var result = db.Status.First(x => x.Id == id);
                db.Status.Remove(result);
                db.SaveChanges();

                flag = true;
            }

            return flag;
        }

    }
}
