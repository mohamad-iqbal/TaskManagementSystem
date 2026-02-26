using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystem.Core.Entities
{
    public class TaskItem : BaseEntity
    {
        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string Status { get; set; } = "Todo";  // Todo, InProgress, Done

        public int ProjectId { get; set; }

        public int CreatedByUserId { get; set; }

        public int AssignedToUserId { get; set; }

        public DateTime DueDate { get; set; }


        // Navigation Properties
        public Project Project { get; set; } = null!;

        public User CreatedByUser { get; set; } = null!;

        public User AssignedToUser { get; set; } = null!;

    }
}
