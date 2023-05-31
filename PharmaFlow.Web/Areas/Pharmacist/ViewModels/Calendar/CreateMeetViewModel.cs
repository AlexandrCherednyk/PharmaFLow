namespace PharmaFlow.Web.Areas.Pharmacist.ViewModels.Calendar;

public record CreateMeetViewModel
{
    [Required]
    public DateTime Start { get; set; }

    [Required]
    public DateTime End { get; set; }

    [Required]
    public Guid StaffTargetID { get; set; }
}
