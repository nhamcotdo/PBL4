using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PBL4.Courses.Dtos;
using Volo.Abp.Application.Dtos;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Application.Services;
using System.Linq;
using PBL4.LessonOfCourses;
using Volo.Abp.ObjectMapping;
using PBL4.LessonOfCourses.Dtos;

namespace PBL4.Courses
{
    public class CourseAppService : CrudAppService<Course, CourseDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateCourseDto, CreateUpdateCourseDto>, ICourseAppService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly ILessonOfCourseRepository _lessonOfCourseRepository;
        public CourseAppService(ICourseRepository courseRepository, ILessonOfCourseRepository lessonOfCourseRepository) : base(courseRepository)
        {
            _courseRepository = courseRepository;
            _lessonOfCourseRepository = lessonOfCourseRepository;
        }

        public async Task<PagedResultDto<CourseDto>> SearchAsync(string filter = "")
        {
            var queryable = (await _courseRepository.GetQueryableAsync())
                .WhereIf(
                    !filter.IsNullOrEmpty(),
                    x =>
                    x.Name.Contains(filter)
                    || x.Description.Contains(filter)
                    || x.NumberOfLesson.ToString().Contains(filter)
                );
            var courses = await queryable.ToListAsync();
            var maxResultCount = await queryable.CountAsync();
            var rs = new PagedResultDto<CourseDto>(maxResultCount, ObjectMapper.Map<List<Course>, List<CourseDto>>(courses));

            return rs;
        }

        public override Task<CourseDto> CreateAsync(CreateUpdateCourseDto input)
        {
            foreach (var lesson in input.LessonOfCourses)
            {
                lesson.Id = Guid.NewGuid();
            }
            return base.CreateAsync(input);
        }

        public override async Task<CourseDto> UpdateAsync(Guid id, CreateUpdateCourseDto input)
        {
            var lessonOfCourseQueryable = await _lessonOfCourseRepository.GetQueryableAsync();
            await _lessonOfCourseRepository.DeleteManyAsync(
                 lessonOfCourseQueryable.Where(x => x.CourseId == id).ToList());
            
            foreach (var lesson in input.LessonOfCourses)
            {
                lesson.Id = Guid.NewGuid();
            }

            return await base.UpdateAsync(id, input);
        }
    }
}