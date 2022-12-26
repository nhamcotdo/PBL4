namespace PBL4.Permissions
{
    public static class PBL4Permissions
    {
        public const string GroupName = "PBL4";

        // public const string Create = GroupName + ".Create";
        // public const string View = GroupName + ".View";
        // public const string Update = GroupName + ".Update";
        // public const string Delete = GroupName + ".Delete";

        public class Class
        {
            public const string Default = GroupName + "_Class";
            public const string Get = Default + "_Get";
            public const string Update = Default + "_Update";
            public const string Create = Default + "_Create";
            public const string Delete = Default + "_Delete";
        }

        public class Course
        {
            public const string Default = GroupName + "_Course";
            public const string Get = Default + "_Get";
            public const string Update = Default + "_Update";
            public const string Create = Default + "_Create";
            public const string Delete = Default + "_Delete";
        }

        public class Lesson
        {
            public const string Default = GroupName + "_Lesson";
            public const string Get = Default + "_Get";
            public const string Update = Default + "_Update";
            public const string Create = Default + "_Create";
            public const string Delete = Default + "_Delete";
        }

        public class Student
        {
            public const string Default = GroupName + "_Student";
            public const string Get = Default + "_Get";
            public const string Update = Default + "_Update";
            public const string Create = Default + "_Create";
            public const string Delete = Default + "_Delete";
        }

        public class Session
        {
            public const string Default = GroupName + "_Session";
            public const string Get = Default + "_Get";
            public const string Update = Default + "_Update";
            public const string Create = Default + "_Create";
            public const string Delete = Default + "_Delete";
        }

        public class Term
        {
            public const string Default = GroupName + "_Term";
            public const string Get = Default + "_Get";
            public const string Update = Default + "_Update";
            public const string Create = Default + "_Create";
            public const string Delete = Default + "_Delete";
        }
    }
}