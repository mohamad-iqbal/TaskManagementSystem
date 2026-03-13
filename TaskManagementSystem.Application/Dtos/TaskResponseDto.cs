using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystem.Application.Dtos
{
    public class TaskResponseDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description {  get; set; } = string.Empty;
        public string Status {  get; set; } = string.Empty;
        public string ProjectName {  get; set; } = string.Empty;
        public string AssignedTo {  get; set; } = string.Empty;
        public DateTime DueDate { get; set; }
    }
}
