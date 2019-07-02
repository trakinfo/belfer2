using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Belfer.Ustawienia.Model
{
    public class SubjectSchemeModel
    {
        public int ID { get; set; }
        public string ClassName { get; set; }
        public string SubjectName { get; set; }
        public YesNo Group { get; set; }
        public string SubjectCategory { get; set; }
        public YesNo ToAvg { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public float LessonCount { get; set; }
        public Signature Creator { get; set; }

        public static SubjectSchemeModel Create(IDataReader R)
        {
            return new SubjectSchemeModel
            {
                ID = Convert.ToInt32(R["ID"]),
                ClassName = R["NazwaKlasy"].ToString(),
                SubjectName = R["Nazwa"].ToString(),
                Group = (YesNo)Convert.ToInt64(R["Grupa"]),
                SubjectCategory = R["Kategoria"].ToString(),
                ToAvg = (YesNo)Convert.ToInt64(R["GetToAverage"]),
                StartDate = Convert.ToDateTime(R["DataAktywacji"]),
                EndDate = Convert.ToDateTime(R["DataDeaktywacji"]),
                LessonCount = Convert.ToSingle(R["LiczbaGodzin"]),
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
