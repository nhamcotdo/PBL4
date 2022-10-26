using System;
using PBL4.Courses.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace PBL4.Courses
{
    public class CourseAppService : CrudAppService<Course, CourseDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateCourseDto, CreateUpdateCourseDto>, ICourseAppService
    {
        private readonly ICourseRepository _courseRepository;
        public CourseAppService(ICourseRepository courseRepository) : base(courseRepository)
        {
            _courseRepository = courseRepository;
        }
    }
}