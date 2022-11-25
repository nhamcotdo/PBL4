using System;
using PBL4.LessonOfCourses.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace PBL4.LessonOfCourses
{
    public class LessonOfCourseAppService : CrudAppService<LessonOfCourse, LessonOfCourseDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateLessonOfCourseDto, CreateUpdateLessonOfCourseDto>, ILessonOfCourseAppService
    {
        private readonly ILessonOfCourseRepository _lessonOfCourseRepository;
        public LessonOfCourseAppService(ILessonOfCourseRepository lessonOfCourseRepository) : base(lessonOfCourseRepository)
        {
            _lessonOfCourseRepository = lessonOfCourseRepository;
        }
    }
}