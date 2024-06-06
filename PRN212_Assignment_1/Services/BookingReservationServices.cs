using Repositories;
using Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class BookingReservationServices
    {
        private BookingReservationRepository _repo = new();
        public List<BookingReservation> GetBookingReservations()
        {
            return _repo.GetAllBookingReservations();
        }
    }
}
