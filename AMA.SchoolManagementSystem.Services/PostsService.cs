namespace AMA.SchoolManagementSystem.Services
{
    using AMA.SchoolManagementSystem.Data.Contracts;
    using AMA.SchoolManagementSystem.Data.Model;
    using AMA.SchoolManagementSystem.Data.Repositories;
    using AMA.SchoolManagementSystem.Services.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class PostsService : IPostsService
    {
        private readonly IEfRepository<Post> postsRepository;
        private readonly ISaveContext context;

        public PostsService(IEfRepository<Post> postsRepository, ISaveContext context)
        {
            this.postsRepository = postsRepository;
            this.context = context;
        }

        public IQueryable<Post> GetAll()
        {
            return postsRepository.All();
        }

        public void Update(Post post)
        {
            postsRepository.Update(post);
            this.context.Commit();
        }
    }
}
