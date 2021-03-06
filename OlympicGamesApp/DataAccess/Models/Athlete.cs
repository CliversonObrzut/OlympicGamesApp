﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlympicGamesApp.DataAccess.Models
{
    public class Athlete
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleNames { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int CountryId { get; set; }
        public int GenderId { get; set; }
        public int GoldMedal { get; set; }
        public int SilverMedal { get; set; }
        public int BronzeMedal { get; set; }
        public int? PictureId { get; set; }
        public virtual Picture Picture { get; set; }
        public virtual Country Country { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual List<Modality> Modalities { get; set; }
        public virtual List<Customer> Customers { get; set; }

        public Athlete()
        {
            Modalities = new List<Modality>();
            Customers = new List<Customer>();
        }

        
    }
}
