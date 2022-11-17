﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVCDemo.Models
{
    public class Expense
    {
        public int Id { get; set; }

        [DisplayName("Expense")]
        [Required]
        public string Name { get; set; }

        [Required]
        [Range(1,int.MaxValue, ErrorMessage="Amount must be greater than 0!")]
        public int Amount { get; set; }
      
        [DisplayName("Expense Type")]
        public int ExpenseTypeId { get; set; }

        [ForeignKey("ExpenseTypeId")]
        public virtual ExpenseType ExpenseType { get; set; }
    }
}