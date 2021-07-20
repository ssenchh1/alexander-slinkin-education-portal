using System.Linq;
using System.Threading.Tasks;
using EduPortal.Application.Interfaces;
using EduPortal.Application.ViewModels;
using EduPortal.Domain;
using EduPortal.Domain.Interfaces;
using EduPortal.Domain.Models;
using EduPortal.Domain.Models.Joining;
using EduPortal.Domain.Models.Materials;
using EduPortal.Domain.Models.Users;
using Microsoft.AspNetCore.Identity;

namespace EduPortal.Application.Services
{
    public class CourseService : ICourseService
    {
        private readonly IRepository<Course> _courseRepository;
        private readonly IRepository<Material> _materialRepository;
        private readonly IGenericUserRepository<User> _userRepository;
        private readonly UserManager<User> _userManager;
        private readonly IUserRepository<Student> _studentRepository;

        public CourseService(IRepository<Course> courseRepository, IRepository<Material> materialRepository, IGenericUserRepository<User> userRepository, UserManager<User> userManager, IUserRepository<Student> studentRepository)
        {
            _courseRepository = courseRepository;
            _materialRepository = materialRepository;
            _userRepository = userRepository;
            _userManager = userManager;
            _studentRepository = studentRepository;
        }

        public async Task<CoursesViewModel> GetCourses()
        {
            return new CoursesViewModel()
            {
                Courses = await _courseRepository.GetAsync()
            };
        }

        public async Task<PagedList<Course>> GetCoursesPaged(int pageNumber, int pageSize)
        {
            return await _courseRepository.GetPagedAsync(pageNumber, pageSize, null, "Author,Students");
        }

        public async Task<CoursesViewModel> GetTopCourses()
        {
            return new CoursesViewModel()
            {
                Courses = await _courseRepository.GetAsync(null, "Students", c => c.OrderByDescending(c => c.Students.Count), 0, 5)
            };
        }

        public async Task<CourseViewModel> GetCourseVMById(int id, string include)
        {
            var course = await _courseRepository.GetByIdAsync(id, include);
            var courseVM = new CourseViewModel()
            {
                Id = course.Id, Title = course.Name, Author = course.AuthorId, Description = course.Description,
                StudentsCount = course.Students.Count, ImagePath = course.CourseImage
            };

            return courseVM;
        }

        public async Task<Course> GetCourseById(int id, string include)
        {
            return await _courseRepository.GetByIdAsync(id, include);
        }

        public async Task AddStudentToCourse(int courseId, Student student)
        {
            var course = await _courseRepository.GetByIdAsync(courseId, "Students");
            if (!course.Students.Contains(student))
            {
                course.Students.Add(student);
                await _courseRepository.UpdateAsync(course);
            }
        }

        public async Task AddCourseToStudent(int courseId, Student student)
        {
            var course = await _courseRepository.GetByIdAsync(courseId);
            student.Courses.Add(course);
        }

        public async Task<bool> IsPurchased(int corseId, Student student)
        {
            var course = await _courseRepository.GetByIdAsync(corseId, "Students");
            return course.Students.Contains(student);
        }

        public async Task<bool> IsMaterialPassed(int materialId, string userName)
        {
            var material = await _materialRepository.GetByIdAsync(materialId);
            var user = await _userRepository.GetByIdAsync((await _userManager.FindByNameAsync(userName)).Id);
            var student = await _studentRepository.GetByIdAsync(user.Id, "PassedMaterials");
            return student.PassedMaterials.Contains(material);
        }

        public async Task PassMaterial(int materialId, string userName)
        {
            var material = await _materialRepository.GetByIdAsync(materialId);
            var user = await _userRepository.GetByIdAsync((await _userManager.FindByNameAsync(userName)).Id);
            var student = await _studentRepository.GetByIdAsync(user.Id, "PassedMaterials");

            if (!student.PassedMaterials.Contains(material))
            {
                student.PassedMaterials.Add(material);
            }

            await _studentRepository.UpdateAsync(student);
        }

        public async Task AddSkills(int materialId, string userName)
        {
            var user = await _userRepository.GetByIdAsync((await _userManager.FindByNameAsync(userName)).Id, "SkillUsers");
            var material = await _materialRepository.GetByIdAsync(materialId, "SkillMaterials");
            
            foreach (var skillMaterial in material.SkillMaterials)
            {
                if (user.SkillUsers.Contains(new SkillUser() {SkillId = skillMaterial.SkillId}))
                {
                    if (user.SkillUsers.FirstOrDefault(sk => sk.SkillId == skillMaterial.SkillId).Level <
                        skillMaterial.Level)
                    {
                        user.SkillUsers.FirstOrDefault(sk => sk.SkillId == skillMaterial.SkillId).Level =
                            skillMaterial.Level;
                    }
                }
                else
                {
                    user.SkillUsers.Add(new SkillUser(){SkillId = skillMaterial.SkillId, UserId = user.Id, Level = skillMaterial.Level});
                }
            }

            await _userRepository.UpdateAsync(user);
        }
    }
}
