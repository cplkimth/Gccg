﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Chinook.Data
{
    public partial class Company
    {
        public Company()
        {
            Artists = new HashSet<Artist>();
        }

        public int CompanyId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Artist> Artists { get; set; }
    }
}