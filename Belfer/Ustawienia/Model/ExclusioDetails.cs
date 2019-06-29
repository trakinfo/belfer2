using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Belfer.Ustawienia.Model
{
    public class ExclusionDetails : Exclusion
    {
        public string StudentName { get; set; }
        public string ClassName { get; set; }
        public string SubjectName { get; set; }

        public static ExclusionDetails CreateExclusionDetails(IDataReader R)
        {
            DateTime.TryParse(R["StartDate"].ToString(), out DateTime startDate);
            DateTime.TryParse(R["EndDate"].ToString(), out DateTime endDate);
            return new ExclusionDetails()
            {
                AllocationID = Convert.ToInt32(R["IdPrzydzial"]),
                PrivilegeID = Convert.ToInt32(R["IdPrzywilej"]),
                StudentName = R["Student"].ToString(),
                ClassName = R["NazwaKlasy"].ToString(),
                SubjectName = R["Alias"].ToString(),
                StartDate = startDate,
                EndDate = endDate,
                Creator = new Signature
                {
                    Owner = R["Owner"].ToString(),
                    User = R["User"].ToString(),
                    IP = R["ComputerIP"].ToString(),
                    Version = Convert.ToDateTime(R["Version"])
                }
            };
        }
    }
}
