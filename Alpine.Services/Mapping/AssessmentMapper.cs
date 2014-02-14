using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpine.Services.ViewModels;
using Alpine.Core.Domain.Assessment;
using AutoMapper;


namespace Alpine.Services.Mapping
{
    public static class AssessmentMapper
    {
        public static AssessmentView ConvertToAssessmentView(this IAssessment assessment)
        {
            return Mapper.Map<IAssessment, AssessmentView>(assessment);
        }

        public static Assessment ConvertToAssessment(this AssessmentView view)
        {
            return Mapper.Map<AssessmentView, Assessment>(view);
        }

        public static IList<AssessmentView> ConvertToAssessmentViewList(this IList<IAssessment> assessments)
        {
            return Mapper.Map<IList<IAssessment>,IList<AssessmentView>>(assessments);
        }
    }
}
