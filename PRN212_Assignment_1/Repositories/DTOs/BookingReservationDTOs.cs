using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.DTOs
{
    public  class BookingReservationDTOs
    {
        public int BookingReservationId { get; set; }

        public DateOnly? BookingDate { get; set; }

        public decimal? TotalPrice { get; set; }

        public int CustomerId { get; set; }

        public byte? BookingStatus { get; set; }
    }
}
