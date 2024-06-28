using PE_PRN212_SU24TrialTest_DoLongAnh.Repo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE_PRN212_SU24TrialTest_DoLongAnh.Repo
{
    public class SupplierCompanyRepository
    {
        private AirConditionerShop2024DbContext _dbContext;
        public SupplierCompany? GetSupplierCompanyById(string SupplierCompanyId)
        {
            _dbContext = new();
            SupplierCompany? result = null;

            result = _dbContext.SupplierCompanies.FirstOrDefault(s => s.SupplierId.ToLower().Equals(SupplierCompanyId.ToLower()));

            return result;
        }

        public List<SupplierCompany> GetAllSuppliers()
        {
            _dbContext = new();

            List<SupplierCompany> result;
            result = _dbContext.SupplierCompanies.ToList();

            return result;
        }
    }
}
