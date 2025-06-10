using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalshinonApp.Models
{
    // This class represents an intel report
    internal class Report
    {
        public int ReporterId { get; set; }
        public int TargetId { get; set; }
        public string Text { get; set; }
        public Report(int reporterId, int targetId, string text)
        {
            this.ReporterId = reporterId;
            this.TargetId = targetId;
            this.Text = text;
        }
    }
}
