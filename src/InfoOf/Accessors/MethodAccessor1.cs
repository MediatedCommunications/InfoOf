namespace System.Reflection {
    public class MethodAccessor<TEntity> : MethodAccessor {
        public MethodAccessor(MethodInfo Method) : base(typeof(TEntity), Method) {

        }
    }




}
