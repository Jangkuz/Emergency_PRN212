using Repositories;
using Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class RoomInformationServices
    {
        private RoomInformationRepository _repo = new();

        public List<RoomInformation> GetRoomInformation()
        {
            return _repo.GetAllRoomInformations();
        }
    }
}
