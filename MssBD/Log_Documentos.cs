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
    
    public partial class Log_Documentos
    {
        public int LogDoc_Id { get; set; }
        public string Accion { get; set; }
        public Nullable<System.DateTime> fecha { get; set; }
        public Nullable<int> DocTipo_Id { get; set; }
        public Nullable<int> Documento_Id { get; set; }
    
        public virtual Documentos Documentos { get; set; }
    }
}