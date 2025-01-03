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
    
    public partial class Biletler
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Biletler()
        {
            this.Rezervasyon = new HashSet<Rezervasyon>();
        }
    
        public int biletId { get; set; }
        public Nullable<System.DateTime> biletTarih { get; set; }
        public Nullable<int> koltukId { get; set; }
        public Nullable<int> seferId { get; set; }
        public Nullable<int> yolcuId { get; set; }
        public Nullable<int> kullaniciId { get; set; }
        public Nullable<int> aracId { get; set; }
        public string PnrNumarasi { get; set; }
        public Nullable<decimal> biletUcreti { get; set; }
        public string odemeYontemi { get; set; }
        public string BiletDurumu { get; set; }
    
        public virtual Araclar Araclar { get; set; }
        public virtual Koltuklar Koltuklar { get; set; }
        public virtual Kullanicilar Kullanicilar { get; set; }
        public virtual Yolcular Yolcular { get; set; }
        public virtual Seferler Seferler { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Rezervasyon> Rezervasyon { get; set; }
    }
}
