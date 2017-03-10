//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MssBD
{
    using System;
    using System.Collections.Generic;
    
    public partial class EstructuraSueldos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EstructuraSueldos()
        {
            this.Contratos = new HashSet<Contratos>();
            this.Personal = new HashSet<Personal>();
        }
    
        public int EstructuraSueldo_Id { get; set; }
        public Nullable<int> Estructura_Codigo { get; set; }
        public string Descripcion { get; set; }
        public Nullable<double> SueldoBase { get; set; }
        public Nullable<double> Gratificacion { get; set; }
        public Nullable<double> BonoAsistencia { get; set; }
        public Nullable<double> BonoProduccion { get; set; }
        public Nullable<double> Colacion { get; set; }
        public Nullable<double> Movilizacion { get; set; }
        public Nullable<double> BonoTurno { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contratos> Contratos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Personal> Personal { get; set; }
    }
}
