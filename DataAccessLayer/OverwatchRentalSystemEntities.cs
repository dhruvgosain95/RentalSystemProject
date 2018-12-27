using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public partial class OverwatchRentalSystemEntities : DbContext
    {
        private static OverwatchRentalSystemEntities _dbContext = null;


        public static OverwatchRentalSystemEntities Instance
        {
            get
            {
                if (_dbContext == null)
                {
                    _dbContext = new OverwatchRentalSystemEntities();
                }
                return _dbContext;
            }
        }
    }
}

