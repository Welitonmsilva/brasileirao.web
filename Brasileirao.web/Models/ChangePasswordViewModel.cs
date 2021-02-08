using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Brasileirao.web.Models
{
    public class ChangePasswordViewModel
    {
        [Required]
        [Display(Name = "Current PasseWord")]
        public string OldPassword { get; set; }
        [Required]
        [Display(Name ="NewPasseWord")]
        public string NewPassword { get; set; }
        [Required]
        [Compare("NewPasseWord")]
        public string Confirm { get; set; }

    }
}
