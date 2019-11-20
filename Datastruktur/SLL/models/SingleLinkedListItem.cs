using System;
using System.Collections.Generic;
using System.Text;

namespace SLL.models
{
    class SingleLinkedListItem<T> where T : class { 
    
    public T Item { get; set; }
        // Referenz auf das nächstem Item
    public SingleLinkedListItem<T> NextItem{get; set;}

    //ctor
    public SingleLinkedListItem() : this(null, null){}

    public SingleLinkedListItem(T Item, SingleLinkedListItem<T> nextItem)
    {
        this.Item = Item;
        this.NextItem = nextItem;
    }

    public override string ToString()
    {
        return this.Item.ToString();
    }

    }
}

