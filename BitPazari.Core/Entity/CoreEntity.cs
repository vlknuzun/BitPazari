using BitPazari.Core.Entity.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BitPazari.Core.Entity
{
   public class CoreEntity : IEntity<int>
    {
        public CoreEntity()
        {
            this.Status = Status.Active;
            this.CreatedDate = DateTime.Now;
            this.CreatedUserName = WindowsIdentity.GetCurrent().Name;
            this.CreatedComputerName = Environment.MachineName;
            this.CreatedIp = "123";
            this.CreatedBy = 1;
        }

        public int Id { get; set; }
        public int MasterID { get; set; }
        public Status Status { get; set; }

        public DateTime? CreatedDate { get; set; }
        public string CreatedComputerName { get; set; }
        public string CreatedIp { get; set; }
        public string CreatedUserName { get; set; }
        public int? CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }
        public string ModifiedComputerName { get; set; }
        public string ModifiedIp { get; set; }
        public string ModifiedUserName { get; set; }
        public int? ModifiedBy { get; set; }
    }
}
