﻿using System.Collections.Generic;

namespace Vault.Core.Entities
{
    public class Book : IEntity
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string Name { get; set; }
        public bool IsAvailable { get; set; }
        public Location Location { get; set; }

        //public virtual ICollection<Picture> Pictures { get; set; }
    }
}
