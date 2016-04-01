using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using DbConnector.DataAccessLayer;

namespace BusinessLogicLayout.Functions
{
    public abstract class EntityHandler
    {
        protected object DbContext;
        protected UnitOfWork UnitOfWork;
        protected EntityHandler()
        {
            var contextHandler = new ContextHandler();
            DbContext = contextHandler.GetContext();
            UnitOfWork = new UnitOfWork(DbContext);
        }
    }
}
