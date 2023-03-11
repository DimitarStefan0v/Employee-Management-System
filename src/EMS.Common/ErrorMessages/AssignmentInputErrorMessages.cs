namespace EMS.Common.ErrorMessages
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class AssignmentInputErrorMessages
    {
        /// <summary>
        /// Title Messages.
        /// </summary>
        public const string TitleRequired = "The Title is required";

        public const string TitleMinLength = "The Title must be at least 4 characters long";

        public const string TitleMaxLength = "The Title can't be more than 20 characters long";

        public const string AssignmentExists = "There is already a pending Task with the same name";

        /// <summary>
        /// Description Messages.
        /// </summary>
        public const string DescriptionRequired = "The Description is required";

        public const string DescriptionMinLength = "The Description must be at least 8 characters long";

        public const string DescriptionMaxLength = "The Description can't be more than 300 characters long";

        /// <summary>
        /// StartDate Messages.
        /// </summary>
        public const string DisplayStartDate = "Start Date";

        public const string StartDateRequired = "The Start Date is required";

        /// <summary>
        /// DueDate Messages.
        /// </summary>
        public const string DisplayDueDate = "Due Date";

        public const string DueDateRequired = "The Due Date is required";
    }
}
