using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Airbnb.Domain.Comparers;

public class OrderExpressionComparer<TSource> : IComparer<(Expression<Func<TSource, bool>> keySelector, bool isAscending)>
{
    public int Compare((Expression<Func<TSource, bool>> keySelector, bool isAscending) x, (Expression<Func<TSource, bool>> keySelector, bool isAscending) y)
    {
        if(ReferenceEquals(x.keySelector, y.keySelector)) return 0;
        if(ReferenceEquals(null, x.keySelector)) return 1;
        if (ReferenceEquals(null, y.keySelector)) return -1;

        var keySelectorComparison = string.Compare(x.keySelector.ToString(), y.keySelector.ToString(), StringComparison.Ordinal);

        return keySelectorComparison != 0 
            ? keySelectorComparison
            : Comparer<bool>.Default.Compare(x.isAscending, y.isAscending);
    }
}