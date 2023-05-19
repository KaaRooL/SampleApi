/* Copyright (C) 2022 Patco, LLC - All Rights Reserved. You may not use, distribute, make copy of, and modify this code without express written permission by Patco, LLC. */

using Core.Base.Type.Exceptions;

namespace Core.Base.Type
{
	public class NullableIntegerId : IEquatable<NullableIntegerId>
	{
		public int? Id { get; }

		public NullableIntegerId(int? id)
		{
			if (id < 0)
			{
				throw new InvalidTypeIdException();
			}

			Id = id;
		}

		public bool Equals(NullableIntegerId other)
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

			return obj.GetType() == GetType() && Equals((NullableIntegerId)obj);
		}

		public override int GetHashCode() => Id.GetHashCode();


		public static bool operator ==(NullableIntegerId a, NullableIntegerId b)
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

		public static implicit operator int?(NullableIntegerId integerId)
			=> integerId.Id;

		public static bool operator !=(NullableIntegerId a, NullableIntegerId b) => !(a == b);

		public override string ToString() => Id.ToString();

	}
}