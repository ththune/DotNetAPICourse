namespace DotnetMinimalAPI.Models
{
    public partial class UserJobInfo
    {
        public int UserId { get; set; }
        public String JobTitle { get; set; } = string.Empty;
        public String Department { get; set; } = string.Empty;
        public UserJobInfo()
        {

        }
    }
}
