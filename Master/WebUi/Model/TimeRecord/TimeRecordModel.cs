using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Server.Infrastructure.Dto;

namespace WebUi.Model.TimeRecord
{
    public class TimeRecordModel
    {
        [Required]
        public long TodoId { get; set; }

        public string TodoTitle { get; set; }

        [Required]
        public int TimeInSeconds { get; set; }

        [Required]
        public string Comment { get; set; }

        [Required]
        public long Id { get; set; }

        public List<TodoDto> TodoList { get; set; }

        public List<TimeRecordDto> TimeRecordList { get; set; } 
    }
}