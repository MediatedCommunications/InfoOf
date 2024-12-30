namespace System.Reflection {
    public class PropertyAccessor<TEntity> : PropertyAccessor {
        public PropertyAccessor(PropertyInfo Property) : base(typeof(TEntity), Property) {

        }
    }




}
