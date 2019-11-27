using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class SprawaNotatkaWersja
    {
        public string IdSprawaNotatka { get; set; }
        public string IdUzytkownik { get; set; }
        public string Tresc { get; set; }
        public string IdPodmiotWlascicielBiznesowy { get; set; }
        public DateTime DataUtworzenia { get; set; }
        public bool CzyUsuniety { get; set; }
    }
}