using Repositories.Entities;

namespace Repositories
{
    public class BookingDetailRepository
    {
        private FuminiHotelManagementContext? _dbContext;

        private static BookingDetailRepository? _instance;
        private BookingDetailRepository()
        {
        }
        public static BookingDetailRepository GetInstance()
        {
            if (BookingDetailRepository._instance == null)
            {
                _instance = new BookingDetailRepository();
            }
            return BookingDetailRepository._instance;
        }

        public List<BookingDetail> GetAllBookingDetails()
        {
            _dbContext = new();
            return _dbContext.BookingDetails.ToList();
        }

        public List<BookingDetail>? GetBookingDetail(int bookingReservationId)
        {
            _dbContext = new();
            return _dbContext.BookingDetails.Where(bd => bd.BookingReservationId == bookingReservationId).ToList();
        }
    }
}
