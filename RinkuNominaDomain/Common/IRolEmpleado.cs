using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RinkuNomina.Domain.Common
{
    public interface IRolEmpleado
    {
         public Guid IdRol { get; set; }

         public string Descripcion { get; set; }

    }

}
