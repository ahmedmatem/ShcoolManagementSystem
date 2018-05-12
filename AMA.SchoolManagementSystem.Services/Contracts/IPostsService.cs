namespace AMA.SchoolManagementSystem.Services.Contracts
{
    using System.Linq;

    using AMA.SchoolManagementSystem.Data.Model;

    public interface IPostsService
    {
        IQueryable<Post> GetAll();

        void Update(Post post);
    }
}
