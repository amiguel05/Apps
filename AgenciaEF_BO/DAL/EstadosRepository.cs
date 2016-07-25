using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgenciaEF_BO.Models;

namespace AgenciaEF_BO.DAL
{
    public class EstadosRepository : GenericRepository<Estados>
    {

        public EstadosRepository(AgenciasContext context)
            : base(context)
        {

        }

        public IEnumerable<Estados> GetByGroupCode(string sGroupCode)
        {

            var cods = this.Get(filter: s => s.GrupoEstados.CODIGO == sGroupCode);


            return cods;

        }
    }
}
