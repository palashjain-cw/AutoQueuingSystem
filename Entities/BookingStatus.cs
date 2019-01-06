using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class BookingStatus
    {
        public int RequestId { get; set; }
        public int UserId { get; set; }
        public int Status { get; set; }
        public DateTime BookingTime { get; set; }
        public DateTime PickedUpTime { get; set; }
        public DateTime CompleteTime { get; set; }
        public int DriverId { get; set; }
    }
}
