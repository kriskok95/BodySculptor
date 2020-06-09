﻿namespace BodySculptor.API.Data.Models
{
    using System;

    public abstract class BaseModel<T>
    {
        public T Id { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        public DateTime? ModifiedOn { get; set; }
    }
}
