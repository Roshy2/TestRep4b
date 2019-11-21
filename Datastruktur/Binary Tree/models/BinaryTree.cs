using System;
using System.Collections.Generic;
using System.Text;

namespace Binary_Tree.models
{
    class BinaryTree
    {
        public BinaryTreeItem _root;

        public BinaryTree()
        {
            _root = null;
        }

        public BinaryTree(int Item)
        {
            this._root = new BinaryTreeItem(Item, null, null, 1);
        }
        public int Tiktok;
        
        //Methode Add
        public bool Add(int itemToAdd)
        {
            if (itemToAdd == 0)
            {
                return false;
            }
            //Liste gibt es nicht
            if (this._root == null)
            {
                this._root = new BinaryTreeItem(itemToAdd, null, null, 1);
                return true;
            }

            //größer oder kleiner 
            BinaryTreeItem actItem = new BinaryTreeItem();
            actItem = _root;
            
            while (actItem != null)
            {
                if (itemToAdd < actItem.Item) {
                    if (actItem.Left == null) {
                        actItem.Left = new BinaryTreeItem(itemToAdd, null, null, 1);
                        return true;
                    }
                    else
                    {
                        actItem = actItem.Left;
                    }
                }
                else if (itemToAdd > actItem.Item) {
                    if (actItem.Right == null)
                    {
                        actItem.Right = new BinaryTreeItem(itemToAdd, null, null, 1);
                        return true;
                    }
                    else
                    {
                        actItem = actItem.Right;
                    }
                }
                else
                {
                    actItem.Counter++;
                    return true;
                }
            }
           //Hier war dei falsche Methode
                return false;
        }

        public bool AddRek(int itemToAdd, BinaryTreeItem actItem = null)
        {
            
            //Liste gibt es nicht
            if(this._root == null)
            {
                this._root = new BinaryTreeItem(itemToAdd, null, null, 1);
                return true;
            }
            //größer, kleiner, gleich vergleich
            if (actItem == null)
            {
                actItem = this._root;
            }

            if ((itemToAdd < actItem.Item)&& (actItem.Left !=null))
            {
                actItem = actItem.Left;
            }
            else if ((itemToAdd > actItem.Item)&& (actItem.Right != null))
            {
                actItem = actItem.Right;
            }


            if((actItem.Right == null)&&(itemToAdd > actItem.Item))
            {
                actItem.Right = new BinaryTreeItem(itemToAdd, null, null, 1);
                return true;
            }else if((actItem.Left == null)&& (itemToAdd < actItem.Item))
            {
                actItem.Left = new BinaryTreeItem(itemToAdd, null, null, 1);
                return true;
            }else if (actItem.Item.Equals(itemToAdd))
            {
                actItem.Counter++;
                return true;
            }else
            {
                return AddRek(itemToAdd, actItem);
            }
        }

        public BinaryTreeItem ItemBeforeItem(int itemToFind, out bool isStartItem, BinaryTreeItem actItem = null)
        {
            isStartItem = false;

            if(this._root == null)
            {
                return null;
            }

            if(actItem == null)
            {
                actItem = this._root;
            }

            if(this._root.Item == itemToFind)
            {
                isStartItem = true;
                return null;
            }

            while (actItem != null)
            {
                //Überprüfung um das itemBeforItem zu finden
                if(actItem.Left.Item == itemToFind)
                {
                    return actItem;
                }
                else if(actItem.Right.Item == itemToFind)
                {
                    return actItem;
                }
                //actItem auf das nächst kleinere setzen
                if(actItem.Item > itemToFind)
                {
                    actItem = actItem.Left;
                }
                //actItem auf das nächst größere setzen
                else if(actItem.Item < itemToFind)
                {
                    actItem = actItem.Right;
                }

                if (actItem == null)
                {
                    return null;
                }
                else
                {
                    return Find(itemToFind, actItem);
                }


            }

            return null;
        }
        public BinaryTreeItem Find(int itemToFind, BinaryTreeItem actItem = null)
        {
            if((itemToFind == 0) || (this._root == null))
            {
                return null;
            }

            if(actItem == null)
            {
                actItem = this._root;
            }

            if(actItem.Item > itemToFind)
            {
                actItem = actItem.Left;
            }
            else if(actItem.Item < itemToFind)
            {
                actItem = actItem.Right;
            }
            else
            {
                return actItem;
            }

            if(actItem == null)
            {
                return null;
            }
            else if(actItem.Item.Equals(itemToFind))
            {
                return actItem;
            }
            else
            {
                return Find(itemToFind, actItem);
            }
        }
        public BinaryTreeItem Minimum(int MinItem, BinaryTreeItem actItem = null)
        {
            if((MinItem == 0) || (this._root == null))
            {
                return null;
            }
            //MinItem in der Liste finden
            BinaryTreeItem  foundItem = Find(MinItem);

            if(foundItem == null)
            {
                return null;
            }
            //actItem zum weiterlaufen der Liste
            if(actItem == null)
            {
                actItem = foundItem;
            }
            //wenn es etwas kleineres gibt
            if(actItem.Left != null)
            {
                actItem = actItem.Left;
            }
            //überprüfen & Stop für Rekursion
            if(actItem.Left == null)
            {
                return actItem;
            }
            else
            {
                return Minimum(MinItem, actItem);
            }
        }

