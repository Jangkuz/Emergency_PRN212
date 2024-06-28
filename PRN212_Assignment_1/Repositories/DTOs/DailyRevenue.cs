using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.DTOs
{
    public class DailyRevenue
    {
            public DateOnly Date { get; set; }
            public decimal TotalRevenue { get; set; }
    }
}
