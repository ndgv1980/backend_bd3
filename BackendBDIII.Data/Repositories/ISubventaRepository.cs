using BackendBDIII.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendBDIII.Data.Repositories
{
    public interface ISubventaRepository
    {
        Task<IEnumerable<Subventa>> GetAllSubsales();
        Task<bool> InsertSubsale(Subventa i_subsale);
    }
}
