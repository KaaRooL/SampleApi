/* Copyright (C) 2023 Patco, LLC - All Rights Reserved. You may not use, distribute, make copy of, and modify this code without express written permission by Patco, LLC. */

namespace Core.Base.Type.Exceptions
{
    internal class InvalidTypeIdException : Exception
    {
        private const string INVALID_TYPE_ID_EXCEPTION = "Id cannot be null or empty";
        public InvalidTypeIdException(Exception innerException) : base(INVALID_TYPE_ID_EXCEPTION, innerException)
        {
        }
        
        public InvalidTypeIdException() : base(INVALID_TYPE_ID_EXCEPTION)
        {
        }
    }
}