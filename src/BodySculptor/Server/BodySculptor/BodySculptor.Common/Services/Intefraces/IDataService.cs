namespace BodySculptor.Common.Services.Intefraces
{
    using BodySculptor.Common.Data.Entities;
    using System.Threading.Tasks;

    public interface IDataService<in TEntity>
       where TEntity : class
    {
        Task MarkMessageAsPublished(int id);

        Task Save(TEntity entity, params Message[] messages);
    }
}
