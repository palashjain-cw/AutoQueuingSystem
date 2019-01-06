using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    public interface IAutoBookInterface
    {
        List<BookingStatus> GetDriverBookingStatus(int driverId);
        bool BookRide(int userId);
        List<BookingStatus> GetAllBookingDetails();
        bool ConfirmRide(int requestId, int driverId);
    }
}
