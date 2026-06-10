using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckManagementSystem
{
    public class UploadMicrEntites
    {
        public int Ex_micr { get; set; }
        public string Location { get; set; }
        public int Update_micr { get; set; }
        public int Branch_master_gid { get; set; }

    }
    public class GetUploadMicrEntites
    {
        public int GetEx_micr { get; set; }
    }
}
