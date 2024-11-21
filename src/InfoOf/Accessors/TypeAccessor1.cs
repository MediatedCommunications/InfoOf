using System.Linq.Expressions;

namespace System.Reflection {
    public class TypeAccessor<TEntity> : TypeAccessor {
        public TypeAccessor() : base(typeof(TEntity)) {

        }

#if NET5_0_OR_GREATER

        public override PropertyAccessor<TEntity> Property(PropertyInfo Property) {
            return new PropertyAccessor<TEntity>(Property);
        }

        public override FieldAccessor<TEntity> Field(FieldInfo Field) {
            return new FieldAccessor<TEntity>(Field);
        }

#endif

        public PropertyAccessor<TEntity, TProperty> Property<TProperty>(Expression<Func<TEntity, TProperty>> Expression) {
            var PropertyInfo = PropertyInfo<TProperty>(Expression);
            return new PropertyAccessor<TEntity, TProperty>(PropertyInfo);
        }

        private static PropertyInfo PropertyInfo<TProperty>(Expression<Func<TEntity, TProperty>> expression) {
            var member = GetMemberExpression(expression).Member;
            var property = member as PropertyInfo;
            if (property is null) {
                throw new MissingMemberException($@"Member with Name '{member.Name}' is not a property.");
            }

            return property;
        }

        public FieldAccessor<TEntity, TField> Field<TField>(Expression<Func<TEntity, TField>> Expression) {
            var FieldInfo = FieldInfo<TField>(Expression);
            return new FieldAccessor<TEntity, TField>(FieldInfo);
        }

        private static FieldInfo FieldInfo<TField>(Expression<Func<TEntity, TField>> expression) {
            var member = GetMemberExpression(expression).Member;
            var Field = member as FieldInfo;
            if (Field is null) {
                throw new MissingMemberException($@"Member with Name '{member.Name}' is not a Field.");
            }

            return Field;
        }

        public MethodAccessor<TEntity, TMethod> Method<TMethod>(Expression<Func<TEntity, TMethod>> Expression) {
            var MethodInfo = MethodInfo<TMethod>(Expression);
            return new MethodAccessor<TEntity, TMethod>(MethodInfo);
        }

        private static MethodInfo MethodInfo<TMethod>(Expression<Func<TEntity, TMethod>> expression) {
            var member = GetMethodExpression(expression).Method;
            var Field = member as MethodInfo;
            if (Field is null) {
                throw new MissingMemberException($@"Member with Name '{member.Name}' is not a method.");
            }

            return Field;
        }


        public MethodAccessor<TEntity> Method(Expression<Action<TEntity>> Expression) {
            var MethodInfo = TypeAccessor<TEntity>.MethodInfo(Expression);
            return new MethodAccessor<TEntity>(MethodInfo);
        }

        private static MethodInfo MethodInfo(Expression<Action<TEntity>> expression) {
            var member = GetMethodExpression(expression).Method;
            var Field = member as MethodInfo;
            if (Field is null) {
                throw new MissingMemberException($@"Member with Name '{member.Name}' is not a method.");
            }

            return Field;
        }

        private static MethodCallExpression GetMethodExpression(LambdaExpression Expression) {
            var ret = default(MethodCallExpression?);

            if (Expression.Body.NodeType == ExpressionType.Call) {
                ret = Expression.Body as MethodCallExpression;
            }

            if (ret is null) {
                throw new ArgumentException("Not a method call", nameof(Expression));
            }

            return ret;
        }



        private static MemberExpression GetMemberExpression(LambdaExpression Expression) {
            var ret = default(MemberExpression?);
            if (Expression.Body.NodeType == ExpressionType.Convert) {
                var body = (UnaryExpression)Expression.Body;
                ret = body.Operand as MemberExpression;
            } else if (Expression.Body.NodeType == ExpressionType.MemberAccess) {
                ret = Expression.Body as MemberExpression;
            }

            if (ret is null) {
                throw new ArgumentException("Not a member access", nameof(Expression));
            }

            return ret;
        }

    }







}
