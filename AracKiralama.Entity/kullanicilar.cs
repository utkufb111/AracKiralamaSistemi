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
    
    public partial class kullanicilar
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public kullanicilar()
        {
            this.kiralikAraclars = new List<kiralikAraclar>();
        }
    
        public int kullaniciID { get; set; }
        public string ad { get; set; }
        public string soyad { get; set; }
        public string eposta { get; set; }
        public string sifre { get; set; }
        public string tel { get; set; }
        public Nullable<int> roleID { get; set; }
        public Nullable<int> adresID { get; set; }
    
        public virtual adre adre { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual List<kiralikAraclar> kiralikAraclars { get; set; }
        public virtual role role { get; set; }
    }
}
