using JobApplicationTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobApplicationTracker.Data
{
    public class DataStore<T> where T : class ,  IEntity 
    {
        List<T> items = [];


        public void Add (T item)
        {
            items.Add(item);
        }

        public void Update (int index , T item)
        {
            if (index < items.Count && index >= 0)
                items[index] = item;
            else
                throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");
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

