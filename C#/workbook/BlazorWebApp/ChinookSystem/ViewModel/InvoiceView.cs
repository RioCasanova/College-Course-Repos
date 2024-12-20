﻿using System.ComponentModel.DataAnnotations;

namespace ChinookSystem.ViewModel
{
    public class InvoiceView
    {
        public int InvoiceNo { get; set; }
        public DateTime InvoiceDate { get; set; } = DateTime.Now;
        public decimal SubTotal { get; set; }
        public decimal Tax { get; set; }

        [Required]
        [StringLength(6, ErrorMessage = "Name is too long")]
        public string SalePerson { get; set; }

        public string PaymentType { get; set; } = "Unknown";
    }
}
