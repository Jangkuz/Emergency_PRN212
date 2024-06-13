using Repositories.Entities;

namespace Repositories
{
    public class RoomInformationRepository
    {
        private FuminiHotelManagementContext? _dbContext;

        private static RoomInformationRepository? _instance;
        private RoomInformationRepository()
        {
        }
        public static RoomInformationRepository GetInstance()
        {
            if (RoomInformationRepository._instance == null)
            {
                _instance = new RoomInformationRepository();
            }
            return RoomInformationRepository._instance;
        }

        public List<RoomInformation> GetAllRoomInformations()
        {
            _dbContext = new();
            return _dbContext.RoomInformations.ToList();
        }

        public RoomInformation? SetRoomStatusAsDelete(int roomId)
        {
            _dbContext = new();
            var roomModel = _dbContext.RoomInformations.FirstOrDefault(r => r.RoomId == roomId);
            if (roomModel != null)
            {
                roomModel!.RoomStatus = 2;
            }
            _dbContext.SaveChanges();

            return roomModel;
        }

        public RoomInformation? GetRoomById(int roomId)
        {
            _dbContext = new();
            return _dbContext?.RoomInformations.FirstOrDefault(r => r.RoomId == roomId);
        }


        public RoomInformation? CreateRoom(RoomInformation roomModel)
        {
            _dbContext = new();
            _dbContext.RoomInformations.Add(roomModel);
            _dbContext.SaveChanges();

            return GetRoomById(roomModel.RoomId);
        }

        public RoomInformation? UpdateRoom(RoomInformation roomModel)
        {
            _dbContext = new();
            _dbContext.RoomInformations.Update(roomModel);
            _dbContext.SaveChanges();
            return GetRoomById(roomModel.RoomId);
        }
    }
}
