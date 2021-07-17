using System.Collections.Generic;
using System.Threading.Tasks;
using EduPortal.Application.Interfaces;
using EduPortal.Application.ViewModels;
using EduPortal.Domain.Interfaces;
using EduPortal.Domain.Models;
using EduPortal.Domain.Models.Materials;
using EduPortal.Domain.Models.Users;

namespace EduPortal.Application.Services
{
    public class OLDMentorService : IMentorService
    {
        private Mentor mentor;

        private readonly IRepository<Article> _articleRepositiry;
        private readonly IRepository<DigitalBook> _digitalBookRepository;
        private readonly IRepository<VideoMaterial> _videoMaterialRepository;
        private readonly IRepository<Material> _materialRepository;
        private readonly IRepository<Course> _courseRepository;
        private readonly IRepository<User> _mentorRepository;

        public OLDMentorService(Mentor mentor, IRepository<User> userRepository, IRepository<Material> materialRepository, IRepository<Course> courseRepository,
            IRepository<Article> articleRepositiry, IRepository<DigitalBook> digitalBookRepository, IRepository<VideoMaterial> videoMaterialRepository)
        {
            this.mentor = mentor;
            _mentorRepository = userRepository;
            _courseRepository = courseRepository;
            _materialRepository = materialRepository;
            _videoMaterialRepository = videoMaterialRepository;
            _digitalBookRepository = digitalBookRepository;
            _articleRepositiry = articleRepositiry;
        }

        public async void CreateCourse(Course course)
        {
            //todo
            //var course = new Course();

            await _courseRepository.AddAsync(course);

            if (mentor.CreatedCourses == null)
            {
                mentor.CreatedCourses = new List<Course>();
            }
            mentor.CreatedCourses.Add(course);

            await _mentorRepository.UpdateAsync(mentor);
        }

        public async  void CreateMaterial(Material material)
        {
            //_materialRepository.Add(material);

            if (material is Article article)
            {
                await _articleRepositiry.AddAsync(article);
            }
            else if(material is DigitalBook dBook)
            {
                await _digitalBookRepository.AddAsync(dBook);
            }
            else if(material is VideoMaterial vMaterial)
            {
                await _videoMaterialRepository.AddAsync(vMaterial);
            }

            if(mentor.CreatedMaterials == null)
            {
                mentor.CreatedMaterials = new List<Material>();
            }

            mentor.CreatedMaterials.Add(material);

            await _mentorRepository.UpdateAsync(mentor);
        }

        public async Task<CoursesViewModel> GetAllCourses()
        {
            //todo
            var courses = new CoursesViewModel()
            {
                //Courses = await _courseRepository.Get(c => true)
            };

            return courses;
        }

        public async void DeleteCourse(Course course)
        {
            await _courseRepository.DeleteAsync(course);
        }

        public UserProfileViewModel GetProfile()
        {
            var properties = mentor.GetType().GetProperties();
            Dictionary<string, object> props = new Dictionary<string, object>();

            foreach (var propertyInfo in properties)
            {
                props.Add(propertyInfo.Name, propertyInfo.GetValue(mentor));
            }

            var profile = new UserProfileViewModel()
            {
                //Fields = props
            };

            return profile;
        }

        public Mentor GetMentor()
        {
            if (mentor.CreatedCourses == null)
            {
                mentor.CreatedCourses = new List<Course>();
            }

            if (mentor.CreatedMaterials == null)
            {
                mentor.CreatedMaterials = new List<Material>();
            }

            return mentor;
        }

        public Task<IEnumerable<CourseViewModel>> GetUserCourses(string userId)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<CourseViewModel>> GetFinishedCourses(string userId)
        {
            throw new System.NotImplementedException();
        }

        public Task<UserProfileViewModel> GetProfile(string userId)
        {
            throw new System.NotImplementedException();
        }

        public Task CreateArticleAsync(CreateArticleViewModel model, string authorId)
        {
            throw new System.NotImplementedException();
        }

        public Task CreateBookAsync(CreateBookViewModel model, string authorId)
        {
            throw new System.NotImplementedException();
        }

        public Task CreateVideoAsync(CreateVideoViewModel model, string authorId)
        {
            throw new System.NotImplementedException();
        }

        public Task CreateCourseAsync(CreateCourseViewModel model, string authorId)
        {
            throw new System.NotImplementedException();
        }

        public Task CreateArticleAsync(CreateArticleViewModel model)
        {
            throw new System.NotImplementedException();
        }
    }
}
