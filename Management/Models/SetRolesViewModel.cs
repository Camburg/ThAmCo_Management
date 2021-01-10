using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Management.Models
{
    public class SetRolesViewModel
    {
        public string Name { get; set; }

        public string Username { get; set; }

        public string HighestRole { get; set; }

        public SelectList Roles { get; set; }

        public int RoleId { get; set; }
    }
}
