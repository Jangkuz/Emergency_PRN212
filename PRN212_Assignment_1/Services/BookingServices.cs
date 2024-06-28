using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.DTOs;
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

        public List<BookingReservation>? GetReservationBasedOnCustomer(Customer cus)
        {
            return _bookingReservationRepo.GetCustomerReservation(cus);
        }

        public string BookRoomFromUI(Customer curCus, List<RoomInformation> roomsInfos, DateOnly startDate, DateOnly endDate)
        {
            string message = "Booking unsuccessful";
            //1. make BookingReservation
            //List<int> dummyRoomIds = new() { 6900, 5900 };
            //var dummyStartDate = DateOnly.FromDateTime(DateTime.Now);
            //var dummyEndDate = DateOnly.FromDateTime(DateTime.Now);
            try
            {
                //var dummyCustomer = new Customer();
                var bookingReservation = new BookingReservation()
                {
                    //set attribute of dummyBookingReservation
                    BookingDate = DateOnly.FromDateTime(DateTime.Now),
                    CustomerId = curCus.CustomerId,
                    BookingStatus = 1,
                };
                _bookingReservationRepo.AddBookingReservation(bookingReservation);

                //2. make BookingDetail
                var dummyBookingDetails = roomsInfos.Select(room => new BookingDetail()
                {
                    RoomId = room.RoomId,
                    StartDate = startDate,
                    EndDate = endDate,
                    ActualPrice = room.RoomPricePerDay,
                }).ToList();

                bookingReservation.BookingDetails = dummyBookingDetails;

                //3. update BookingReservation.TotalPrice.
                bookingReservation.TotalPrice = bookingReservation.BookingDetails.Sum(d => d.ActualPrice * (d.EndDate.DayNumber - d.StartDate.DayNumber));
                _bookingReservationRepo.UpdateBookingReservation(bookingReservation);

                message = "Booking successful!";
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("BookingServices_BookRoomFromUI_NullReferenceException" + ex.Message);
                message += "\nBookingServices_BookRoomFromUI_NullReferenceException" + ex.Message;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("BookingServices_BookRoomFromUI_SqlException" + ex.Message);
                message += "\nBookingServices_BookRoomFromUI_SqlException" + ex.Message;
            }
            catch(Exception ex)
            {
                Console.WriteLine("BookingServices_BookRoomFromUI_GeneralException"+ex.Message);
                message += "\nBookingServices_BookRoomFromUI_GeneralException" + ex.Message;
            }
            return message;
        }

        public  IQueryable<DailyRevenue> GetDailyRevenue()
        {
            var dailyRevenue = _bookingDetailRepo.GetAllBookingDetails()
                .GroupBy(br => br.StartDate)
                .Select(g => new DailyRevenue
                {
                    Date = g.Key,
                    TotalRevenue = g.Sum(br => br.ActualPrice ?? 0)
                })
                .OrderByDescending(dr => dr.TotalRevenue)
                .ToList();

            return dailyRevenue.AsQueryable();
        }
    }
}
