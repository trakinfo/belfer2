using Belfer.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Belfer.Administrator.Model
{
    public class AppUser : User
    {

        [JsonProperty(Required = Required.AllowNull)]
        public UserSettings Settings { get; set; }
        public IEnumerable<UserSchoolToken> SchoolTokenList { get; set; }
        public IEnumerable<Privilege> PrivilageSet { get; set; }
        public IEnumerable<Exclusion> ExclusionSet { get; set; }

        public class UserSettings
        {
            public static event EventHandler RaiseConfigChanged;

            int year = CalcHelper.StartDateOfSchoolYear().Year;
            int schoolId;
            bool landscape;
            int leftMargin = 39, topMargin = 39;
            Font textFont = new Font("Times New Roman", 9.75f), headerFont = new Font("Arial", 12, FontStyle.Bold), subheaderFont = new Font("Arial", 11.25f, FontStyle.Bold);
            float absenceLevel = 50F, avg = 1.5F;
            byte scoreCount = 0;
            float xcaliber = -3.937f, ycaliber = -7.9f;

            [JsonProperty(Required = Required.AllowNull)]
            public int SchoolID { get => schoolId; set { schoolId = value; IsDirty = true; } }
            [JsonProperty(Required = Required.AllowNull)]
            public int Year { get => year; set { year = value; IsDirty = true; } }
            [JsonProperty(Required = Required.AllowNull)]
            public bool Landscape { get => landscape; set { landscape = value; IsDirty = true; } }
            [JsonProperty(Required = Required.AllowNull)]
            public int LeftMargin { get => leftMargin; set { leftMargin = value; IsDirty = true; } }
            [JsonProperty(Required = Required.AllowNull)]
            public int TopMargin { get => topMargin; set { topMargin = value; IsDirty = true; } }
            [JsonProperty(Required = Required.AllowNull)]
            public Font TextFont { get => textFont; set { textFont = value; IsDirty = true; } }
            [JsonProperty(Required = Required.AllowNull)]
            public Font HeaderFont { get => headerFont; set { headerFont = value; IsDirty = true; } }
            [JsonProperty(Required = Required.AllowNull)]
            public Font SubHeaderFont { get => subheaderFont; set { subheaderFont = value; IsDirty = true; } }
            [JsonProperty(Required = Required.AllowNull)]
            public float AbsenceLevel { get => absenceLevel; set { absenceLevel = value; IsDirty = true; } }
            [JsonProperty(Required = Required.AllowNull)]
            public float Avg { get => avg; set { avg = value; IsDirty = true; } }
            [JsonProperty(Required = Required.AllowNull)]
            public byte ScoreCount { get => scoreCount; set { scoreCount = value; IsDirty = true; } }
            [JsonProperty(Required = Required.AllowNull)]
            public float XCaliber { get => xcaliber; set { xcaliber = value; IsDirty = true; } }
            [JsonProperty(Required = Required.AllowNull)]
            public float YCaliber { get => ycaliber; set { ycaliber = value; IsDirty = true; } }


            [JsonIgnore]
            public string SchoolYear { get => CalcHelper.SchoolYear(year); }
            [JsonIgnore]
            public bool IsDirty { get; set; } = false;

            public void ConfigChanged()
            {
                RaiseConfigChanged?.Invoke(this, new EventArgs());
            }
        }
        public class UserSchoolToken
        {
            public int SchoolID { get; set; }
            public UserRole UserRole { get; set; }
            public int UserID { get; set; }
        }

    }
}
