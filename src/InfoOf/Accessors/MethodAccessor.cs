namespace System.Reflection {
    public class MethodAccessor {
        public Type EntityType { get; }
        public Type ReturnType { get; }
        public MethodInfo Method { get; }

        public MethodAccessor(MethodInfo Method) {

            var DeclaringType = Method.DeclaringType;

            if (DeclaringType is null) {
                throw new Exception();
            }

            this.EntityType = DeclaringType;

            this.Method = Method;
            this.ReturnType = Method.ReturnType;

        }

        public MethodAccessor(Type EntityType, MethodInfo Method) {
            this.EntityType = EntityType;

            this.Method = Method;
            this.ReturnType = Method.ReturnType;

        }
    }





}
