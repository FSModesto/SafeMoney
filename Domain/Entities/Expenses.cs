﻿using Domain.Enums;

namespace Domain.Entities
{
    public class Expenses
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
        public DateTime Date { get; set; }
        public virtual Categorys Categorys { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}