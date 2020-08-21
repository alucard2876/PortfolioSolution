using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PortfolioSolution.Buisness.ViewModels
{
    public class UserViewModel
    {
        public Guid Id { get; set; }
        [Required()]
        [DisplayName("User name")]
        public string UserName { get; set; }
        [Required()]
        [DisplayName("password")]
        public string Password { get; set; }
        [Required()]
        [DisplayName("Confirm password")]
        [Compare(nameof(Password))]
       
        public string ConfirmPassword { get; set; }
        [Required()]
        [DisplayName("Email")]
        [EmailAddress()]
        public string Email { get; set; }

        public IEnumerable<ToDoViewModel> Items { get; set; }

    }
}
