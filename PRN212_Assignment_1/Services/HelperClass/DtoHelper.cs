using Repositories.DTOs;
using Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Services.HelperClass
{
    public static class DtoHelper
    {
        public static BookingReservationDTOs ToBookingReservationDto(this BookingReservation bookingReservation)
        {
            return new BookingReservationDTOs()
            {
                BookingReservationId = bookingReservation.BookingReservationId,
                BookingStatus = bookingReservation.BookingStatus,
                BookingDate = bookingReservation.BookingDate,
                CustomerId = bookingReservation.CustomerId,
                TotalPrice = bookingReservation.TotalPrice,
            };
        }

    }
}
    