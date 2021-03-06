﻿using System;

namespace XimoSample.Domain.Exceptions
{
    public class DuplicateSystemTagException : Exception
    {
        internal DuplicateSystemTagException(string message)
            : base(message)
        {
        }

        internal static DuplicateSystemTagException Create(string tagName)
        {
            var message = $"A tag with the name '{tagName}' already exists for this account.";
            return new DuplicateSystemTagException(message);
        }
    }
}