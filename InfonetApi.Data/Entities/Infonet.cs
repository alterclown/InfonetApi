using System;
using System.Collections.Generic;

#nullable disable

namespace InfonetApi.Data.Entities
{
    public partial class Infonet
    {
        public int InformationId { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string LanguageSkills { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public byte[] ResumeUpload { get; set; }
    }
}
