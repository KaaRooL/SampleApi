/* Copyright (C) 2023 Patco, LLC - All Rights Reserved. You may not use, distribute, make copy of, and modify this code without express written permission by Patco, LLC. */

using Core.Base.Type.Exceptions;

namespace Core.Base.Type
{
    public abstract class GuidId : IEquatable<GuidId>
    {
        public Guid Id { get; }

        protected GuidId(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new InvalidTypeIdException();
            }

            Id = id;
        }
        public bool Equals(GuidId other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            return ReferenceEquals(this, other) || Id.Equals(other.Id);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            return obj.GetType() == GetType() && Equals((GuidId) obj);
        }

        public override int GetHashCode() => Id.GetHashCode();

        public bool IsEmpty() => Id == Guid.Empty;

        public static bool operator ==(GuidId a, GuidId b)
        {
            if (ReferenceEquals(a, b))
            {
                return true;
            }

            if (a is not null && b is not null)
            {
                return a.Id.Equals(b.Id);
            }

            return false;
        }

        public static implicit operator Guid(GuidId guidId)
            => guidId.Id;

        public static bool operator !=(GuidId a, GuidId b) => !(a == b);

        public override string ToString() => Id.ToString();
    }
}