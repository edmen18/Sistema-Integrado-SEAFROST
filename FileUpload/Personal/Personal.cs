using EFX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFX
{
    public class Personal
    {
        public List<vista_planillaSemanal> PlanillaSemanal()
        {
            using (INYSOFT2013Entities context = new INYSOFT2013Entities())
            {

                return (from c in context.planillaSemanal orderby c.semana descending select c).ToList<vista_planillaSemanal>();
            }
        }

    }
}
