using DataAccessLayer;
using Server.Infrastructure.Dto;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebUi.Model.Status
{
    public class Status
    {
        public long Id { get; set; }    

        [Required]
        public string Name { get; set; }

        public StateEnum State { get; set; }

        public List<StatusDto> StatusList{ get; set; }

    }
}