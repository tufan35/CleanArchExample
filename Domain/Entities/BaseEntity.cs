﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{

    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string IdentityNumber { get; set; }
        public string Title { get; set; }
    }
}
