﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlympicGamesApp.DataAccess.Models
{
    public class CompetitionPhase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<CompetitionEvent> CompetitionEvents { get; set; }

        public CompetitionPhase()
        {
            CompetitionEvents = new List<CompetitionEvent>();
        }
    }
}
