using Repositories.Entities;

namespace Repositories
{
    public class RoomTypeRepository
    {
        private FuminiHotelManagementContext? _dbContext;

        private static RoomTypeRepository? _instance;
        private RoomTypeRepository()
        {
        }
        public static RoomTypeRepository GetInstance()
        {
            if (RoomTypeRepository._instance == null)
            {
                _instance = new RoomTypeRepository();
            }
            return RoomTypeRepository._instance;
        }

        public List<RoomType> GetAllRoomTypes()
        {
            _dbContext = new();
            return _dbContext.RoomTypes.ToList();
        }
    }
}
