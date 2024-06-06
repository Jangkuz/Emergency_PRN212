using Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class RoomTypeRepository
    {
        private FuminiHotelManagementContext _dbContext;

        public List<RoomType> GetAllRoomTypes()
        {
            _dbContext = new();
            return _dbContext.RoomTypes.ToList();
        }
    }
}
