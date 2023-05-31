namespace PharmaFlow.Web.Areas.Pharmacist.ViewModels.MedicalFacilities;

public class MedicalFacilityContactViewModel
{
    public Guid ID { get; set; }

    public Guid CotnactID { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public Guid PositionID { get; set; }

    public string PositionName { get; set; } = null!;

    public string DropDownText => $"{FirstName} {LastName} - {PositionName} - ID:{ID}";
}
