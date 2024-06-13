using Repositories;
using Repositories.Entities;

namespace Services
{
    public class RoomTypeServices
    {
        private RoomTypeRepository _repo;

        public RoomTypeServices()
        {
            _repo = RoomTypeRepository.GetInstance();
        }
        public List<RoomType> GetRoomTypes()
        {
            return _repo.GetAllRoomTypes();
        }
    }
}
