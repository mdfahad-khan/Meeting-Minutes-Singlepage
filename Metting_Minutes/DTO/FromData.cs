using System;

using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Metting_Minutes.DTO
{
	public class FromData
	{
        public string CustomerName { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<System.TimeSpan> Time { get; set; }
        public string AttendsFromClientSide { get; set; }
        public byte[] AttendsFromHostSide { get; set; }
        public string MeettingAgenda { get; set; }
        public string MeetingDisCussion { get; set; }
        public string MettingDecision { get; set; }

        public string ProductName { get; set; }
        public string Unit { get; set; }
        public Nullable<int> Quantity { get; set; }
    }
}