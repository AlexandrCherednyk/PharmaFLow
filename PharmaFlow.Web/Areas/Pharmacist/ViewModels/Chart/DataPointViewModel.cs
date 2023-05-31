using System.Runtime.Serialization;

namespace PharmaFlow.Web.Areas.Pharmacist.ViewModels.Chart;

[DataContract]
public class DataPointViewModel
{
    public DataPointViewModel(double x, double y)
    {
        this.X = x;
        this.Y = y;
    }

    [DataMember(Name = "x")]
    public double? X = null;

    [DataMember(Name = "y")]
    public double? Y = null;
}
