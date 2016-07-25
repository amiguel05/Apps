using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clsUtils
{
    public interface IErrores
    {

        void MostrarMensaje(string mensaje, bool requiereConfirmacion = false);

    }
}
