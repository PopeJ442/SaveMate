﻿using SaveMate.Models.Enums;

namespace SaveMate.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public int CategoryId { get; set; }
        public decimal Amount { get; set; }
        public TransactionType Type { get; set; } 
        public string Description { get; set; } = string.Empty;
        public DateTime Date { get; set; }
    }
}
