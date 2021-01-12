using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Management.Dto;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Management.Models
{
    public class IndexViewModel
    {
        public List<SystemLogDto> Logs { get; set; }

        public SelectList Roles { get; set; }

        [Display(Name = "Role")]
        public int RoleId { get; set; }

        public SelectList Components { get; set; }

        [Display(Name = "Component")]
        public int ComponentId { get; set; }

        public SelectList AlertTypes { get; set; }

        [Display(Name = "Alert Type")]
        public int AlertId { get; set; }

        public DateTime Date { get; set; }


    }
}
