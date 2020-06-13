﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JobSearchApp.Models
{
    public class Technology
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] Picture { get; set; }
        public bool IsActive { get; set; }
    }
}
