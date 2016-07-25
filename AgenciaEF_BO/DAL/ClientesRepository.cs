using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgenciaEF_BO.Models;

namespace AgenciaEF_BO.DAL
{
    public class ClientesRepository : GenericRepository<Clientes>
    {

        public ClientesRepository(AgenciasContext context)
            : base(context)
        {

        }

        public IEnumerable<Clientes> ClienteIdFromEps(string psNumeroEps)
        {

            var cods = this.Get(filter: s => s.CTE_NUMERO_EPS == psNumeroEps);

            return cods;

        }
      


    }
}
