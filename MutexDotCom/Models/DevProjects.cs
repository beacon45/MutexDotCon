namespace MutexDotCom.Models
{
    public class DevProjects
    {
        public int ProjectId { get; set; }
        public Project Project { get; set; }

        public int DevId {  get; set; }
        public Developer Developer { get; set; }
    }
}
