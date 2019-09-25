using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Server.Infrastructure.Dto;

namespace WebUi.Model.Currency
{
    public class CurrencyModel
    {
        [Required]
        public string Code { get; set; }

        [Required]
        [Display(Name = "Is it default?")]
        public bool IsDefault { get; set; }

        [Required]
        [Display(Name = "Default price")]
        public string PriceToDefault { get; set; }

        [Required]
        public long Id { get; set; }

        public List<CurrencyDto> CurrencyList { get; set; }
    }
}