namespace ENTITY
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    using System.Data.Entity;


    [Table("PersonalEmpresa")]
    public partial class PersonalEmpresa
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idCodPer { get; set; }

        [StringLength(15)]
        public string CodPer { get; set; }

        [StringLength(2)]
        public string TipoCodPer { get; set; }

        [StringLength(80)]
        public string Detalle { get; set; }

        [StringLength(2)]
        public string Produccion { get; set; }

        [StringLength(20)]
        public string Apellido1 { get; set; }

        [StringLength(20)]
        public string Apellido2 { get; set; }

        [StringLength(20)]
        public string Nombre1 { get; set; }

        [StringLength(20)]
        public string Nombre2 { get; set; }

        [StringLength(2)]
        public string CategoriaTrabajador { get; set; }

        [StringLength(1)]
        public string TrabajadorPensionista { get; set; }

        [StringLength(1)]
        public string TipoPension { get; set; }

        [StringLength(11)]
        public string RucEmpresa { get; set; }

        [Column(TypeName = "date")]
        public DateTime? FechaNacimiento { get; set; }

        [StringLength(1)]
        public string Sexo { get; set; }

        [StringLength(12)]
        public string Telefono { get; set; }

        [StringLength(12)]
        public string Celular { get; set; }

        [StringLength(1)]
        public string RegimenLaboral { get; set; }

        [StringLength(2)]
        public string SituacionEPS { get; set; }

        [StringLength(2)]
        public string TipoTrabajador { get; set; }

        [Column(TypeName = "date")]
        public DateTime? FechaIngreso { get; set; }

        [Column(TypeName = "date")]
        public DateTime? FechaBaja { get; set; }

        [StringLength(1)]
        public string CodigoEPS { get; set; }

        [StringLength(1)]
        public string ESSALUDVida { get; set; }

        [StringLength(12)]
        public string CUSPP { get; set; }

        [StringLength(1)]
        public string SCTRSalud { get; set; }

        [StringLength(1)]
        public string SCTRPension { get; set; }

        [Column(TypeName = "date")]
        public DateTime? FechaInscripcion { get; set; }

        [StringLength(4)]
        public string Nacionalidad { get; set; }

        [StringLength(1)]
        public string Discapacidad { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(5)]
        public string DepositoBancoCuenta { get; set; }

        [StringLength(1)]
        public string DepositoTipoCuenta { get; set; }

        [StringLength(24)]
        public string DepositoCuenta { get; set; }

        [StringLength(1)]
        public string Periodicidad { get; set; }

        [StringLength(1)]
        public string TipoRemuneracion { get; set; }

        [StringLength(5)]
        public string DepositoBancoCTS { get; set; }

        [StringLength(24)]
        public string DepositoCTS { get; set; }

        [StringLength(1)]
        public string SujetoControl { get; set; }

        [StringLength(1)]
        public string Sindicalizado { get; set; }

        [StringLength(6)]
        public string MunicipalidadPartidaNac { get; set; }

        [StringLength(2)]
        public string NivelEducativo { get; set; }

        [StringLength(6)]
        public string Ocupacion { get; set; }

        [StringLength(2)]
        public string TipoContrato { get; set; }

        [StringLength(2)]
        public string EstadoCivil { get; set; }

        [StringLength(1)]
        public string EsDomiciliado { get; set; }

        [StringLength(11)]
        public string RUC { get; set; }

        [StringLength(2)]
        public string DomicilioTipoVia { get; set; }

        [StringLength(100)]
        public string DomicilioNombreVia { get; set; }

        [StringLength(10)]
        public string DomicilioNumeroVia { get; set; }

        [StringLength(10)]
        public string DomicilioInterior { get; set; }

        [StringLength(2)]
        public string DomicilioTipoZona { get; set; }

        [StringLength(20)]
        public string DomicilioNombreZona { get; set; }

        [StringLength(40)]
        public string DomicilioReferencia { get; set; }

        [StringLength(6)]
        public string DomicilioUbigeo { get; set; }

        [StringLength(1)]
        public string IngresoSalida { get; set; }

        [StringLength(5)]
        public string Ficha { get; set; }

        [StringLength(30)]
        public string CodigoLaboral { get; set; }

        public int? idGrupoTrabajo { get; set; }

        [StringLength(3)]
        public string GrupoTrabajo { get; set; }

        public int? idLaborRealizada { get; set; }

        [StringLength(3)]
        public string LaborRealizada { get; set; }

        [Column(TypeName = "money")]
        public decimal? Basico { get; set; }

        public int? idUbicacion { get; set; }

        [StringLength(3)]
        public string Ubicacion { get; set; }

        public int? idCosto { get; set; }

        [StringLength(5)]
        public string Costo { get; set; }

        public int? idCategoria { get; set; }

        [StringLength(2)]
        public string Categoria { get; set; }

        public bool? Actualizado { get; set; }

        public bool? Activo { get; set; }

        public bool? Vacaciones { get; set; }

        [Column(TypeName = "image")]
        public byte[] Foto { get; set; }

        [StringLength(1)]
        public string TipoContratoEmpresa { get; set; }

        [StringLength(1)]
        public string CondicionLaboralEmpresa { get; set; }

        [StringLength(3)]
        public string Contratista { get; set; }

        public bool? AsignacionFamiliar { get; set; }

        public bool? AsignacionEmpresarial { get; set; }

        [Column(TypeName = "money")]
        public decimal? AsignacionEmpresarialImporte { get; set; }

        public bool? IncAFP1023 { get; set; }

        [Column(TypeName = "money")]
        public decimal? IncAFP1023Importe { get; set; }

        public bool? IncAFP300 { get; set; }

        [Column(TypeName = "money")]
        public decimal? IncAFP300Importe { get; set; }

        public bool? Representacion { get; set; }

        [Column(TypeName = "money")]
        public decimal? RepresentacionImporte { get; set; }

        public bool? Movilidad { get; set; }

        [Column(TypeName = "money")]
        public decimal? MovilidadImporte { get; set; }

        public bool? VidaAccidente { get; set; }

        public bool? DescJudiciales { get; set; }

        public decimal? DescJudicialesPorc { get; set; }

        [Column(TypeName = "money")]
        public decimal? DescJudicialesImporte { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DescJudicialesFin { get; set; }

        public bool? DescRenta { get; set; }

        [Column(TypeName = "money")]
        public decimal? DescRentaImporte { get; set; }

        public bool? AporteEsSalud { get; set; }

        public decimal? AporteEsSaludPorc { get; set; }

        public bool? AporteSenati { get; set; }

        public decimal? AporteSenatiPorc { get; set; }

        public bool? ParametroTopeQuincena { get; set; }

        [Column(TypeName = "money")]
        public decimal? ParametroTopeQuincenaImporte { get; set; }

        public bool? ParametroVacaciones { get; set; }

        [Column(TypeName = "date")]
        public DateTime? FechaVacProgramadas { get; set; }

        public int? Vac_Anterior { get; set; }

        public int? Vac_Actual { get; set; }

        public int? Vac_Total { get; set; }

        public int? Vac_DiasLaborados { get; set; }

        public bool? Supervisor1Cta { get; set; }

        [StringLength(10)]
        public string Supervisor1CtaCodUsu { get; set; }

        public DateTime? Supervisor1CtaFechaMod { get; set; }

        public bool? Supervisor1CTS { get; set; }

        [StringLength(10)]
        public string Supervisor1CTSCodUsu { get; set; }

        public DateTime? Supervisor1CTSFechaMod { get; set; }

        public bool? Supervisor2Cta { get; set; }

        [StringLength(10)]
        public string Supervisor2CtaCodUsu { get; set; }

        public DateTime? Supervisor2CtaFechaMod { get; set; }

        public bool? Supervisor2CTS { get; set; }

        [StringLength(10)]
        public string Supervisor2CTSCodUsu { get; set; }

        public DateTime? Supervisor2CTSFechaMod { get; set; }

        [StringLength(1)]
        public string MotivoBloqueo { get; set; }

        public string Comentario { get; set; }

        [StringLength(10)]
        public string CodUsu { get; set; }

        public DateTime? FechaMod { get; set; }

        [Key]
        [Column(Order = 1)]
        public bool? flatGratificacionExtraordinaria { get; set; }

        [Column(TypeName = "money")]
        public decimal? montoGratificacionExtraordinaria { get; set; }

        [StringLength(3)]
        public string grupo2 { get; set; }

        [StringLength(3)]
        public string moneda { get; set; }

        [StringLength(3)]
        public string deposito { get; set; }

        [StringLength(2)]
        public string idSubGrupoTrabajo { get; set; }

        [StringLength(2)]
        public string RegimenPensionario { get; set; }

        [StringLength(2)]
        public string idTipoComision { get; set; }

        public List<vista_personalGeneral> ListaPersonal()
        {
            List<vista_personalGeneral> userx = new List<vista_personalGeneral>();
            try
            {
                using (var ctx = new PERSONALCONTEXT())
                {
                    userx = (ctx.vista_personalGeneral.OrderBy(x=>x.detalle)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return userx;
        }

        public List<vista_personalGeneral> ListaPersonalBySinFotoID(string codper)
        {
            List<vista_personalGeneral> userx = new List<vista_personalGeneral>();
            try
            {
                using (var ctx = new PERSONALCONTEXT())
                {
                    userx = (ctx.vista_personalGeneral.Where(x=>x.codper ==codper)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return userx;
        }

        public static vista_personalGeneralFoto ListaPersonalByID(string codper)
        {
            vista_personalGeneralFoto userx = new vista_personalGeneralFoto();
            try
            {
                using (var ctx = new PERSONALCONTEXT())
                {
                    userx = (ctx.vista_personalGeneralFoto.Where(x => x.codper == codper)).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return userx;
        }
    }
}
