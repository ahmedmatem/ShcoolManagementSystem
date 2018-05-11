namespace AMA.SchoolManagementSystem.Data.Model.Contracts
{
    using System;

    public interface IDeleted
    {
        bool IsDeleted { get; set; }

        DateTime? DeletedOn { get; set; }
    }
}
