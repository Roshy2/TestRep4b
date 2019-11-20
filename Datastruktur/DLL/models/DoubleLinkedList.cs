using System;
using System.Collections.Generic;
using System.Text;

namespace DLL.models
{
    class DoubleLinkedList<T> where T : class
    {
        public DoubleLinkedListItem<T> _firstItem;
        public DoubleLinkedListItem<T> _lastItem;

        public DoubleLinkedList()
        {
            this._firstItem = null;
            this._lastItem = null;
        }

        public DoubleLinkedList(T item)
        {
            this._firstItem = new DoubleLinkedListItem<T>(item, null, null);
            this._lastItem = _firstItem;
        }

        public DoubleLinkedList(DoubleLinkedList<T> dll)
        {
            this._firstItem = dll._firstItem;
            this._lastItem = dll._lastItem;
        }

        //Methoden
        public bool Add(T itemToAdd)
        {
            if(itemToAdd == null)
            {
                return false;
            }
            //1.Fall: Die Liste ist leer
            if(this._firstItem == null)
            {
                this._firstItem = new DoubleLinkedListItem<T>(itemToAdd, null, null);
                this._lastItem = this._firstItem;
            }
            //2.Fall: Die Liste ist nicht leer
            else
            {
                this._lastItem.NextItem = new DoubleLinkedListItem<T>(itemToAdd, null, _lastItem);
                this._lastItem = this._lastItem.NextItem;
            }
            return true;
        }

        public bool AddItemAfterItem(T itemToFind, T itemToAdd)
        {
            if (itemToFind == null || itemToAdd == null || this._firstItem == null)
            {
                return false;
            }

            DoubleLinkedListItem<T> foundItem = Find(itemToFind);
            if (foundItem == null)
            {
                return false;
            }
            else
            {
                if (foundItem == this._lastItem)
                {
                    this.Add(itemToAdd);
                    return true;
                }
                else
                {
                    DoubleLinkedListItem<T> newItem = new DoubleLinkedListItem<T>(itemToAdd, foundItem.NextItem, foundItem);
                    foundItem.NextItem.PreviousItem = newItem;
                    foundItem.NextItem = newItem;
                    return true;
                }
            }
        }
        public bool Remove(T itemToRemove)
        {
            if (itemToRemove == null)
            {
                return false;
            }
            // es existiert noch kein Eintrag in der Liste
            if (this._firstItem == null)
            {
                return false;
            }

            DoubleLinkedListItem<T> foundItem = this.Find(itemToRemove);

            // Item ist nicht vorhanden
            if (foundItem == null)
            {
                return false;
            }
            // 1ter Fall: 1ter Eintrag
            // 1ter Eintrag ist der gesuchte Eintrag
            if (foundItem == this._firstItem)
            {
                this._firstItem = this._firstItem.NextItem;
                this._firstItem.PreviousItem = null;
                return true;
            }
            // 2ter Fall: es handelt sich um den letzten Eintrag
            if (foundItem.NextItem == null)
            {
                this._lastItem = foundItem.PreviousItem;
                this._lastItem.NextItem = null;
                return true;
            }
            // 3ter Fall: irgendwo zwischen _firstItem und _lastItem
            else
            {
                foundItem.NextItem.PreviousItem = foundItem.PreviousItem;
                foundItem.PreviousItem.NextItem = foundItem.NextItem;
                return true;
            }
        }
        public DoubleLinkedListItem<T> Find(T itemToFind)
        {
            if (itemToFind == null)
            {
                return null;
            }
            if (this._firstItem == null)
            {
                return null;
            }

            DoubleLinkedListItem<T> actItem = this._firstItem;
            while (actItem != null)
            {
                if (actItem.Item.Equals(itemToFind))
                {
                    return actItem;
                }
                actItem = actItem.NextItem;
            };
            return null;
        }

        public DoubleLinkedListItem<T> FindRecursic(T itemToFind, DoubleLinkedListItem<T> actItem = null)
        {
            //Parameter überprüfen
            if(itemToFind == null)
            {
                return null;
            }

            if(_firstItem == null)
            {
                return null;
            }

            if(actItem == null)
            {
                actItem = this._firstItem;
            }

            //ansonsten, soll der Zeiger auf das nächste Element gesetzt werden
            else
            {
                actItem = actItem.NextItem;
            }
            
            //actItem wird normalerweise auf actItem.NextItem gesetzt
            //    => actItem könnte null sein (Ende der Liste)
            if(actItem == null)
            {
                return null;
            }

            //ist das aktuelle Element das gesuchte Element
            else if (actItem.Item.Equals(itemToFind))
            {
                return actItem;
            }

            //ansonsten wurde das Element noch nicht gefunden und das
            //     Ende der Liste wurde noch nicht erreicht
            else
            {
                //rekursiver Aufruf
                return FindRecursic(itemToFind, actItem);
            }
        }
        public bool Change(T itemToChange, T itemNewData)
        {
            // Parameter überprüfen
            if ((itemToChange == null) || (itemNewData == null))
            {
                return false;
            }
            if (this._firstItem == null)
            {
                return false;
            }

            DoubleLinkedListItem<T> foundItem = Find(itemToChange);

            // mit dem Ergebnis weiterarbeiten
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
                DoubleLinkedListItem<T> actItem = this._firstItem;
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
