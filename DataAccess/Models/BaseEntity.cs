﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class BaseEntity
    {
        public int ID { get; set; }
        public bool IsDeleted { get; set; }//Used For Soft Delete
    }
}
