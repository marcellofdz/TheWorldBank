﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CoreBank
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class WorldBankEntities : DbContext
    {
        public WorldBankEntities()
            : base("name=WorldBankEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Banco> Bancos { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Cuenta> Cuentas { get; set; }
        public virtual DbSet<Empleado> Empleados { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<TipoCuenta> TipoCuentas { get; set; }
        public virtual DbSet<TipoMoneda> TipoMonedas { get; set; }
        public virtual DbSet<TipoTransaccione> TipoTransacciones { get; set; }
        public virtual DbSet<Transaccione> Transacciones { get; set; }
    
        public virtual ObjectResult<sp_GetAccounts_Result> sp_GetAccounts(string cedula)
        {
            var cedulaParameter = cedula != null ?
                new ObjectParameter("cedula", cedula) :
                new ObjectParameter("cedula", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_GetAccounts_Result>("sp_GetAccounts", cedulaParameter);
        }
    
        public virtual ObjectResult<sp_GetClient_Result> sp_GetClient(string username, string password)
        {
            var usernameParameter = username != null ?
                new ObjectParameter("username", username) :
                new ObjectParameter("username", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("password", password) :
                new ObjectParameter("password", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_GetClient_Result>("sp_GetClient", usernameParameter, passwordParameter);
        }
    
        public virtual ObjectResult<sp_GetEmployee_Result> sp_GetEmployee(string username, string password)
        {
            var usernameParameter = username != null ?
                new ObjectParameter("username", username) :
                new ObjectParameter("username", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("password", password) :
                new ObjectParameter("password", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_GetEmployee_Result>("sp_GetEmployee", usernameParameter, passwordParameter);
        }
    
        public virtual int sp_InsertTransaction(Nullable<int> clienteid, Nullable<int> cuentaid, Nullable<int> tusuariocuenta, string tusuariocedula, string notas, Nullable<int> tipotransacid, Nullable<int> tusuariobancoid, Nullable<int> tipomonedaid, Nullable<double> debito, Nullable<double> credito, Nullable<System.DateTime> fechacreacion, Nullable<System.DateTime> fechaaprobacion, string noaprobacion, Nullable<int> transaccioncompletada)
        {
            var clienteidParameter = clienteid.HasValue ?
                new ObjectParameter("clienteid", clienteid) :
                new ObjectParameter("clienteid", typeof(int));
    
            var cuentaidParameter = cuentaid.HasValue ?
                new ObjectParameter("cuentaid", cuentaid) :
                new ObjectParameter("cuentaid", typeof(int));
    
            var tusuariocuentaParameter = tusuariocuenta.HasValue ?
                new ObjectParameter("tusuariocuenta", tusuariocuenta) :
                new ObjectParameter("tusuariocuenta", typeof(int));
    
            var tusuariocedulaParameter = tusuariocedula != null ?
                new ObjectParameter("tusuariocedula", tusuariocedula) :
                new ObjectParameter("tusuariocedula", typeof(string));
    
            var notasParameter = notas != null ?
                new ObjectParameter("notas", notas) :
                new ObjectParameter("notas", typeof(string));
    
            var tipotransacidParameter = tipotransacid.HasValue ?
                new ObjectParameter("tipotransacid", tipotransacid) :
                new ObjectParameter("tipotransacid", typeof(int));
    
            var tusuariobancoidParameter = tusuariobancoid.HasValue ?
                new ObjectParameter("tusuariobancoid", tusuariobancoid) :
                new ObjectParameter("tusuariobancoid", typeof(int));
    
            var tipomonedaidParameter = tipomonedaid.HasValue ?
                new ObjectParameter("tipomonedaid", tipomonedaid) :
                new ObjectParameter("tipomonedaid", typeof(int));
    
            var debitoParameter = debito.HasValue ?
                new ObjectParameter("debito", debito) :
                new ObjectParameter("debito", typeof(double));
    
            var creditoParameter = credito.HasValue ?
                new ObjectParameter("credito", credito) :
                new ObjectParameter("credito", typeof(double));
    
            var fechacreacionParameter = fechacreacion.HasValue ?
                new ObjectParameter("fechacreacion", fechacreacion) :
                new ObjectParameter("fechacreacion", typeof(System.DateTime));
    
            var fechaaprobacionParameter = fechaaprobacion.HasValue ?
                new ObjectParameter("fechaaprobacion", fechaaprobacion) :
                new ObjectParameter("fechaaprobacion", typeof(System.DateTime));
    
            var noaprobacionParameter = noaprobacion != null ?
                new ObjectParameter("noaprobacion", noaprobacion) :
                new ObjectParameter("noaprobacion", typeof(string));
    
            var transaccioncompletadaParameter = transaccioncompletada.HasValue ?
                new ObjectParameter("transaccioncompletada", transaccioncompletada) :
                new ObjectParameter("transaccioncompletada", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_InsertTransaction", clienteidParameter, cuentaidParameter, tusuariocuentaParameter, tusuariocedulaParameter, notasParameter, tipotransacidParameter, tusuariobancoidParameter, tipomonedaidParameter, debitoParameter, creditoParameter, fechacreacionParameter, fechaaprobacionParameter, noaprobacionParameter, transaccioncompletadaParameter);
        }
    
        public virtual int sp_UpsertAccount(Nullable<int> cuentaid, Nullable<int> clienteid, Nullable<double> balance, Nullable<int> tipocuentaid, Nullable<int> enabled)
        {
            var cuentaidParameter = cuentaid.HasValue ?
                new ObjectParameter("cuentaid", cuentaid) :
                new ObjectParameter("cuentaid", typeof(int));
    
            var clienteidParameter = clienteid.HasValue ?
                new ObjectParameter("clienteid", clienteid) :
                new ObjectParameter("clienteid", typeof(int));
    
            var balanceParameter = balance.HasValue ?
                new ObjectParameter("balance", balance) :
                new ObjectParameter("balance", typeof(double));
    
            var tipocuentaidParameter = tipocuentaid.HasValue ?
                new ObjectParameter("tipocuentaid", tipocuentaid) :
                new ObjectParameter("tipocuentaid", typeof(int));
    
            var enabledParameter = enabled.HasValue ?
                new ObjectParameter("enabled", enabled) :
                new ObjectParameter("enabled", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_UpsertAccount", cuentaidParameter, clienteidParameter, balanceParameter, tipocuentaidParameter, enabledParameter);
        }
    
        public virtual int sp_UpsertClient(string cedula, string username, string password, string nombres, string apellidos, string sexo, Nullable<System.DateTime> fechanacimiento, string direccion, string telefono, Nullable<int> estado)
        {
            var cedulaParameter = cedula != null ?
                new ObjectParameter("cedula", cedula) :
                new ObjectParameter("cedula", typeof(string));
    
            var usernameParameter = username != null ?
                new ObjectParameter("username", username) :
                new ObjectParameter("username", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("password", password) :
                new ObjectParameter("password", typeof(string));
    
            var nombresParameter = nombres != null ?
                new ObjectParameter("nombres", nombres) :
                new ObjectParameter("nombres", typeof(string));
    
            var apellidosParameter = apellidos != null ?
                new ObjectParameter("apellidos", apellidos) :
                new ObjectParameter("apellidos", typeof(string));
    
            var sexoParameter = sexo != null ?
                new ObjectParameter("sexo", sexo) :
                new ObjectParameter("sexo", typeof(string));
    
            var fechanacimientoParameter = fechanacimiento.HasValue ?
                new ObjectParameter("fechanacimiento", fechanacimiento) :
                new ObjectParameter("fechanacimiento", typeof(System.DateTime));
    
            var direccionParameter = direccion != null ?
                new ObjectParameter("direccion", direccion) :
                new ObjectParameter("direccion", typeof(string));
    
            var telefonoParameter = telefono != null ?
                new ObjectParameter("telefono", telefono) :
                new ObjectParameter("telefono", typeof(string));
    
            var estadoParameter = estado.HasValue ?
                new ObjectParameter("Estado", estado) :
                new ObjectParameter("Estado", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_UpsertClient", cedulaParameter, usernameParameter, passwordParameter, nombresParameter, apellidosParameter, sexoParameter, fechanacimientoParameter, direccionParameter, telefonoParameter, estadoParameter);
        }
    
        public virtual int sp_UpsertEmployee(string cedula, string username, string password, Nullable<int> roleId, string nombres, string apellidos, string sexo, Nullable<System.DateTime> fechanacimiento, Nullable<int> estado)
        {
            var cedulaParameter = cedula != null ?
                new ObjectParameter("cedula", cedula) :
                new ObjectParameter("cedula", typeof(string));
    
            var usernameParameter = username != null ?
                new ObjectParameter("username", username) :
                new ObjectParameter("username", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("password", password) :
                new ObjectParameter("password", typeof(string));
    
            var roleIdParameter = roleId.HasValue ?
                new ObjectParameter("roleId", roleId) :
                new ObjectParameter("roleId", typeof(int));
    
            var nombresParameter = nombres != null ?
                new ObjectParameter("nombres", nombres) :
                new ObjectParameter("nombres", typeof(string));
    
            var apellidosParameter = apellidos != null ?
                new ObjectParameter("apellidos", apellidos) :
                new ObjectParameter("apellidos", typeof(string));
    
            var sexoParameter = sexo != null ?
                new ObjectParameter("sexo", sexo) :
                new ObjectParameter("sexo", typeof(string));
    
            var fechanacimientoParameter = fechanacimiento.HasValue ?
                new ObjectParameter("fechanacimiento", fechanacimiento) :
                new ObjectParameter("fechanacimiento", typeof(System.DateTime));
    
            var estadoParameter = estado.HasValue ?
                new ObjectParameter("Estado", estado) :
                new ObjectParameter("Estado", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_UpsertEmployee", cedulaParameter, usernameParameter, passwordParameter, roleIdParameter, nombresParameter, apellidosParameter, sexoParameter, fechanacimientoParameter, estadoParameter);
        }
    }
}