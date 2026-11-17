using JobApplicationTracker.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobApplicationTracker.Data
{
    public class DataStore<T> : IEnumerable<T> where T : class ,  IEntity 
    {
        List<T> items = [];
        public IEnumerator<T> GetEnumerator() { return items.GetEnumerator(); }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


        public void Add (T item)
        {
            items.Add(item);
        }

        public bool Update (T  olditem , T newitem)
        {
            int index = items.IndexOf(olditem);
            if (index != -1)
            {
                items[index] = newitem;
                return true;
            }
            else
                return false;
        }

        public void Remove (T item)
        {
            items.Remove(item);
        }

        public List<T> GetAll => items.ToList();

        public T? GetById(int id)
        {
            T? res = null;
            foreach (var item in items)
            {
                if (id == item.Id)
                   { res = item;
                    break;
                }
                   
            }

            return res;

        }


    }


}

