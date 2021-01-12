using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Management.Enums;

namespace Management.Models
{
    public class Alert
    {
        public int AlertId { get; set; }

        public AlertType AlertName { get; set; }
    }
}
