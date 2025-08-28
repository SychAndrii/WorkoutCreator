namespace WorkoutApplication
{
    public abstract class ApplicationMapper
    {
        protected T TryMap<T>(Func<T> mapFunc)
        {
            try
            {
                return mapFunc();
            }
            catch (Exception ex)
            {
                throw new InvalidContractException("Failed to map contract to domain object.", ex);
            }
        }
    }
}
