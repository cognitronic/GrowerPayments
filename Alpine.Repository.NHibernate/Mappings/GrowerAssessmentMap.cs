using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpine.Core.Domain.Grower;
using FluentNHibernate.Mapping;
using Alpine.Core.Domain.Assessment;

namespace Alpine.Repository.NHibernate.Mappings
{
    public class GrowerAssessmentMap : ClassMap<GrowerAssessment>
    {
        public GrowerAssessmentMap()
        {
            Id(x => x.ID);
            Map(x => x.AssessmentID);
            Map(x => x.ChangedBy);
            Map(x => x.CropYear);
            Map(x => x.DateCreated);
            Map(x => x.EnteredBy);
            Map(x => x.GrowerID);
            Map(x => x.LastUpdated);
            References<Assessment>(x => x.Assessment)
                .Column("AssessmentID")
                .NotFound
                .Ignore()
                .Not.Update()
                .Not.Insert();
        }
    }
}
