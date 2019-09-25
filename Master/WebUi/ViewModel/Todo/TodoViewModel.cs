using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DataAccessLayer;
using Server.Infrastructure.Dto;

namespace WebUi.ViewModel.Todo
{
    public class TodoViewModel
    {
        [Required]
        public long StatusId { get; set; }

        public string StatusName { get; set; }

        public StateEnum State { get; set; }

        public long Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public TodoDto Todo { get; set; }   

        public List<TodoDto> TodoList { get; set; }

        public List<StatusDto> StatusList { get; set; }

        public List<ProjectDto> ProjectList { get; set; }

        public long ProjectId { get; set; }      

        public long TimeInSeconds { get; set; }

        public string Comment { get; set; }
    }
}