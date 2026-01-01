namespace SWMS.Models;

public class Report
{
    public int ReportId { get; set; }          
    public string WasteType { get; set; } = ""; 
    public string Description { get; set; } = "";

    public double? Latitude { get; set; }      
    public double? Longitude { get; set; }    

   
    public int UserAccountId { get; set; }
    public UserAccount? UserAccount { get; set; } 
}
