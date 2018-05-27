namespace AMA.SchoolManagementSystem.Data.Model.Abstracts
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using AMA.SchoolManagementSystem.Data.Model.Contracts;

    public abstract class SchoolObject : DataModel
    {
        public virtual string Name { get; set; }
    }
}
