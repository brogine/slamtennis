﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Servicio.InterfacesUI
{
    public interface ILoginUI
    {
        int Dni { get; }

        string Usuario { get; }

        string Password { get; }

        bool Estado { get; set; }
    }
}
