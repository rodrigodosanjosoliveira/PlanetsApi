using System;
using System.Collections.Generic;

namespace PlanetsApi.Models
{
    public abstract class EntityBase : IEquatable<EntityBase>
    {
        public int Id { get; set; }

        public override bool Equals(object obj)
        {
            return obj is EntityBase @base &&
                   Id == @base.Id;
        }

        public bool Equals(EntityBase other)
        {
            return other != null &&
                   Id == other.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

        public static bool operator ==(EntityBase left, EntityBase right)
        {
            return EqualityComparer<EntityBase>.Default.Equals(left, right);
        }

        public static bool operator !=(EntityBase left, EntityBase right)
        {
            return !(left == right);
        }
    }
}
