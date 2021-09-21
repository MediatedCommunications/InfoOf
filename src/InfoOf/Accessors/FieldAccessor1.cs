namespace System.Reflection {
    public class FieldAccessor<TEntity> : FieldAccessor {
        public FieldAccessor(FieldInfo Field) : base(typeof(TEntity), Field) {

        }
    }




}
