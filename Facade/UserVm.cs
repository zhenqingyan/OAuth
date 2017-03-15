using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OAuth.Facade
{
    public class UserVm
    {
        public string RowGuid { get; set; }
        public string LogonName { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public int IsValid { get; set; }
        public int IsDel { get; set; }
        public string Creator { get; set; }
        public DateTime CreateTime { get; set; }
        public string Modifier { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
