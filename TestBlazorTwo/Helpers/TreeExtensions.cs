using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestBlazorTwo.ViewModels;

namespace TestBlazorTwo.Helpers
{
    public static class TreeExtensions
    {
        public static IEnumerable<Tree> Ancestors(this Tree value)
        {
            // an ancestor is the node self and any ancestor of the parent
            var ancestor = value;
            // post-order tree walker
            while (ancestor != null)
            {
                yield return ancestor;
                ancestor = ancestor.Parent;
            }
        }
    }
}
