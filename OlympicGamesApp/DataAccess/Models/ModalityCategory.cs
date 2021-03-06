﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlympicGamesApp.DataAccess.Models
{
    public class ModalityCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Modality> Modalities { get; set; }

        public ModalityCategory()
        {
            Modalities = new List<Modality>();
        }

    }
}
