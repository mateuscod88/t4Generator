using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class SprawaNotatka
    {
        public string Id { get; set; }
        public string IdSprawa { get; set; }
        public TypNotatki Typ { get; set; }
        public string IdPodmiotWlascicielBiznesowy { get; set; }
        public DateTime DataUtworzenia { get; set; }
        public bool CzyUsuniety { get; set; }
        public DateTime DataUsuniecia { get; set; }
        public string IdUzytkownikUsuwajacy { get; set; }
    }
}
/*
 Pobierz SprawaNotatka 
     foreach po propertiesach
     W zaleznosci od typow wygeneruj wiersz

     */