using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Statehantering.Models.ViewModels
{
    public class StateCreateVM
    {
        [Required(ErrorMessage = "Enter a E-mail adress")]
        [EmailAddress(ErrorMessage = "Not a valid E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter a name")]
        public string CompanyName { get; set; }
    }
}
