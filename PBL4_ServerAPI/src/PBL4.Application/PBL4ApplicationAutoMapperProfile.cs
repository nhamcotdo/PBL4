using AutoMapper;
using PBL4.Classes;
using PBL4.Classes.Dtos;
using PBL4.Courses;
using PBL4.Courses.Dtos;
using PBL4.LessonCompletes;
using PBL4.LessonCompletes.Dtos;
using PBL4.LessonOfCourses;
using PBL4.LessonOfCourses.Dtos;
using PBL4.Lessons;
using PBL4.Lessons.Dtos;
using PBL4.Registers;
using PBL4.Registers.Dtos;
using PBL4.SessionRegisters;
using PBL4.SessionRegisters.Dtos;
using PBL4.Sessions;
using PBL4.Sessions.Dtos;
using PBL4.Students;
using PBL4.Students.Dtos;
using PBL4.TeacherOfSessions;
using PBL4.TeacherOfSessions.Dtos;
using PBL4.Teachers;
using PBL4.Teachers.Dtos;
using PBL4.Terms;
using PBL4.Terms.Dtos;
using PBL4.UserLogins;
using PBL4.UserLogins.Dtos;

namespace PBL4
{
    public class PBL4ApplicationAutoMapperProfile : Profile
    {
        public PBL4ApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */
            CreateMap<CreateUpdateUserLoginDto, UserLogin>();
            CreateMap<UserLoginDto, UserLogin>();
            CreateMap<UserLogin, UserLoginDto>();
            CreateMap<CreateUpdateUserLoginDto, UserLoginDto>();
            CreateMap<UserLoginDto, CreateUpdateUserLoginDto>();

            CreateMap<CreateUpdateStudentDto, Student>();
            CreateMap<StudentDto, Student>();
            CreateMap<Student, StudentDto>();
            CreateMap<CreateUpdateStudentDto, StudentDto>();
            CreateMap<StudentDto, CreateUpdateStudentDto>();

            CreateMap<CreateUpdateClassDto, Class>();
            CreateMap<ClassDto, Class>();
            CreateMap<Class, ClassDto>();
            CreateMap<CreateUpdateClassDto, ClassDto>();
            CreateMap<ClassDto, CreateUpdateClassDto>();

            CreateMap<CreateUpdateCourseDto, Course>();
            CreateMap<CourseDto, Course>();
            CreateMap<Course, CourseDto>();
            CreateMap<CreateUpdateCourseDto, CourseDto>();
            CreateMap<CourseDto, CreateUpdateCourseDto>();

            CreateMap<CreateUpdateLessonCompleteDto, LessonComplete>();
            CreateMap<LessonCompleteDto, LessonComplete>();
            CreateMap<LessonComplete, LessonCompleteDto>();
            CreateMap<CreateUpdateLessonCompleteDto, LessonCompleteDto>();
            CreateMap<LessonCompleteDto, CreateUpdateLessonCompleteDto>();

            CreateMap<CreateUpdateLessonDto, Lesson>();
            CreateMap<LessonDto, Lesson>();
            CreateMap<Lesson, LessonDto>();
            CreateMap<CreateUpdateLessonDto, LessonDto>();
            CreateMap<LessonDto, CreateUpdateLessonDto>();

            CreateMap<CreateUpdateCourseDto, Course>();
            CreateMap<CourseDto, Course>();
            CreateMap<Course, CourseDto>();
            CreateMap<CreateUpdateCourseDto, CourseDto>();
            CreateMap<CourseDto, CreateUpdateCourseDto>();

            CreateMap<CreateUpdateRegisterDto, Register>();
            CreateMap<RegisterDto, Register>();
            CreateMap<Register, RegisterDto>();
            CreateMap<CreateUpdateRegisterDto, RegisterDto>();
            CreateMap<RegisterDto, CreateUpdateRegisterDto>();

            CreateMap<CreateUpdateTeacherOfSessionDto, TeacherOfSession>();
            CreateMap<TeacherOfSessionDto, TeacherOfSession>();
            CreateMap<TeacherOfSession, TeacherOfSessionDto>();
            CreateMap<CreateUpdateTeacherOfSessionDto, TeacherOfSessionDto>();
            CreateMap<TeacherOfSessionDto, CreateUpdateTeacherOfSessionDto>();

            CreateMap<CreateUpdateSessionRegisterDto, SessionRegister>();
            CreateMap<SessionRegisterDto, SessionRegister>();
            CreateMap<SessionRegister, SessionRegisterDto>();
            CreateMap<CreateUpdateSessionRegisterDto, SessionRegisterDto>();
            CreateMap<SessionRegisterDto, CreateUpdateSessionRegisterDto>();

            CreateMap<CreateUpdateTeacherDto, Teacher>();
            CreateMap<TeacherDto, Teacher>();
            CreateMap<Teacher, TeacherDto>();
            CreateMap<CreateUpdateTeacherDto, TeacherDto>();
            CreateMap<TeacherDto, CreateUpdateTeacherDto>();

            CreateMap<CreateUpdateTermDto, Term>();
            CreateMap<TermDto, Term>();
            CreateMap<Term, TermDto>();
            CreateMap<CreateUpdateTermDto, TermDto>();
            CreateMap<TermDto, CreateUpdateTermDto>();

            CreateMap<CreateUpdateLessonOfCourseDto, LessonOfCourse>();
            CreateMap<LessonOfCourseDto, LessonOfCourse>();
            CreateMap<LessonOfCourse, LessonOfCourseDto>();
            CreateMap<CreateUpdateLessonOfCourseDto, LessonOfCourseDto>();
            CreateMap<LessonOfCourseDto, CreateUpdateLessonOfCourseDto>();

            CreateMap<CreateUpdateSessionDto, Session>();
            CreateMap<SessionDto, Session>();
            CreateMap<Session, SessionDto>();
            CreateMap<CreateUpdateSessionDto, SessionDto>();
            CreateMap<SessionDto, CreateUpdateSessionDto>();
        }
    }
}
