using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IBase<T>
    {
        OverwatchRentalSystemEntities dbContext { get; }

        IEnumerable<T> GetAll();
        bool Insert(T entity);
        T Update(T entity);
    }
}
