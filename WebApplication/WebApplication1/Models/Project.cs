using Microsoft.EntityFrameworkCore;

namespace ModelProject.Models
{
    public class Project
    {
        public int adminUserID { get; set; }
        public string projectName { get; set; }
        private int doneTasks { get; set; }
        public int projectID { get; set; }
        private static int nextID { get; set; }
    }
}