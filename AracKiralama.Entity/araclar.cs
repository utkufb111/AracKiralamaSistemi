//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AracKiralama.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class araclar
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public araclar()
        {
            this.kiralikAraclars = new List<kiralikAraclar>();
        }
    
        public int aracID { get; set; }
        public string aracMarka { get; set; }
        public string aracModel { get; set; }
        public Nullable<int> gerekenEhliyetYasi { get; set; }
        public Nullable<int> gunlukSinirKm { get; set; }
        public Nullable<int> anlikKm { get; set; }
        public Nullable<bool> airbag { get; set; }
        public Nullable<int> bagajHacmi { get; set; }
        public Nullable<int> koltukSayisi { get; set; }
        public Nullable<int> aracSayisi { get; set; }
        public string renk { get; set; }
        public Nullable<decimal> fiyat { get; set; }
        public Nullable<bool> aracDurumu { get; set; }
        public Nullable<int> sirketID { get; set; }
        public string photo { get; set; }
    
        public virtual sirketler sirketler { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual List<kiralikAraclar> kiralikAraclars { get; set; }
    }
}
