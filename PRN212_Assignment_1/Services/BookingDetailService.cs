using Repositories;
using Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class BookingDetailService
    {
        private BookingDetailRepository _repo = new();

        public List<BookingDetail> GetBookingDetails()
        {
            return _repo.GetAllBookingDetails();
        }
    }
}
