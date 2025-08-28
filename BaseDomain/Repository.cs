namespace BaseDomain
{
    public interface Repository
    {
        IUnitOfWork UnitOfWork
        {
            get;
        }
    }
}
