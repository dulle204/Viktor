using PlayersDatav1.Repositories;

namespace PlayersDatav1.UnitOfWork
{
    public interface IUnitOfWork
    {
        DrzavaRepository DrzavaRepository { get; }
        IgracRepository IgracRepository { get; }
        KlubRepository KlubRepository { get; }
        LigaRepository LigaRepository { get; }

        void Dispose();
        void Save();
    }
}