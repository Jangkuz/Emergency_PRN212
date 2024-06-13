using Microsoft.Data.SqlClient;
using Repositories;
using Repositories.Entities;

namespace Services
{
    public class BookingServices
    {
        private BookingReservationRepository _bookingReservationRepo;
        private BookingDetailRepository _bookingDetailRepo;
        private RoomInformationRepository _roomInformationRepo;
        public BookingServices()
        {
            _bookingReservationRepo = BookingReservationRepository.GetInstance();
            _bookingDetailRepo = BookingDetailRepository.GetInstance();
            _roomInformationRepo = RoomInformationRepository.GetInstance();
        }

        public List<BookingReservation> GetBookingReservations()
        {
            return _bookingReservationRepo.GetAllBookingReservations();
        }

        public string BookRoomFromUI()
        {
            string message = "Booking unsuccessful";
            //1. make BookingReservation
            List<int> dummyRoomIds = new() { 6900, 5900 };
            var dummyStartDate = DateOnly.FromDateTime(DateTime.Now);
            var dummyEndDate = DateOnly.FromDateTime(DateTime.Now);
            try
            {
                var dummyCustomer = new Customer();
                var dummyBookingReservation = new BookingReservation()
                {
                    //set attribute of dummyBookingReservation
                    BookingDate = DateOnly.FromDateTime(DateTime.Now),
                    CustomerId = dummyCustomer.CustomerId,
                    BookingStatus = 1,
                };

                //2. make BookingDetail
                var dummyBookingDetails = dummyRoomIds.Select(roomId => new BookingDetail()
                {
                    RoomId = roomId,
                    StartDate = dummyStartDate,
                    EndDate = dummyEndDate,
                    ActualPrice = _roomInformationRepo.GetRoomById(roomId)!.RoomPricePerDay,
                }).ToList();

                dummyBookingReservation.BookingDetails = dummyBookingDetails;

                //3. update BookingReservation.TotalPrice.
                dummyBookingReservation.TotalPrice = dummyBookingReservation.BookingDetails.Sum(d => d.ActualPrice * (d.EndDate.DayNumber - d.StartDate.DayNumber));
                _bookingReservationRepo.AddBookingReservation(dummyBookingReservation);

                message = "Booking successful!";
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("BookingServices_BookRoomFromUI " + ex.Message);
            } catch(SqlException ex)
            {
                Console.WriteLine("BookingServices_BookRoomFromUI " + ex.Message);
            }
            return message;
        }
    }
}
