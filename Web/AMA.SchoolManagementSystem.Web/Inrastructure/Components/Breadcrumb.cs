namespace AMA.SchoolManagementSystem.Web.Inrastructure.Components
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class Breadcrumb
    {
        public const string ActionAdd = "Добавяне";

        public const string HomeIcon = "<i class=\"fa fa-home\"></i>";

        public const string HomeName = "Начало";
        public const string SchoolName = "Училище";
        public const string StudentsName = "Ученици";
        public const string TeachersName = "Учители";
        public const string GroupsName = "Класове";

        public const string AdminHomeUrl = "~/admin/home";
        public const string AdminSchoolUrl = "~/admin/school";
        public const string AdminStudentsUrl = "~/admin/students";
        public const string AdminTeachersUrl = "~/admin/teachers";
        public const string AdminGroupsUrl = "~/admin/groups";

        public string Name { get; set; }

        public string Url { get; set; }

        public Breadcrumb(string name) : this(name, "#") { }

        public Breadcrumb(string name, string url)
        {
            Name = name;
            Url = url;
        }
    }
}