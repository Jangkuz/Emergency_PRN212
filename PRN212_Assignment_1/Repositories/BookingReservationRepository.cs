using Repositories.Entities;

namespace Repositories
{
    public class BookingReservationRepository
    {
        private FuminiHotelManagementContext? _dbContext;

        private static BookingReservationRepository? _instance;
        private BookingReservationRepository()
        {
        }
        public static BookingReservationRepository GetInstance()
        {
            if (BookingReservationRepository._instance == null)
            {
                _instance = new BookingReservationRepository();
            }
            return BookingReservationRepository._instance;
        }

        public List<BookingReservation> GetAllBookingReservations()
        {
            _dbContext = new();
            return _dbContext.BookingReservations.ToList();
        }

        public BookingReservation? GetReservationById(int id)
        {
            _dbContext = new();
            return _dbContext.BookingReservations.FirstOrDefault(br => br.BookingReservationId == id);
        }

        public BookingReservation? AddBookingReservation(BookingReservation bookingReservation)
        {
            _dbContext = new();
            _dbContext.BookingReservations.Add(bookingReservation);
            _dbContext.SaveChanges();
            return GetReservationById(bookingReservation.BookingReservationId);
        }
    }
}
