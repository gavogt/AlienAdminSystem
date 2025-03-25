﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlienAdminSystem
{
    public class AlienGroup
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; } = String.Empty;
    }
}
