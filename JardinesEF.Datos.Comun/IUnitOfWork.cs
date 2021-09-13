using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JardinesEF.Datos.Comun
{
    public interface IUnitOfWork
    {
        void Save();
        //void Commit();
        //void Rollback();
    }
}
