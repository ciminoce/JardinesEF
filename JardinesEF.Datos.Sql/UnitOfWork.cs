using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JardinesEF.Datos.Comun;

namespace JardinesEF.Datos.Sql
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly ViveroSqlDbContext _context;
        public UnitOfWork(ViveroSqlDbContext context)
        {
            _context = context;
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
