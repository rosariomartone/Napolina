using System;
using System.Collections.Generic;
using System.Text;

namespace Napolina.Data
{
    public partial class Request
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public string SessionId { get; set; }
        public string AppId { get; set; }
        public string RequestId { get; set; }
        public string UserId { get; set; }
        public System.DateTime Timestamp { get; set; }
        public string Intent { get; set; }
        public string Slots { get; set; }

        private List<KeyValuePair<string, string>> slotsList = new List<KeyValuePair<string, string>>();

        public List<KeyValuePair<string, string>> SlotsList
        {
            get
            {
                return slotsList;
            }
            set
            {
                slotsList = value;

                var slots = new StringBuilder();

                slotsList.ForEach(s => slots.AppendFormat("{0}|{1},", s.Key, s.Value));

                Slots = slots.ToString().TrimEnd(',');
            }
        }

        public bool IsNew { get; set; }
        public string Version { get; set; }
        public string Type { get; set; }
        public string Reason { get; set; }
        public System.DateTime DateCreated { get; set; }

        public virtual Member Member { get; set; }
    }
}
