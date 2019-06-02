using PlayersDatav1.Repositories;
using PlayersDatav1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace PlayersDatav1.UnitOfWork
{

    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        //private readonly IPlayersContext _ipc;
//
       // public UnitOfWork(IPlayersContext ipc)
      //  {
          //  _ipc = ipc;
       // }

        private PlayersContext _context = null;
        private IgracRepository _igracRepository;
        private KlubRepository _klubRepository;
        private DrzavaRepository _drzavaRepository;
        private ILigaRepository _ligaRepository;

        public UnitOfWork(PlayersContext context)
        {
            _context = context;
        }

        public IgracRepository IgracRepository => _igracRepository ?? (_igracRepository = new IgracRepository(_context));

        public KlubRepository KlubRepository => _klubRepository ?? (_klubRepository = new KlubRepository(_context));

        public DrzavaRepository DrzavaRepository => _drzavaRepository ?? (_drzavaRepository = new DrzavaRepository(_context));

        public ILigaRepository LigaRepository => _ligaRepository ?? (_ligaRepository = new LigaRepository(_context));

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}