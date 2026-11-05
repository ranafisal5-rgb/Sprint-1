using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class generic<T>

{
    T value;

   public  generic(T value) => this.value = value;

    public T getvalue()
    {
        return value;
    }

    public void display ()
    {
        Console.WriteLine($"the value : {value}");

    }


}

class values
{


  public  T compare<T>(T a, T b) where T : IComparable<T>
    {
        return a.CompareTo(b) > 0 ? a : b;
    }

}

class repo<T>  where T : class
{
    List<T> items = [];

    void add(T item)
    {
        items.Add(item);
    }

    void remove(T item)
    {
        items.Remove(item);

    }

    List<T> getall() => items;

    bool find(T item) => items.Contains(item);



}






