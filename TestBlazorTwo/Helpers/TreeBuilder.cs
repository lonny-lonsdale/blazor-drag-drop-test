using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestBlazorTwo.Model;
using TestBlazorTwo.ViewModels;

namespace TestBlazorTwo.Helpers
{
    public static class TreeBuilder
    {
        public static Tree BuildTree(IEnumerable<Item> nodes)
        {
            if (nodes == null) return new Tree();

            var nodeList = nodes.ToList();

            var tree = new Tree();

            BuildTree(tree, nodeList);

            return tree;
        }

        private static void BuildTree(Tree tree, IList<Item> descendants)
        {
            var children = descendants.Where(node => node.parent_id == tree.Item_Id).ToArray();

            var orderId = 1;

            foreach (var child in children.OrderBy(o => o.order_id))
            {
                child.order_id = orderId;
                var branch = Map(child);
                tree.Add(branch);
                descendants.Remove(child);

                orderId += 1;
            }

            foreach (var branch in tree.Children)
            {
                BuildTree(branch, descendants);
            }
        }

        private static Tree Map(Item node)
        {
            return new Tree
            {
                Id = node.Id,
                //IsActive = node.IsActive,
                Item_Id = node.item_id,
                Text = node.label,
                Parent_Id = node.parent_id,
                Type = node.type,
                Order_Id = node.order_id,
                //Options = node.options,
                Placeholder = node.type == "question" ? "Type question" : "Type section title"
            };
        }
    }
}
