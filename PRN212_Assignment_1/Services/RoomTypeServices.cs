using Repositories.Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class RoomTypeServices
    {
        private RoomTypeRepository _repo = new();

        public List<RoomType> GetRoomTypes()
        {
            return _repo.GetAllRoomTypes();
        }
    }
}
