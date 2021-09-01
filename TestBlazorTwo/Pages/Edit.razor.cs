using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestBlazorTwo.Model;
using TestBlazorTwo.ViewModels;

namespace TestBlazorTwo.Pages
{
    public partial class Edit
    {
        private Template template;
        private Tree tree;
        private Tree dropTargetTree;

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            await RefreshTree();
        }

        public async Task AcceptedItem(Tree tree)
        {
            dropTargetTree = tree;
        }

        public async Task OnDropped(Tree tree)
        {
            // Get the tree item that has been dragged
            var draggedItem = template.items.Where(i => i.Id == tree.Id).FirstOrDefault();

            // Get the item that has been dropped on
            var dropTargetItem = template.items.Where(i => i.Id == dropTargetTree.Id).FirstOrDefault();
        }

        private async Task RefreshTree()
        {
            // Hard coded test data

            #region the template
            template = new Template
            {
                name = "Paul Test Nested Sections",
                type = "template",
                template_id = Guid.NewGuid().ToString()
            };
            #endregion

            #region page one
            var pageOne = new Item
            {
                item_id = Guid.NewGuid().ToString(),
                type = "section",
                label = "Page One",
                parent_id = null,
                order_id = 1
            };
            template.items.Add(pageOne);

            template.items.Add(new Item {
                item_id = Guid.NewGuid().ToString(),
                type = "textsingle",
                label = "Question A",
                parent_id = pageOne.item_id,
                order_id = 1
            });

            template.items.Add(new Item
            {
                item_id = Guid.NewGuid().ToString(),
                type = "textsingle",
                label = "Question B",
                parent_id = pageOne.item_id,
                order_id = 2
            });

            #region sub section Y
            var sectionY = new Item
            {
                item_id = Guid.NewGuid().ToString(),
                type = "category",
                label = "Section Y",
                parent_id = pageOne.item_id,
                order_id = 3
            };
            template.items.Add(sectionY);

            template.items.Add(new Item
            {
                item_id = Guid.NewGuid().ToString(),
                type = "textsingle",
                label = "Question Y1",
                parent_id = sectionY.item_id,
                order_id = 1
            });

            template.items.Add(new Item
            {
                item_id = Guid.NewGuid().ToString(),
                type = "textsingle",
                label = "Question Y2",
                parent_id = sectionY.item_id,
                order_id = 2
            });
            #endregion

            template.items.Add(new Item
            {
                item_id = Guid.NewGuid().ToString(),
                type = "textsingle",
                label = "Question C",
                parent_id = pageOne.item_id,
                order_id = 4
            });

            template.items.Add(new Item
            {
                item_id = Guid.NewGuid().ToString(),
                type = "textsingle",
                label = "Question D",
                parent_id = pageOne.item_id,
                order_id = 5
            });
            #endregion

            #region page two
            var pageTwo = new Item
            {
                item_id = Guid.NewGuid().ToString(),
                type = "section",
                label = "Page Two",
                parent_id = null,
                order_id = 2
            };
            template.items.Add(pageTwo);

            template.items.Add(new Item
            {
                item_id = Guid.NewGuid().ToString(),
                type = "textsingle",
                label = "Question 1",
                parent_id = pageTwo.item_id,
                order_id = 1
            });

            template.items.Add(new Item
            {
                item_id = Guid.NewGuid().ToString(),
                type = "textsingle",
                label = "Question 2",
                parent_id = pageTwo.item_id,
                order_id = 2
            });

            #region sub section X
            var sectionX = new Item
            {
                item_id = Guid.NewGuid().ToString(),
                type = "category",
                label = "Section X",
                parent_id = pageTwo.item_id,
                order_id = 3
            };
            template.items.Add(sectionX);

            template.items.Add(new Item
            {
                item_id = Guid.NewGuid().ToString(),
                type = "textsingle",
                label = "Question X1",
                parent_id = sectionX.item_id,
                order_id = 1
            });

            template.items.Add(new Item
            {
                item_id = Guid.NewGuid().ToString(),
                type = "textsingle",
                label = "Question X2",
                parent_id = sectionX.item_id,
                order_id = 2
            });
            #endregion

            template.items.Add(new Item
            {
                item_id = Guid.NewGuid().ToString(),
                type = "textsingle",
                label = "Question 3",
                parent_id = pageTwo.item_id,
                order_id = 4
            });

            template.items.Add(new Item
            {
                item_id = Guid.NewGuid().ToString(),
                type = "textsingle",
                label = "Question 4",
                parent_id = pageTwo.item_id,
                order_id = 5
            });
            #endregion

            tree = Helpers.TreeBuilder.BuildTree(template.items);

            StateHasChanged();
        }
    }
}
