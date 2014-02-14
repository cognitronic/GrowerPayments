using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpine.Core.Domain.Assessment;
using System.Web.Mvc;


namespace Alpine.Controllers.ViewModels.Assessments
{
    public class AssessmentsView
    {
        public AssessmentsView()
        {
            this.Assessments = new List<IAssessment>();
        }
        public IList<IAssessment> Assessments { get; set; }
        public IAssessment SelectedAssessment { get; set; }
        public bool CanRunSetup { get; set; }
    }
}
