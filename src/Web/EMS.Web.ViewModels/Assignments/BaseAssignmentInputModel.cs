namespace EMS.Web.ViewModels.Assignments
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using EMS.Common.ErrorMessages;
    using EMS.Common.ValidationAttributes;

    public abstract class BaseAssignmentInputModel
    {
        [Required(ErrorMessage = AssignmentInputErrorMessages.TitleRequired)]
        [MinLength(4, ErrorMessage = AssignmentInputErrorMessages.TitleMinLength)]
        [MaxLength(50, ErrorMessage = AssignmentInputErrorMessages.TitleMaxLength)]
        public string Title { get; set; }

        [Required(ErrorMessage = AssignmentInputErrorMessages.DescriptionRequired)]
        [MinLength(8, ErrorMessage = AssignmentInputErrorMessages.DescriptionMinLength)]
        [MaxLength(500, ErrorMessage = AssignmentInputErrorMessages.DescriptionMaxLength)]
        public string Description { get; set; }

        [Display(Name = AssignmentInputErrorMessages.DisplayStartDate)]
        [Required(ErrorMessage = AssignmentInputErrorMessages.StartDateRequired)]
        [DataType(DataType.Date, ErrorMessage = AssignmentInputErrorMessages.StartDateRequired)]
        [CurrentYearMaxValueAttribute(2015)]
        public DateTime StartDate { get; set; }

        [Display(Name = AssignmentInputErrorMessages.DisplayDueDate)]
        [Required(ErrorMessage = AssignmentInputErrorMessages.DueDateRequired)]
        [DataType(DataType.Date, ErrorMessage = AssignmentInputErrorMessages.DueDateRequired)]
        public DateTime DueDate { get; set; }
    }
}
