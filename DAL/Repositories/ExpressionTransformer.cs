using System;
using System.Linq.Expressions;

namespace DAL.Repositories
{
    public static class ExpressionTransformer<TFrom, TTo>
    {
        public class Visitor : ExpressionVisitor
        {
            private readonly ParameterExpression _parameter;

            public Visitor(ParameterExpression parameter)
            {
                _parameter = parameter;
            }

            protected override Expression VisitParameter(ParameterExpression node)
            {
                return _parameter;
            }
        }

        public static Expression<Func<TTo, bool>> Tranform(Expression<Func<TFrom, bool>> expression)
        {
            var parameter = Expression.Parameter(typeof(TTo));
            var body = new Visitor(parameter).Visit(expression.Body);
            return Expression.Lambda<Func<TTo, bool>>(body, parameter);
        }
    }
}
