using Microsoft.Data.SqlClient;
using Repositories;
using Repositories.Entities;

namespace Services
{
    public class RoomInformationServices
    {
        private RoomInformationRepository _repo;

        public RoomInformationServices()
        {
            _repo = RoomInformationRepository.GetInstance();
        }

        public List<RoomInformation> GetAllRoomInformationToUI()
        {
            return _repo.GetAllRoomInformations();
        }

        public string SetRoomStatusAsDeleteFromUI(RoomInformation room)
        {
            string result = "Error happened";
            var roomModel = _repo.SetRoomStatusAsDelete(room.RoomId);
            //TODO: try catch SQL exception
            if (roomModel != null)
            {
                result = "Set status delete succesful!";
            }
            return result;
        }
        public string UpdateRoomFromUI(RoomInformation room)
        {
            string result = string.Empty;
            //var roomModel = _repo.
            return result;
        }

        public string CreateRoomFromUI(RoomInformation roomModel)
        {
            string message = "Create not success!";
            try
            {
                var createdRoom = _repo.CreateRoom(roomModel);
                if (createdRoom != null)
                {
                    message = "Create room successed!";
                }

            }
            catch (SqlException ex)
            {
                Console.WriteLine("RoomInformationServices_CreateRoomFromUI: " + ex.Message);
                message += " An error have occured!";
            }

            return message;
        }

        public string UpdateFromUI(RoomInformation roomModel)
        {
            string message = "Update not success!";
            try
            {
                var createdRoom = _repo.UpdateRoom(roomModel);
                if (createdRoom != null)
                {
                    message = "Update room successed!";
                }

            }
            catch (SqlException ex)
            {
                Console.WriteLine("RoomInformationServices_UpdateFromUI: " + ex.Message);
                message += " An error have occured!";
            }

            return message;
        }
    }
}
