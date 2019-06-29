using System;
using System.Data;

namespace Belfer.Ustawienia.Model
{
    public class Exclusion
    {
        public int AllocationID { get; set; }
        public int PrivilegeID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Signature Creator { get; set; }

        internal static Exclusion CreateExclusion(IDataReader R)
        {
            DateTime.TryParse(R["StartDate"].ToString(), out DateTime startDate);
            DateTime.TryParse(R["EndDate"].ToString(), out DateTime endDate);
            return new Exclusion()
            {
                AllocationID = Convert.ToInt32(R["IdPrzydzial"]),
                PrivilegeID = Convert.ToInt32(R["IdPrzywilej"]),
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
