﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
   public class VISTAIMP_TRABAJOS_DETALLE
    {
        public string TR_CODIGO { get; set; }

        public int AE_COD { get; set; }
        public string AE_DESC { get; set; }

        public string EQ_CODIGO { get; set; }
        public string EQ_DESCRIPCION { get; set; }
        public string PL_CODIGO { get; set; }

        public string PL_DESCRIPCION { get; set; }
        public string CONTRATISTA { get; set; }

        public string COD_CENCOS { get; set; }

        public string CENTRO_COSTO { get; set; }
       public string DESCRIPCION { get; set; }

        public string CONTROL_ACTIVOS { get; set; }
        public string OBSERVACIONES { get; set; }
        public DateTime FECHA { get; set; }

      
        public DateTime FECHAFIN { get; set; }
        public decimal PRESUPUESTO { get; set; }
        public decimal MONTO { get; set; }
        public decimal PORC_ADICIONAL { get; set; }
    
        public string ESTADO { get; set; }
        public string COD_MON { get; set; }

        public string MONEDA { get; set; }

        public string USU1 { get; set; }

        public string USU2 { get; set; }

        public string USU3 { get; set; }

        public string tipodoc { get; set; }
        public string documento { get; set; }
    }
}
