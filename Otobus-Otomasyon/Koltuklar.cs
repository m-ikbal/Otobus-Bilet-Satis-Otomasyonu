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
    
    public partial class Koltuklar
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Koltuklar()
        {
            this.Biletler = new HashSet<Biletler>();
        }
    
        public int koltukId { get; set; }
        public Nullable<int> koltukNo { get; set; }
        public string koltukDurum { get; set; }
        public Nullable<int> aracId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Biletler> Biletler { get; set; }
        public virtual Araclar Araclar { get; set; }
    }
}