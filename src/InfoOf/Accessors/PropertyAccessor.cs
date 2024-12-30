namespace System.Reflection {
    public class PropertyAccessor {
        public Type EntityType { get; }
        public Type PropertyType { get; }
        public PropertyInfo Property { get; }

        public PropertyAccessor(PropertyInfo Property) {

            var DeclaringType = Property.DeclaringType;

            if (DeclaringType is null) {
                throw new Exception();
            }

            this.EntityType = DeclaringType;

            this.Property = Property;
            this.PropertyType = Property.PropertyType;

        }

        public PropertyAccessor(Type EntityType, PropertyInfo Property) {
            this.EntityType = EntityType;

            this.Property = Property;
            this.PropertyType = Property.PropertyType;

        }
    }





}