        public BinaryTreeItem Maximum(int MaxItem, BinaryTreeItem actItem = null)
        {
            if ((MaxItem == 0) || (this._root == null))
            {
                return null;
            }
            //Maxitem in der Liste finden 
            BinaryTreeItem foundItem = Find(MaxItem);

            if (foundItem == null)
            {
                return null;
            }
            //actItem zum weiterlaufen der Liste
            if (actItem == null)
            {
                actItem = foundItem;
            }
            //gibt es ein größeres Item
            if (actItem.Right != null)
            {
                actItem = actItem.Right;
            }
            //Überprüfen & Stop für Rekursion
            if (actItem.Right == null)
            {
                return actItem;
            }
            else
            {
                return Maximum(MaxItem, actItem);
            }
        }
        
        public BinaryTreeItem MinimumRecursiv(int? startValue = null, BinaryTreeItem actItem = null)
        {
            //bei "ersten" Aufruf ist actItem null
            if(actItem == null)
            {
                //falls startValue != null ist, suchen wir das Element im Baum und setzen das actItem
                if(startValue != null)
                {
                    actItem = Find(startValue.Value);
                }
                //ansonsten starten wir bei _root
                else
                {
                    actItem = this._root;
                }
            }
            //bei allen weiteren Aufrufen, setzen wir den Zeiger auf den LeftItem
            else
            {
                actItem = actItem.Left;
            }

            if(actItem == null)
            {
                return null;
            }

            //Minimum wurde gefunden
            if(actItem.Left == null)
            {
                return actItem;
            }
            else
            {
                return MinimumRecursiv(startValue, actItem);
            }
        }

        public BinaryTreeItem MaximumRecursiv(int? startValue = null, BinaryTreeItem actItem = null)
        {
            //bei "ersten" Aufruf ist actItem null
            if (actItem == null)
            {
                //falls startValue != null ist, suchen wir das Element im Baum und setzen das actItem
                if (startValue != null)
                {
                    actItem = Find(startValue.Value);
                }
                //ansonsten starten wir bei _root
                else
                {
                    actItem = this._root;
                }
            }
            //bei allen weiteren Aufrufen, setzen wir den Zeiger auf den RightItem
            else
            {
                actItem = actItem.Right;
            }

            if (actItem == null)
            {
                return null;
            }

            //Minimum wurde gefunden
            if (actItem.Right == null)
            {
                return actItem;
            }
            else
            {
                return MaximumRecursiv(startValue, actItem);
            }
        }
        public BinaryTreeItem Remove(int itemToRemove, BinaryTreeItem actItem = null)
        {
            if(actItem == null)
            {
                actItem = this._root;
            }

            if (itemToRemove == this._root.Item)
            {
                actItem = actItem.Right;
                actItem = MinimumRecursiv(actItem.Item);
                actItem.Left = this._root.Left;
                this._root.Right = this._root;
                return actItem;
            }
            else
            {
                
                while ((actItem.Left != null) && (actItem.Right != null)){ 
                    if (itemToRemove > actItem.Item)
                    {
                        actItem = actItem.Right;
                    }
                    else if(itemToRemove < actItem.Item)
                    {
                        actItem = actItem.Left;
                    }
                    //Fall a) 
                    if((actItem.Left.Item  == itemToRemove) && (actItem.Left.Left == null))
                    {
                        actItem.Left = actItem.Left.Right;
                        return actItem;
                    }
                    else if ((actItem.Right.Item == itemToRemove) && (actItem.Right.Left == null))
                    {
                        actItem.Right = actItem.Right.Right;
                        return actItem;
                    }
                    //Fall b)
                    if ((actItem.Left.Item == itemToRemove) && (actItem.Left.Right == null))
                    {
                        actItem.Left = actItem.Left.Left;
                        return actItem;
                    }
                    else if ((actItem.Right.Item == itemToRemove) && (actItem.Right.Right == null))
                    {
                        actItem.Right = actItem.Right.Left;
                        return actItem;
                    }
                    //Fall c)
                    bool isFirstItem;
                    BinaryTreeItem itemBeforeItem = this.ItemBeforeItem(itemToRemove, out isFirstItem);


                }
                return actItem;
                //Dieser kommentar wurde am 20.11.2019 geschriebem
            }
        }
    }
}
/* Meine falsche Methode
            if (itemToAdd >= actItem.Item)
            {
                actItem = actItem.Right;
                while ((actItem.Right != null) && (actItem.Left != null))
                {
                    if (itemToAdd >= actItem.Item)
                    {
                        actItem = actItem.Right;
                    }
                    else
                    {
                        actItem = actItem.Left;
                    }
                }

                if (itemToAdd >= actItem.Item)
                {
                    actItem.Right = new BinaryTreeItem(itemToAdd, null, null, 1);
                    return true;
                }
                else
                {
                    actItem.Left = new BinaryTreeItem(itemToAdd, null, null, 1);
                    return true;
                }
            }
            else
            {

                actItem = actItem.Left;
                while (actItem != null)
                {
                    if (itemToAdd >= actItem.Item)
                    {
                        actItem.Right = new BinaryTreeItem(itemToAdd, null, null, 1);
                        return true;
                        
                    }
                    else
                    {
                        actItem = actItem.Right; 
                    }

                    if (itemToAdd <= actItem.Item)
                    {
                        actItem.Left = new BinaryTreeItem(itemToAdd, null, null, 1);
                        return true;

                    }
                    else
                    {
                        actItem = actItem.Left;
                    }
                } */
