using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpeAgencia2.Core.Base
{
    // Manuel A. Hernández. 14-1-2014
    /// <summary>
    /// Interfaz que se incluirá en todas las entidades para obtener su llave primaria.
    /// </summary>
    public interface IEntity
    {
        int EntityId { get; }
    }
}
