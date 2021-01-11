using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Management.Models
{
    public class SetRolesViewModel
    {
        public string Name { get; set; }

        public string Username { get; set; }

        [Display(Name = "Current Role")]
        public string HighestRole { get; set; }

        public SelectList Roles { get; set; }

        public int RoleId { get; set; }
    }
}
