﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpine.Core.Domain.Assessment;
using System.Runtime.Serialization;

namespace Alpine.Services.Messaging.AssessmentService
{
    [Serializable]
    public class DeleteAssessmentRequest
    {
        public string AssessmentID { get; set; }
        public IAssessment Assessment { get; set; }
    }
}
