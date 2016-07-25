﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgenciaEF_BO.Models;

namespace AgenciaEF_BO.DAL
{
    public class TiposRepository : GenericRepository<Tipos>
    {

        public TiposRepository(AgenciasContext context)
            : base(context)
        {

        }

        public IEnumerable<Tipos> GetByGroupCode(string sGroupCode)
        {

            var cods = this.Get(filter: s => s.GruposTipos.CODIGO == sGroupCode);


            return cods;

        }
    }
}
