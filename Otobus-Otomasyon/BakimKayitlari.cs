//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Otobus_Otomasyon
{
    using System;
    using System.Collections.Generic;
    
    public partial class BakimKayitlari
    {
        public int BakimId { get; set; }
        public Nullable<int> AracId { get; set; }
        public Nullable<System.DateTime> BakimTarihi { get; set; }
        public string BakimTipi { get; set; }
        public string Aciklama { get; set; }
        public Nullable<decimal> BakimMaliyeti { get; set; }
        public string ServisMerkezi { get; set; }
        public string SorumuKisi { get; set; }
        public string Durum { get; set; }
    
        public virtual Araclar Araclar { get; set; }
    }
}
