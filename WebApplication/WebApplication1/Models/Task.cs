using Microsoft.EntityFrameworkCore;

namespace ModelTask.Models
{
    public class Task
    {
        public string taskName { get; set; }
        public int responsableUserID { get; set; }
        public DateTime startDate { get; set; }
        public DateTime finalDate { get; set; }
        public int taskID { get; set; }
        public string? observation { get; set; }
        public int projectID { get; set; }
    }
}