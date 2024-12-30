namespace System.Reflection {
    public class TypeAccessor {
        public Type EntityType { get; }

        public TypeAccessor(Type EntityType) {
            this.EntityType = EntityType;
        }

        public virtual PropertyAccessor Property(string Name) {
            var Prop = EntityType.GetProperty(Name, BindingFlags.FlattenHierarchy | BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            if (Prop is null) {
                throw new Exception("Unable to find property");
            }


            return Property(Prop);
        }

        public virtual PropertyAccessor Property(PropertyInfo Property) {
            return new PropertyAccessor(EntityType, Property);
        }

        public virtual FieldAccessor Field(string Name) {
            var Prop = EntityType.GetField(Name, BindingFlags.FlattenHierarchy | BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            if (Prop is null) {
                throw new Exception("Unable to find field");
            }


            return Field(Prop);
        }

        public virtual FieldAccessor Field(FieldInfo Field) {
            return new FieldAccessor(EntityType, Field);
        }
    }







}
