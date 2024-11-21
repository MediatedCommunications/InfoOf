using System.Linq.Expressions;

namespace System.Reflection {
    public static class FieldCompiler {
        public static Func<object, object?> ObjectGetter(this FieldAccessor This) {
            var Method = This.Field;

            var Instance = Expression.Parameter(typeof(object), "i");
            var InstanceCast = Expression.Convert(Instance, This.EntityType);

            var GetterCall = Expression.Field(InstanceCast, Method);
            var ReturnCast = Expression.Convert(GetterCall, typeof(object));

            var tret = Expression.Lambda(ReturnCast, Instance).Compile();
            var ret = (Func<object, object?>)tret;

            return ret;
        }

        public static Action<object, object?> ObjectSetter(this FieldAccessor This) {
            var Method = This.Field;

            var Instance = Expression.Parameter(typeof(object), "i");
            var InstanceCast = Expression.Convert(Instance, This.EntityType);

            var Argument = Expression.Parameter(typeof(object), "a");
            var ArgumentCast = Expression.Convert(Argument, This.FieldType);

            var SetterCall = Expression.Assign(Expression.Field(InstanceCast, Method), ArgumentCast);
            var tret = Expression.Lambda<Action<object, object?>>(SetterCall, Instance, Argument).Compile();
            var ret = tret;

            return ret;
        }

        public static Func<TEntity, object?> EntityGetter<TEntity>(this FieldAccessor<TEntity> This) {
            var Method = This.Field;

            var Instance = Expression.Parameter(typeof(TEntity), "i");

            var GetterCall = Expression.Field(Instance, Method);
            var GetterCast = Expression.Convert(GetterCall, typeof(object));

            var tret = Expression.Lambda(GetterCast, Instance).Compile();
            var ret = (Func<TEntity, object?>)tret;

            return ret;
        }

        public static Action<TEntity, object?> EntitySetter<TEntity>(this FieldAccessor<TEntity> This) {
            var Method = This.Field;

            var Instance = Expression.Parameter(typeof(TEntity), "i");
            var Argument = Expression.Parameter(typeof(object), "a");
            var ArgumentCast = Expression.Convert(Argument, This.FieldType);

            var SetterCall = Expression.Assign(Expression.Field(Instance, Method), ArgumentCast);
            var tret = Expression.Lambda<Action<TEntity, object?>>(SetterCall, Instance, Argument).Compile();
            var ret = tret;

            return ret;
        }



        public static Func<TEntity, TField> ValueGetter<TEntity, TField>(this FieldAccessor<TEntity, TField> This) {
            var Method = This.Field;

            var Instance = Expression.Parameter(typeof(TEntity), "i");

            var GetterCall = Expression.Field(Instance, Method);

            var tret = Expression.Lambda(GetterCall, Instance).Compile();
            var ret = (Func<TEntity, TField>)tret;

            return ret;
        }


        public static Action<TEntity, TField> ValueSetter<TEntity, TField>(this FieldAccessor<TEntity, TField> This) {
            var Method = This.Field;
            if (Method is null) {
                throw new ArgumentException("Unable to find setter");
            }

            var Instance = Expression.Parameter(typeof(TEntity), "i");
            var Argument = Expression.Parameter(typeof(TField), "a");

            var SetterCall = Expression.Assign(Expression.Field(Instance, Method), Argument);
            var tret = Expression.Lambda<Action<TEntity, TField>>(SetterCall, Instance, Argument).Compile();
            var ret = tret;

            return ret;
        }

    }


}
