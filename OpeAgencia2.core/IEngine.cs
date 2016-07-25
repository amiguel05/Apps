using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpeAgencia2.Core.Base
{
    public interface IEngine<T> where T: class 
    {
        T Crear(T entidad);
        void Actualizar(T entidad);
        void Eliminar(T entidad);
        int Save();
    }
}
