using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Servicio
{
    public interface IListadoPaises
    {
        Dictionary<int,String> ListarPaises { set; }
    }
}
