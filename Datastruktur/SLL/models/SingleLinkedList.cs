using System;
using System.Collections.Generic;
using System.Text;

namespace SLL.models
{
    class SingleLinkedList<T> where T : class
    {
        public SingleLinkedListItem<T> _firstItem;
        public SingleLinkedListItem<T> _lastItem;
        

        public SingleLinkedList()
        {
            this._firstItem = null;
            this._lastItem = null;
        }

        public SingleLinkedList(T item)
        {
            this._firstItem = new SingleLinkedListItem<T>(item, null);
            this._lastItem = _firstItem;
        }

        public SingleLinkedList(SingleLinkedList<T> sll)
        {
            this._firstItem = sll._firstItem;
            this._lastItem = sll._lastItem;
        }

        //Methode Add
        public bool Add(T itemToAdd)
        {
            //1. Parameter überprüfen
            if (itemToAdd == null)
            {
                return false;
            }
            //1.Fall: die SLL ist leer
            if (this._firstItem == null)
            {
                this._firstItem = new SingleLinkedListItem<T>(itemToAdd, null);
                this._lastItem = this._firstItem;
            }

            //2.Fall: die SLL ist nicht leer
            else
            {
                this._lastItem.NextItem = new SingleLinkedListItem<T>(itemToAdd, null);
                this._lastItem = this._lastItem.NextItem;
            }
            return true;
        }
        /*
        public void AddItemafterItem(T itemToAdd, T itemToFind)
        {
           
            SingleLinkedListItem<T> actItem = this._firstItem;
            while (actItem != null) { 
                //1.Fall:  gesuchtes Item befindet sich irgendwo in der Liste
                if (actItem.Equals(itemToFind))
                {
                   //itemToFind.NextItem = itemToAdd.NextItem;
                    //itemToAdd.NextItem = itemToFind;
                    
                }

                //2.Fall: gesuchtes Item ist letztes Item
                if(itemToFind == _lastItem)
                {
                    this._lastItem.NextItem = new SingleLinkedListItem<T>(itemToAdd, null);
                    this._lastItem = this._lastItem.NextItem;
                }
            }
        }
        */
        /*
        public bool Remove(T itemToRemove)
        {
            if(itemToRemove == null)
            {
                return false;
            }
            // es exitstiert noch kein Eintrag in der Liste
            if (this._firstItem == null)
            {
                return false;
            }
            // 1ter Fall: 1ter Eintrag
            // 1ter eintrag ist der gesuchte Eintrag
            if(itemToRemove.Equals(this._firstItem.Item))
            {
                this._firstItem = this._firstItem.NextItem;
                return true;
            }
            // 2ter Fall: irgendwo zwischen _firstItem und _lastItem
            SingleLinkedListItem<T> actItem = this._firstItem;
            while (actItem != null)
            {
                if(actItem.NextItem != null)
                {
                    if (actItem.NextItem.Item.Equals(itemToRemove))
                    {
                        actItem.NextItem = actItem.NextItem.NextItem;
                        return true;
                    }
                    
                }
                actItem = actItem.NextItem;
            }

            // 3ter Fall: es handelt sich um den letzten Eintrag
            actItem = this._firstItem;
            while (actItem.NextItem  != this._lastItem)
            {
                actItem = actItem.NextItem;
                if (actItem.NextItem.Item.Equals(itemToRemove))
                {
                    this._lastItem = actItem;
                    this._lastItem.NextItem = null;
                    return true;
                }
                return false;
            }

            return false;
        }
        */

        public bool Remove(T itemToRemove)
        {
            if (itemToRemove == null)
            {
                return false;
            }
            // es exitstiert noch kein Eintrag in der Liste
            if (this._firstItem == null)
            {
                return false;
            }

            bool isFirstItem;
            SingleLinkedListItem<T> itemBeforeItemToRemove = this.FindItemBeforeItemToFind(itemToRemove, out isFirstItem);

            //Item ist nicht vorhanden
            if(itemBeforeItemToRemove == null && !isFirstItem)
            {
                return false;
            }

            //1.Fall 1ter Eintrag
            //1. Eintrag ist der gesuchte Eintrag
            if (isFirstItem)
            {
                this._firstItem = this._firstItem.NextItem;
                return true;
            }

            //2. Fall: es handelt sich um den letzten Eintrag
            if(itemBeforeItemToRemove.NextItem.NextItem == null)
            {
                this._lastItem = itemBeforeItemToRemove;
                this._lastItem.NextItem = null;
                return true;
            }

            //3. Fall: Eintrag ist irgenwo dazwischen
            //if(itemBeforeItemToRemove.NextItem == itemToRemove)
            else{
                itemBeforeItemToRemove.NextItem = itemBeforeItemToRemove.NextItem.NextItem;
                return true;
            }
            
        }
        public SingleLinkedListItem<T> Find(T itemToFind)
        {
            ;

            if(itemToFind == null)
            {
                return null;
            }
            if(this._firstItem == null)
            {
                return null;
            }
            // 1. Fall: Firstitem ist das gesuchte Item
            /*
            if (this._firstItem.Item.Equals(itemtoFind)){

                return _firstItem;
            }
            */
            //2. Fall: Item in der Liste ist gesucht
            SingleLinkedListItem<T> actItem = this._firstItem;
             
                while (actItem != null)
                {
                    if (actItem.Item.Equals(itemToFind))
                    {
                        return actItem;
                    }
                    actItem = actItem.NextItem;
                }
                
            
            return null;

        }

        public SingleLinkedListItem<T> FindItemBeforeItemToFind(T itemToFind, out bool isStartItem)
        {
            isStartItem = false;

            if (itemToFind == null)
            {
                return null;
            }
            if (this._firstItem == null)
            {
                return null;
            }

            if (this._firstItem.Item.Equals(itemToFind))
            {
                isStartItem = true;
                return null;
            }

            SingleLinkedListItem<T> actItem = this._firstItem;
            while (actItem != null)
            {
                if ((actItem.NextItem != null) && (actItem.NextItem.Item.Equals(itemToFind)))
                {
                    return actItem;
                }
                actItem = actItem.NextItem;
            }


            return null;
        }

        public bool Change (T itemToChange, T itemNewData)
        {
            //parameter überprüfen
            if((itemToChange == null) || (itemNewData == null))
            {
                return false;
            }
            if(this._firstItem == null)
            {
                return false;
            }
            SingleLinkedListItem<T> foundItem = Find(itemToChange);

            //mit dem Ergebnis weiterarbeiten
            if (foundItem == null)
            {
                return false;
            }
            else
            {
                foundItem.Item = itemNewData;
                return true;
            }

        }
        public override string ToString()
        {
            string s = "";

            if (this._firstItem != null)
            {
                SingleLinkedListItem<T> actItem = this._firstItem;
                while (actItem != null)
                {
                    s += actItem.Item.ToString() + "\n";
                    actItem = actItem.NextItem;
                }
            }
            if (s == "")
            {
                return "no item";
            }
            return s;
        }

    }
}

