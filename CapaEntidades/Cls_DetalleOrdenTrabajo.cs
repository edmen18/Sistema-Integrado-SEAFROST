using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaEntidades
{
  public  class Cls_DetalleOrdenTrabajo
    {
  public  int  id   { get; set; }
  public double	cantidad    { get; set; }
  public string	codunidad   { get; set; }
  public string	detalle   { get; set; }
  public string	centrocosto  { get; set; }
  public double	valorunitario   { get; set; }
  public double	total   { get; set; }
  public int	mes   { get; set; }
  public string	numero    { get; set; }
  public int	anio    { get; set; }
  public string	codpresupuesto    { get; set; }
  public DateTime	fecha   { get; set; }
  public string	codusu   { get; set; }
  public DateTime	fechamod  { get; set; }
    }
}
