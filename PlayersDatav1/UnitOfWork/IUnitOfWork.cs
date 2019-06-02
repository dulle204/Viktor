using PlayersDatav1.Repositories;

namespace PlayersDatav1.UnitOfWork
{
    public interface IUnitOfWork
    {
        DrzavaRepository DrzavaRepository { get; }
        IgracRepository IgracRepository { get; }
        KlubRepository KlubRepository { get; }
        ILigaRepository LigaRepository { get; }

        void Dispose();
        void Save();
    }
}