using System;
using System.Collections.Generic;

namespace Napolina.Data
{
    public partial class Member
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Member()
        {
            this.Requests = new HashSet<Request>();
        }

        public int Id { get; set; }
        public string AlexaUserId { get; set; }
        public int RequestCount { get; set; }
        public System.DateTime LastRequestDate { get; set; }
        public System.DateTime CreatedDate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Request> Requests { get; set; }
    }
}
