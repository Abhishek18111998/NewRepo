﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDonationManagementSystem.Model
{
    public class SchoolModel
    {
        [Key]
        public int RollId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string FoodType { get; set; }
        public string ContactNumber { get; set; }
    }
}
