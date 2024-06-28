using PE_PRN212_SU24TrialTest_DoLongAnh.Repo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE_PRN212_SU24TrialTest_DoLongAnh.Repo
{
    public class StaffMemberRepository
    {
        private AirConditionerShop2024DbContext? _dbContext;
        public StaffMemberRepository()
        {
        }
        
        public List<StaffMember> GetAllStaffMember()
        {
            _dbContext = new();
            return _dbContext.StaffMembers.ToList();
        }

        public StaffMember? CheckLogin(string staffEmail, string password)
        {
            StaffMember? loginStaff;
            _dbContext = new();
            loginStaff = _dbContext.StaffMembers.FirstOrDefault(s => s.EmailAddress!.ToLower().Equals(staffEmail) 
                                                                      && s.Password.ToLower().Equals(password));
            return loginStaff;
        }

    }
}
