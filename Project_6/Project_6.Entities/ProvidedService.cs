using System;

namespace Project_6.Entities
{
    public class ProvidedService : BaseEntity
    {
        public string Title { get; set; }

        public string ImagePath { get; set; }

        public string Description { get; set; }

        public DateTime CreatedTime { get; set; }
    }
}