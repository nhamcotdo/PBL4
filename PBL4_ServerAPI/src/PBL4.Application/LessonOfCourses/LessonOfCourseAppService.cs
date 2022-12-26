using System;
using Microsoft.AspNetCore.Authorization;
using PBL4.LessonOfCourses.Dtos;
using PBL4.Permissions;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace PBL4.LessonOfCourses
{
    [Authorize]
    public class LessonOfCourseAppService : CrudAppService<LessonOfCourse, LessonOfCourseDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateLessonOfCourseDto, CreateUpdateLessonOfCourseDto>, ILessonOfCourseAppService
    {
        private readonly ILessonOfCourseRepository _lessonOfCourseRepository;
        public LessonOfCourseAppService(ILessonOfCourseRepository lessonOfCourseRepository) : base(lessonOfCourseRepository)
        {
            _lessonOfCourseRepository = lessonOfCourseRepository;
        }
    }
}