using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Belfer.Ustawienia.Model
{
    public class SubjectModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public string Type { get; set; }
        public int Priority { get; set; }
        public Signature Creator { get; set; }

        public static SubjectModel Create(IDataReader R)
        {
            return new SubjectModel()
            {
                ID = Convert.ToInt32(R["ID"]),
                Name = R["Nazwa"].ToString(),
                Alias = R["Alias"].ToString(),
                Type = R["Typ"].ToString(),
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
        public override string ToString()
        {
            return Alias;
        }
    }
}
