﻿using System;
using Project_6.Dtos.Interfaces;

namespace Project_6.Dtos.ProvidedServiceDtos
{
    public class ProvidedServiceUpdateDto : IDto
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string ImagePath { get; set; }

        public string Description { get; set; }
        
    }
}