namespace System.Reflection {

    public static class InfoOf {
        public static TypeAccessor Type(Type Type) {
            return new TypeAccessor(Type);
        }

        public static TypeAccessor<T> Type<T>() {
            return new TypeAccessor<T>();
        }

        public static PropertyAccessor Property(PropertyInfo Property) {
            return new PropertyAccessor(Property);
        }

        public static FieldAccessor Field(FieldInfo Property) {
            return new FieldAccessor(Property);
        }

    }



}
