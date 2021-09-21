namespace System.Reflection {
    public class FieldAccessor {
        public Type EntityType { get; }
        public Type FieldType { get; }
        public FieldInfo Field { get; }

        public FieldAccessor(FieldInfo Field) {

            var DeclaringType = Field.DeclaringType;

            if (DeclaringType is null) {
                throw new Exception();
            }

            this.EntityType = DeclaringType;

            this.Field = Field;
            this.FieldType = Field.FieldType;

        }

        public FieldAccessor(Type EntityType, FieldInfo Field) {
            this.EntityType = EntityType;

            this.Field = Field;
            this.FieldType = Field.FieldType;

        }
    }





}
