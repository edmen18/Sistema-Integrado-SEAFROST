using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{

    public class vistas_finanzas
    {

        public string CP_CVANEXO { get; set; }

        public string CP_CCODIGO { get; set; }

        public string NOMTIT { get; set; }

        public string CP_CTIPDOC { get; set; }


        public string CP_CNUMDOC { get; set; }


        public string CP_CFECDOC { get; set; }



        public string CP_CFECVEN { get; set; }


        public string CP_CFECREC { get; set; }


        public string CP_CSITUAC { get; set; }


        public string CP_CFECCOM { get; set; }


        public string CP_CSUBDIA { get; set; }


        public string CP_CCOMPRO { get; set; }

        public string CP_CDEBHAB { get; set; }


        public string CP_CCODMON { get; set; }


        public decimal CP_NTIPCAM { get; set; }

        public decimal IMPORTE { get; set; }

        public decimal CP_NIMPOMN { get; set; }


        public decimal CP_NIMPOUS { get; set; }


        public decimal CP_NSALDMN { get; set; }


        public decimal CP_NSALDUS { get; set; }

        public decimal SALDO { get; set; }

        public decimal CP_NIGVMN { get; set; }


        public decimal CP_NIGVUS { get; set; }


        public decimal CP_NIMP2MN { get; set; }


        public decimal CP_NIMP2US { get; set; }


        public decimal CP_NIMPAJU { get; set; }


        public string CP_CCUENTA { get; set; }


        public string CP_CAREA { get; set; }

        public string NOMARE { get; set; }

        public string CP_CFECUBI { get; set; }


        public string CP_CTDOCRE { get; set; }


        public string CP_CNDOCRE { get; set; }



        public string CP_CFDOCRE { get; set; }



        public string CP_CTDOCCO { get; set; }



        public string CP_CNDOCCO { get; set; }



        public string CP_CFDOCCO { get; set; }



        public string CP_CFECPRO { get; set; }



        public string CP_CFORMPG { get; set; }



        public string CP_CCOGAST { get; set; }


        public string CP_CDESCRI { get; set; }

        public DateTime? CP_DFECCRE { get; set; }

        public DateTime? CP_DFECMOD { get; set; }


        public string CP_CUSER { get; set; }


        public decimal CP_NINAFEC { get; set; }



        public string CP_CTIPSUN { get; set; }

        public DateTime? CP_DFECDOC { get; set; }

        public DateTime? CP_DFECVEN { get; set; }

        public DateTime? CP_DFECREC { get; set; }

        public DateTime? CP_DFECCOM { get; set; }

        public string CP_DFDOCRE { get; set; }
        public string CP_DFECCRE1 { get; set; }

        public DateTime? CP_DFDOCCO { get; set; }

        public DateTime? CP_DFECPRO { get; set; }

        public DateTime? CP_DFECUBI { get; set; }


        public decimal CP_CIMAGEN { get; set; }


        public string CP_CVANERF { get; set; }


        public string CP_CCODIRF { get; set; }



        public string CP_CNUMORD { get; set; }



        public string CP_CTIPO { get; set; }



        public string CP_CFECCAM { get; set; }

        public DateTime? CP_DFECCAM { get; set; }



        public string CP_CTASDET { get; set; }

        public string PORDET { get; set; }

        public string CP_CSECDET { get; set; }



        public string CP_CCENCOR { get; set; }

        public string CENCOR { get; set; }

        public string CP_CRETE { get; set; }


        public decimal CP_NPORRE { get; set; }
    }

    public class vista_prog_pagos
    {
        public string CP_CPROGRA { get; set; }
        public string CP_CMEDPAG { get; set; }
        public string CP_CMODULO { get; set; }
        public string CP_CUSUCRE { get; set; }
        public string CP_DFECCRE { get; set; }
        public string TCOD { get; set; }
        public string TCLAVE { get; set; }
        public string TDESCRI { get; set; }
    }

    public class vista_prog_sub
    {
        public string CP_CPROGRA { get; set; }
        public string TCOD { get; set; }
        public string TCLAVE { get; set; }
        public string TDESCRI { get; set; }
    }

    public class vista_pago
    {
        /**/
        public string BA_TIPREG { get; set; }/*TIPO CUENTA*/
        public string BA_TIPREG1 { get; set; }/*TIPO CUENTA*/
        public string BA_TIPREG2 { get; set; }
        public string PG_CVANEXO { get; set; }
        public string PG_CCODIGO { get; set; }
        public string PG_REFEREN { get; set; }
        public string PG_REFEREN1 { get; set; }
        public string PG_CTIPDOC { get; set; }
        public string PG_CNUMDOC { get; set; }
        public String PG_CNUMDOC1 { get; set; }
        public String PG_MINUDOC { get; set; }
        public String PG_NDOCPAG { get; set; }/*NUMERO DE DOCUMENTO A PAGAR*/
        public string PG_DESCRIP { get; set; }
        public string PG_CSUBDIA { get; set; }
        public string PG_CNUMCOM { get; set; }
        public string PG_CFECCOM { get; set; }
        public string PG_DFECCOM { get; set; }
        public string PG_CFECCOM2 { get; set; }
        public string PG_HORPRO { get; set; }
        public string PG_CANTABO { get; set; }
        public string PG_CTACORR { get; set; }/*CUENTA CORRIENTE*/
        public string PG_CCODMON { get; set; }
        public string PG_NIMPORT { get; set; }
        public string PG_NIMPORTR { get; set; }
        public decimal PG_NIMPOMN { get; set; }
        public decimal PG_NIMPOUS { get; set; }
        public decimal PG_IMRCOMD { get; set; }/*IMPORTE DE RETENCION DEL DETALLE COMPROBANTE*/
        public string PG_FLAG { get; set; }
        /**/
        public string AU_MODPAG { get; set;}/*proveedor*/
        public string AV_CDOCIDE { get; set; }/*proveedor*/
        public string AC_CCODIGO { get; set; }
        public string AC_CODOPRO { get; set; } /*PROVEEDOR*/
        public string AC_CNOMBRE { get; set; }
        public string AV_CTIPTRA { get; set; }/*TIPO TRABAJADOR*/
        public string AC_CVALRUT { get; set; }/*FLAG VALIDAR RUC*/
        public string AC_CTIPPRO { get; set; }/*TIPO PRODUCTO*/

        /*VARI*/
        public string CT_CTCARGO { get; set; }/*SEAFROST*/
        //public string CT_CTABONO { get; set; }
        public string CT_CNUMCTA { get; set; }
        public string CT_CCODMON { get; set; }
        public string CT_CCUENTA { get; set; }
        public string CT_BANCO { get; set; }
        public string CT_CTOTAL { get; set; }
        public string AC_CABREVI { get; set; }

        /*COMPROBNATE*/
        public string DFECVEN2 { get; set; }
    }
    /// <summary>
    /// Detalle txt x Banco
    /// </summary>
    /*public class vista_pago_d{
        public string PG_CVANEXO { get; set; }
        public string PG_CCODIGO { get; set; }
        public string PG_CSUBDIA { get; set; }
        public string PG_CNUMCOM { get; set; }
    }*/
}
