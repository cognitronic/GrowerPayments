﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpine.Services.ViewModels;

namespace Alpine.Services.Messaging.GrowerService
{
    public class GrowerAssessmentResponse : Response
    {
        public GrowerAssessmentResponse()
        {
            View = new GrowerAssessmentView();
        }
        public GrowerAssessmentView View { get; set; }
    }
}
