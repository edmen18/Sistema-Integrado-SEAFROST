using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
  public  class VISTA_TRABAJO
    {
        public string TR_CODIGO { get; set; }

        public int AE_COD { get; set; }
        public string AE_DESC { get; set; }
        public string TIPO { get; set; }
        public string COD { get; set; }

        public string EQ_CODIGO { get; set; }
        public string EQ_DESCRIPCION { get; set; }
        public string PL_CODIGO { get; set; }
        public string PL_DESCRIPCION { get; set; }
        public string CONTRATISTA { get; set; }
        public string COD_CONTRATISTA { get; set; }

        public string COD_CENCOS { get; set; }
             
        public string CENTRO_COSTO { get; set; }
        public string DESCRIPCION { get; set; }
              
        public string CONTROL_ACTIVOS { get; set; }
        public string OBSERVACIONES { get; set; }
        public DateTime? FECHA { get; set; }

        public DateTime? FECHA_INI { get; set; }
        public DateTime? FECHA_FIN { get; set; }

        public string FECH { get; set; }
        public DateTime? FECHAFIN { get; set; }
        public decimal PRESUPUESTO { get; set; }

        public decimal ? PRES_MANOBRA { get; set; }
        public decimal ? PRES_MATERIAL { get; set; }
        public decimal ? PRES_EQUIPOS { get; set; }


        public decimal PORC_ADICIONAL { get; set; }
        public decimal ? acumulado { get; set; }
        public decimal TIPO_CAMBIO { get; set; }
        public string ESTADO { get; set; }
        public string COD_MON { get; set; }
              
        public string MONEDA { get; set; }

        public string USU1 { get; set; }

        public string USU2 { get; set; }

        public string USU3 { get; set; }

        public string tipodoc { get; set; }
        public string documento { get; set; }
        public string VALIDACION { get; set; }

        public List<string> lista { get; set; }

        //datos presupuestos iniciales
        public decimal PI_INICIAL { get; set; }
        public decimal PI_MANOBRA { get; set; }
        public decimal PI_MATERIALES { get; set; }
        public decimal PI_EQUIPOS { get; set; }
        public decimal PORC_INICIAL { get; set; }

        //public string TIPO { get; set; }
    }
}
