using System.Linq.Expressions;

namespace System.Reflection {
    public static class PropertyCompiler {
        public static Func<object, object?> ObjectGetter(this PropertyAccessor This) {
            var Method = This.Property.GetGetMethod(true);
            if (Method is null) {
                throw new ArgumentException("Unable to find getter");
            }

            var Instance = Expression.Parameter(typeof(object), "i");
            var InstanceCast = Expression.Convert(Instance, This.EntityType);

            var GetterCall = Expression.Call(InstanceCast, Method);
            var ReturnCast = Expression.Convert(GetterCall, typeof(object));

            var tret = Expression.Lambda(ReturnCast, Instance).Compile();
            var ret = (Func<object, object?>)tret;

            return ret;
        }

        public static Action<object, object?> ObjectSetter(this PropertyAccessor This) {
            var Method = This.Property.GetSetMethod(true);
            if (Method is null) {
                throw new ArgumentException("Unable to find setter");
            }

            var Instance = Expression.Parameter(typeof(object), "i");
            var InstanceCast = Expression.Convert(Instance, This.EntityType);

            var Argument = Expression.Parameter(typeof(object), "a");
            var ArgumentCast = Expression.Convert(Argument, This.PropertyType);

            var SetterCall = Expression.Call(InstanceCast, Method, ArgumentCast);
            var tret = Expression.Lambda(SetterCall, Instance, Argument).Compile();
            var ret = (Action<object, object?>)tret;

            return ret;
        }

        public static Func<TEntity, object?> EntityGetter<TEntity>(this PropertyAccessor<TEntity> This) {
            var Method = This.Property.GetGetMethod(true);
            if (Method is null) {
                throw new ArgumentException("Unable to find getter");
            }

            var Instance = Expression.Parameter(typeof(TEntity), "i");

            var GetterCall = Expression.Call(Instance, Method);
            var GetterCast = Expression.Convert(GetterCall, typeof(object));

            var tret = Expression.Lambda(GetterCast, Instance).Compile();
            var ret = (Func<TEntity, object?>)tret;

            return ret;
        }

        public static Action<TEntity, object?> EntitySetter<TEntity>(this PropertyAccessor<TEntity> This) {
            var Method = This.Property.GetSetMethod(true);
            if (Method is null) {
                throw new ArgumentException("Unable to find setter");
            }

            var Instance = Expression.Parameter(typeof(TEntity), "i");
            var Argument = Expression.Parameter(typeof(object), "a");
            var ArgumentCast = Expression.Convert(Argument, This.PropertyType);

            var SetterCall = Expression.Call(Instance, Method, ArgumentCast);
            var tret = Expression.Lambda(SetterCall, Instance, Argument).Compile();
            var ret = (Action<TEntity, object?>)tret;

            return ret;
        }



        public static Func<TEntity, TProperty> ValueGetter<TEntity, TProperty>(this PropertyAccessor<TEntity, TProperty> This) {
            var Method = This.Property.GetGetMethod(true);
            if (Method is null) {
                throw new ArgumentException("Unable to find getter");
            }

            var Instance = Expression.Parameter(typeof(TEntity), "i");

            var GetterCall = Expression.Call(Instance, Method);

            var tret = Expression.Lambda(GetterCall, Instance).Compile();
            var ret = (Func<TEntity, TProperty>)tret;

            return ret;
        }


        public static Action<TEntity, TProperty> ValueSetter<TEntity, TProperty>(this PropertyAccessor<TEntity, TProperty> This) {
            var Method = This.Property.GetSetMethod(true);
            if (Method is null) {
                throw new ArgumentException("Unable to find setter");
            }

            var Instance = Expression.Parameter(typeof(TEntity), "i");
            var Argument = Expression.Parameter(typeof(TProperty), "a");

            var SetterCall = Expression.Call(Instance, Method, Argument);
            var tret = Expression.Lambda(SetterCall, Instance, Argument).Compile();
            var ret = (Action<TEntity, TProperty>)tret;

            return ret;
        }

    }


}
