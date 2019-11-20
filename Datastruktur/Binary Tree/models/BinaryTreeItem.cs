using System;
using System.Collections.Generic;
using System.Text;

namespace Binary_Tree.models
{
    class BinaryTreeItem
    {
        public int Item { get; set; }

        public BinaryTreeItem Right { get; set; }

        public BinaryTreeItem Left { get; set; }

        public int Counter { get; set; }

        public BinaryTreeItem() : this(0, null,null, 0) { }
        public BinaryTreeItem(int item, BinaryTreeItem right, BinaryTreeItem left, int counter)
        {
            this.Item = item;
            this.Right  = right ;
            this.Left  = left ;
            this.Counter = counter;
        }

        public override string ToString()
        {
            return this.Item.ToString();
        }
    }
}
