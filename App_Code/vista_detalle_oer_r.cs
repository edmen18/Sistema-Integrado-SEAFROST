using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de vista_detalle_oer_r
/// </summary>
public class vista_detalle_oer_r
{
    public string ORDEN_NUMERO { get; set; }
    public string FECHA { get; set; }
    public string FECHA_CREACION { get; set; }
    public string COD_SOLICITANTE { get; set; }
    public string SOLICITANTE { get; set; }
    public string COD_BANCO { get; set; }
    public string BANCO { get; set; }
    public string NUMERO_CUENTA { get; set; }
    public string MONTO { get; set; }
    public string MOTIVO { get; set; }
    public string APROB1 { get; set; }
    public string APROB2 { get; set; }
    public string APROB3 { get; set; }
    public string ESTADO { get; set; }
    public string CCUENTA { get; set; }
    public string MONEDA { get; set; }
    public string USUMOD { get; set; }
    public string TIPO { get; set; }
    public string CODIGO_TIPO { get; set; }

    // detalle 

    public string PROVEEDOR { get; set; }
    public string RUC { get; set; }
    public string TIPO_DOCUMENTO { get; set; }
    public string NUM_DOCUMENTO { get; set; }
    public string FECHA_EMISION { get; set; }
    public string IGV { get; set; }
    public string MONTO_IGV { get; set; }
    public string PARCIAL { get; set; }
    public string TOTAL { get; set; }
    public string MONTO_DECLARADO { get; set; }
    public string CCOMPRO { get; set; }
    public string GLOSA_COMPROBANTE { get; set; }
    public string GLOSA_MOVIMIENTO { get; set; }
}
