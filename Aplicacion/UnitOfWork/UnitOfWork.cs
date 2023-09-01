using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacion.Repository;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly SkeletonAppWebApiContext context;
        private PaisRepository _paises;
        public UnitOfWork(SkeletonAppWebApiContext _context){
            context = _context;
        }

        public IPaisRepository Paises
        {
            get 
            {
                if(_paises == null){
                    _paises = new PaisRepository(context);
                }
                return _paises;
            }
        }

        //public IRegion Regiones => throw new NotImplementedException();

        public void Dispose()
        {
            context.Dispose();//ayuda a que no haya recarga de memoria en el servidor
        }

        public async Task<int> SaveAsync()
        {
            return await context.SaveChangesAsync();
        }
    }
}