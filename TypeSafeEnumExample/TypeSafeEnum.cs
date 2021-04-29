using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace TypeSafeEnumExample
{
    public abstract class TypeSafeEnum
    {
        public int Value { get; }
        public string Name { get; }
        
        protected TypeSafeEnum(int value, string name)
        {
            Value = value;
            Name = !string.IsNullOrEmpty(name) ? name : throw new ArgumentNullException(nameof(name));
        }

        protected static IEnumerable<TypeSafeEnum> GetAll<T>() where T : TypeSafeEnum
        {
            return typeof(T).GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly)
                .Select(f => f.GetValue(null))
                .Cast<T>();
        }

        public override string ToString() => Name;

        public override bool Equals(object obj)
        {
            if (obj is not TypeSafeEnum other) return false;

            return GetType() == obj.GetType()
                   && Value == other.Value;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Value, Name);
        }
    }

    public abstract class TypeSafeEnum<T> : TypeSafeEnum where T : TypeSafeEnum<T>
    {
        protected TypeSafeEnum(int value, string name) : base(value, name) {}
        
        public static IEnumerable<TypeSafeEnum<T>> GetAll()
        {
            return GetAll<T>() as IEnumerable<TypeSafeEnum<T>>;
        }
    }
}