using PE_PRN212_SU24TrialTest_DoLongAnh.Repo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE_PRN212_SU24TrialTest_DoLongAnh.Repo
{
    public class AirConditionerRepository
    {
        private AirConditionerShop2024DbContext _dbContext;
        public List<AirConditioner> GetAllAC()
        {
            _dbContext = new();
            return _dbContext.AirConditioners.ToList();
        }

        public AirConditioner? GetAcById(int id)
        {
            AirConditioner? result = null;

            try
            {
                _dbContext = new();
                result = _dbContext.AirConditioners.FirstOrDefault(ac => ac.AirConditionerId == id);
            }
            catch (Exception ex)
            {
                Console.WriteLine("AirConditionerRepository_GetAcById: " + ex.Message);
            }

            return result;
        }

        public List<AirConditioner> SearchByFeatureAndQuantity(string feature, int quantity)
        {
            List<AirConditioner> result = new();

            _dbContext = new();
            result = _dbContext.AirConditioners
                                .Where(ac => ac.FeatureFunction!.Contains(feature)
                                    && ac.Quantity>=quantity)
                                .ToList();
            return result;
        }

        public AirConditioner? AddAirConditioner(AirConditioner addedAirConditioner)
        {
            _dbContext = new();
            _dbContext.AirConditioners.Add(addedAirConditioner);
            _dbContext.SaveChanges();

            return GetAcById(addedAirConditioner.AirConditionerId);
        }

        public AirConditioner? UpdateAirConditioner(AirConditioner updatedAirConditioner)
        {
            _dbContext = new();
            _dbContext.AirConditioners.Update(updatedAirConditioner);
            _dbContext.SaveChanges();
            return GetAcById(updatedAirConditioner.AirConditionerId);
        }

        public void DeleteAirConditioner(AirConditioner airConditioner)
        {
            _dbContext = new();
            _dbContext.AirConditioners.Remove(airConditioner);
            _dbContext.SaveChanges();
        }
    }
}
