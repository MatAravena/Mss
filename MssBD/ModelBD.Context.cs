﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class MSS_BDEntities : DbContext
    {
        public MSS_BDEntities()
            : base("name=MSS_BDEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Afp> Afp { get; set; }
        public virtual DbSet<Bancos> Bancos { get; set; }
        public virtual DbSet<CentrosDeCostos> CentrosDeCostos { get; set; }
        public virtual DbSet<Comunas> Comunas { get; set; }
        public virtual DbSet<Contratos> Contratos { get; set; }
        public virtual DbSet<Documentos> Documentos { get; set; }
        public virtual DbSet<EstructuraSueldos> EstructuraSueldos { get; set; }
        public virtual DbSet<Finiquito> Finiquito { get; set; }
        public virtual DbSet<Isapres> Isapres { get; set; }
        public virtual DbSet<Log> Log { get; set; }
        public virtual DbSet<Paises> Paises { get; set; }
        public virtual DbSet<Personal> Personal { get; set; }
        public virtual DbSet<Privilegios> Privilegios { get; set; }
        public virtual DbSet<Provincias> Provincias { get; set; }
        public virtual DbSet<Regiones> Regiones { get; set; }
        public virtual DbSet<Remuneraciones> Remuneraciones { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
        public virtual DbSet<VW_DOC_Anexos> VW_DOC_Anexos { get; set; }
        public virtual DbSet<VW_DOC_Contratos> VW_DOC_Contratos { get; set; }
        public virtual DbSet<VW_DOC_Finiquitos> VW_DOC_Finiquitos { get; set; }
        public virtual DbSet<VW_Documentos_Visar> VW_Documentos_Visar { get; set; }
        public virtual DbSet<Vw_EmpleadosTodos> Vw_EmpleadosTodos { get; set; }
        public virtual DbSet<VW_Logs> VW_Logs { get; set; }
        public virtual DbSet<Log_Documentos> Log_Documentos { get; set; }
        public virtual DbSet<DocumentoTipo> DocumentoTipo { get; set; }
        public virtual DbSet<VW_DOC_Historial> VW_DOC_Historial { get; set; }
        public virtual DbSet<Anexos> Anexos { get; set; }
    
        public virtual ObjectResult<CON_Empleados_Rut_Centro_Result> CON_Empleados_Rut_Centro(string rut, string centroCosto, string apellidoPaterno, string apellidoMaterno)
        {
            var rutParameter = rut != null ?
                new ObjectParameter("Rut", rut) :
                new ObjectParameter("Rut", typeof(string));
    
            var centroCostoParameter = centroCosto != null ?
                new ObjectParameter("CentroCosto", centroCosto) :
                new ObjectParameter("CentroCosto", typeof(string));
    
            var apellidoPaternoParameter = apellidoPaterno != null ?
                new ObjectParameter("ApellidoPaterno", apellidoPaterno) :
                new ObjectParameter("ApellidoPaterno", typeof(string));
    
            var apellidoMaternoParameter = apellidoMaterno != null ?
                new ObjectParameter("ApellidoMaterno", apellidoMaterno) :
                new ObjectParameter("ApellidoMaterno", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CON_Empleados_Rut_Centro_Result>("CON_Empleados_Rut_Centro", rutParameter, centroCostoParameter, apellidoPaternoParameter, apellidoMaternoParameter);
        }
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int SP_CON_Documentos(Nullable<bool> vigencia)
        {
            var vigenciaParameter = vigencia.HasValue ?
                new ObjectParameter("Vigencia", vigencia) :
                new ObjectParameter("Vigencia", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_CON_Documentos", vigenciaParameter);
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagramdefinition_Result> sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagramdefinition_Result>("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagrams_Result> sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagrams_Result>("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    }
}
