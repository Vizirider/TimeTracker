using Server.Infrastructure.Dto;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BusinessLogicLayer.TimeRecord
{
    using DataAccessLayer;

    public class TimeRecordLogic
    {
        public TimeRecord AddTimeRecord(long id, string comment, int timeInSec, long todoId)
        {
            var timeRecord = new TimeRecord
            {
                Comment = comment,
                TimeInSeconds = timeInSec,
                TodoId = todoId
            };

            using (var db = new TimeTrackerModelContainer())
            {
                db.TimeRecord.Add(timeRecord);
                db.SaveChanges();
            }
            return timeRecord;
        }

        public List<TimeRecordDto> GetAllTimeRecords()
        {
            List<TimeRecordDto> listTimeRecords = new List<TimeRecordDto>();

            using (var db = new TimeTrackerModelContainer())
            {
                var resultList = db.TimeRecord.AsEnumerable().ToList();

                foreach (var tempList in resultList)
                {
                    listTimeRecords.Add(new TimeRecordDto
                    {
                        Id = tempList.Id,
                        TodoId = tempList.TodoId,
                        TodoTitle = tempList.Todo.Title,
                        TimeInSeconds = tempList.TimeInSeconds,
                        Comment = tempList.Comment
                    });
                }
            }

            return listTimeRecords;
        }

        public TimeRecord GetTimeRecordByTodoId(long id)
        {
            using (var db = new TimeTrackerModelContainer())
            {
                return db.TimeRecord.FirstOrDefault(x => x.TodoId == id);
            }
        }

        public bool EditTimeRecord(long id, string comment, int timeInSec, long todoId)
        {
            var timeRecord = new TimeRecord();
            
            using (var db = new TimeTrackerModelContainer())
            {
                timeRecord = db.TimeRecord.FirstOrDefault(x => x.Id == id);
                timeRecord.Comment = comment;
                timeRecord.TimeInSeconds = timeInSec;
                timeRecord.TodoId = todoId;

                db.Entry(timeRecord).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
        }

        public bool DeleteTimeRecord(long id)
        {
            using (var db = new TimeTrackerModelContainer())
            {
                var timeRecord = db.TimeRecord.FirstOrDefault(x => x.Id == id);
                db.TimeRecord.Remove(timeRecord);
                db.SaveChanges();

                return true;
            }
        }

        public TimeRecord GeTimeRecordById(long id)
        {
            var timeRecord = new TimeRecord();

            using (var db = new TimeTrackerModelContainer())
            {
                timeRecord = db.TimeRecord.FirstOrDefault(x => x.Id == id);
            }

            return timeRecord;
        }
    }
}