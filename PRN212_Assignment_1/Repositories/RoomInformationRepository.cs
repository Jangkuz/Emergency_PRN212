using Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class RoomInformationRepository
    {
        private FuminiHotelManagementContext _dbContext;

        public List<RoomInformation> GetAllRoomInformations()
        {
            _dbContext = new();
            return _dbContext.RoomInformations.ToList();
        }
    }
}
