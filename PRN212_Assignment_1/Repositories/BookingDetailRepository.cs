using Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class BookingDetailRepository
    {
        private FuminiHotelManagementContext _dbContext;

        public List<BookingDetail> GetAllBookingDetails()
        {
            _dbContext = new();
            return _dbContext.BookingDetails.ToList();
        }
    }
}
