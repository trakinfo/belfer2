using System;
using System.Data;

namespace Belfer.Ustawienia.Model
{
    public class SchoolSubjectModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Priority { get; set; }
        public Signature Creator { get; set; }

        internal static SchoolSubjectModel CreateSchoolSubject(IDataReader R)
        {
            return new SchoolSubjectModel
            {
                ID = Convert.ToInt32(R["ID"]),
                Name = R["Nazwa"].ToString(),
                Priority = Convert.ToInt32(R["Priorytet"]),
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
