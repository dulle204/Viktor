namespace PlayersDomain
{
    public interface IFactory
    {
        IPlayerService GetInstance(string par);
    }
}