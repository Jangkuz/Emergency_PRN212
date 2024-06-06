using Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class BookingReservationRepository
    {
        private FuminiHotelManagementContext _dbContext;

        public List<BookingReservation> GetAllBookingReservations()
        {
            _dbContext = new();
            return _dbContext.BookingReservations.ToList();
        }
    }
}
