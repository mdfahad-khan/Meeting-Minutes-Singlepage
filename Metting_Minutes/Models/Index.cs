using Metting_Minutes.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Metting_Minutes.Models
{
    public class Index: ValidationAttribute
    {
        [Required(ErrorMessage = "Customer Name is required")]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "Date is required")]
        [DataType(DataType.Date, ErrorMessage = "Please enter a valid date")]
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<System.TimeSpan> Time { get; set; }

        [Required(ErrorMessage = "Attends from client side is required")]
        public string AttendsFromClientSide { get; set; }

        [Required(ErrorMessage = "Attends from host side is required")]
        public string AttendsFromHostSide { get; set; }

        [Required(ErrorMessage = "Meeting Agenda is required")]
        public string MeettingAgenda { get; set; }

        [Required(ErrorMessage = "Meeting Discussion is required")]
        public string MeetingDisCussion { get; set; }

        [Required(ErrorMessage = "Meeting Decision is required")]
        public string MettingDecision { get; set; }

        [Required(ErrorMessage = "Meeting Place is required")]
        public string MeetingPlace { get; set; }

        [Required(ErrorMessage = "Product Name is required")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Unit is required")]
        public string Unit { get; set; }

        [Required(ErrorMessage = "Quantity is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than 0")]
        public Nullable<int> Quantity { get; set; }
    }
}