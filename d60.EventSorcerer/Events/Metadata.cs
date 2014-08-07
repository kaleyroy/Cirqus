﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using d60.EventSorcerer.Extensions;
using d60.EventSorcerer.Numbers;

namespace d60.EventSorcerer.Events
{
    /// <summary>
    /// Metadata collection that stores a bunch of key-value pairs that can be used for
    /// cross-cutting concerns like e.g. handling multi-tenancy, auditing, etc.
    /// </summary>
    public class Metadata : Dictionary<string, object>
    {
        internal void Merge(Metadata otherMeta)
        {
            foreach (var kvp in otherMeta)
            {
                if (ContainsKey(kvp.Key)) continue;

                this[kvp.Key] = kvp.Value;
            }
        }

        internal void TakeFromAttributes(ICustomAttributeProvider provider)
        {
            foreach (var meta in provider.GetAttributes<MetaAttribute>())
            {
                if (ContainsKey(meta.Key)) continue;

                this[meta.Key] = meta.Value;
            }
        }

        public override string ToString()
        {
            var lines = new[] { "Metadata:" }
                .Concat(this.Select(kvp => string.Format("    {0}: {1}", kvp.Key, kvp.Value)));

            return string.Join(Environment.NewLine, lines);
        }
    }
}