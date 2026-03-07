using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystem.Domain.Enums
{
    public enum TaskStatus //enum adalah tipe data yang digunakan untuk menyimpan sekumpulan konstanta bernama dengan nilai numerik.
    {
        Pending = 0,
        InProgress = 1,
        Completed = 2
    }
}
