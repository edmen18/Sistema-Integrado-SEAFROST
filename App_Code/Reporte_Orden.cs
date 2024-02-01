using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class reporte_orden
    {
        
        public string OC_CNUMORD { get; set; }
        public string OC_CCODPRO { get; set; }
        public string OC_CRAZSOC { get; set; }
        public string OC_CDIRPRO { get; set; }
        public string OC_CCODMON { get; set; }
        public string OC_CFORPA1 { get; set; }
        public string OC_DFECACT { get; set; }
        public string SC_CUSUARI { get; set; }//subconsulta
        public string OC_DFECDOC { get; set; }
        public string OC_DFECENT { get; set; }
        public string SC_CCOSTOC { get; set; }//subconsulta
        public string OC_CLUGENT { get; set; }
        public string OC_CDETENT { get; set; }//OBSERVACION
        public string OC_CCOTIZA { get; set; }
        public string SC_CTIPDOC { get; set; }//TIPODOCUMENTO SUBCONSULTA
        public string SC_CTIPORD { get; set; }//TIPOORDEN NACIONAL IMPORT SUBCONSULTA
        public string SC_CSITORD { get; set; }//SITUACION ORDEN SUBCONSULTA 
        public decimal OC_NIMPUS { get; set; }
        public decimal OC_NIMPMN { get; set; }
        //---------DETALLE------------
        public string OC_CCODIGO { get; set; }
        public string OC_CDESREF { get; set; }
        public string OC_CNUMREQ { get; set; }//requerimiento
        public string SC_CCENCOS { get; set; }//SUBCONSULTA
        public string SC_CSOLICI { get; set; }//SUBCONSULTA
        public string OC_CUNIDAD { get; set; }
        public decimal OC_NCANORD { get; set; }
        public decimal OC_NPREUN2 { get; set; }
        public decimal OC_SUBTOTAL { get; set; }//OC_NPREUN2* OC_NCANORD // SUBTOTAL
        public decimal OC_NIGV { get; set; } //TOTAL IGV
        public decimal OC_NTOTUS { get; set; } 
        public decimal OC_NTOTMN { get; set; }
        public string SC_EMPRESA { get; set; }
        public string SC_RUC { get; set; }
        public string SC_DIREC { get; set; }
        public string SC_TELE { get; set; }
        public string SC_CONTAC { get; set; }
        public string OC_CTIPORD { get; set; }
        public decimal OC_NDESCTO { get; set; }
        public decimal OC_NDESCAD { get; set; }
        public string OC_CUSEA01 { get; set; }
        public string OC_CUSEA02 { get; set; }
        public string OC_CUSEA03 { get; set; }

        public string OC_CSTNOMC { get; set; }
        public string OC_CSTPAIS { get; set; }
        public string OC_CSTDIRC { get; set; }
        public string OC_CSTTELC { get; set; }
        public string OC_CSTFAXC { get; set; }
        public string OC_CSTPERA { get; set; }
        public string OC_CCTNOMC { get; set; }
        public string OC_CCTPAIS { get; set; }
        public string OC_CCTDIRC { get; set; }
        public string OC_CCTTELC { get; set; }
        public string OC_CCTFAXC { get; set; }
        public string OC_CCTPERA { get; set; }
        public string OC_GRUPO { get; set; }
        public string OC_COMENTA { get; set; }
        public string OC_CCENCOS { get; set; }
        public string OC_CPEDINT { get; set; }
        public decimal OC_NISC { get; set; }
        public string OC_CRESPER3 { get; set; }
        public string OC_INFOT { get; set; }

        //informacion para calidad
        public string CA_DESCERTIF { get; set; }
        public string CA_DESDEST { get; set; }
        public string CA_DESPROD { get; set; }
        public string CA_DESSOLI { get; set; }
        public string CA_PRODMUE { get; set; }
        public string CA_AADIC { get; set; }
        public string CA_FECHAD { get; set; }
        public string CA_FECHAA { get; set; }
        //para subinforme
        public string SR_NORD { get; set; }
        public decimal OC_NDOCCHA { get; set; }
    }
}
