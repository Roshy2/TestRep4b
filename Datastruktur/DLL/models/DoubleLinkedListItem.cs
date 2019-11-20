using System;
using System.Collections.Generic;
using System.Text;

namespace DLL.models
{
    class DoubleLinkedListItem<T> where T : class
    {
        public T Item { get; set; }

        //Referenz auf das nächste Item
        public DoubleLinkedListItem<T> NextItem { get; set; }

        //Referenz auf das vorhärige Item
        public DoubleLinkedListItem<T> PreviousItem { get; set; }

        //ctor
        public DoubleLinkedListItem() : this(null, null, null) {}

        public DoubleLinkedListItem(T Item, DoubleLinkedListItem<T> nextItem, DoubleLinkedListItem<T> previousItem)
        {
            this.Item = Item;
            this.NextItem = nextItem;
            this.PreviousItem = previousItem;
        }

        public override string ToString()
        {
            return this.Item.ToString();
        }
    }
}
