using System.Threading.Tasks;
using EduPortal.Application.ViewModels;

namespace EduPortal.Application.Interfaces
{
    public interface IMentorService : IUserService
    {
        Task CreateArticleAsync(CreateArticleViewModel model, string authorId);

        Task CreateBookAsync(CreateBookViewModel model, string authorId);

        Task CreateVideoAsync(CreateVideoViewModel model, string authorId);

        Task CreateCourseAsync(CreateCourseViewModel model, string authorId);

        Task UpdateCourseAsync(CreateCourseViewModel model, string authorId);
    }
}
