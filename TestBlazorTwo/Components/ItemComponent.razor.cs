using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestBlazorTwo.ViewModels;

namespace TestBlazorTwo.Components
{
    public partial class ItemComponent
    {
        //[CascadingParameter]
        //public Template_Data Template_Data { get; set; }

        [Parameter]
        public Tree Tree { get; set; }

        [Parameter]
        public int Level { get; set; }

        [Parameter]
        public EventCallback<Tree> AcceptedItem { get; set; }

        [Parameter]
        public EventCallback<Tree> OnDropped { get; set; }

        private bool Accepts(Tree draggedItem, Tree underneathItem)
        {
            if (underneathItem != null)
            {
                AcceptedItem.InvokeAsync(underneathItem);
            }

            return true;
        }
    }
}
