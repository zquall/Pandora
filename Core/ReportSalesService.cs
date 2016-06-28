using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace Core
{
    public class ReportSalesService
    {
        public IEnumerable<GetSalesByEmployeeByDivision_Result> GetSalesByEmployeeByDivision (DateTime startDate, DateTime endDate)
        {
            List<GetSalesByEmployeeByDivision_Result> result;
            using (var pandoraEntities = new PandoraEntities())
            {
                result = pandoraEntities.GetSalesByEmployeeByDivision(startDate, endDate).ToList();
            }
            return result;
        }
        
    }
}
