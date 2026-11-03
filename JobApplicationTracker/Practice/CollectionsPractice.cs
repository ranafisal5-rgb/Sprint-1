using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


void print<T> (IEnumerable<T> collection)
{
    foreach (var x in collection)
        Console.WriteLine(x);
}

//list
Console.WriteLine("////list//////");
List<int> nums = new List<int>() { 1 , 2 , 3, 4 };
List<string> names =  ["rana" , "mona" , "hoda"];
nums.Add(5);
nums.Add(6);
Console.WriteLine("/////print list/////");
foreach (var x in nums)
 Console.WriteLine(x);
Console.WriteLine("////delete 1//////");
nums.Remove(1);
print(nums);
// search 
Console.WriteLine(nums.Contains(1) ? "1 is found" : "one not found");
int[] range = new int[] { 6, 7, 8, 9 };
nums.AddRange(range);
Console.WriteLine("////add range//////");
print(nums);
nums[0] = -1;
Console.WriteLine("////editingg//////");
print(nums);
nums.Insert(1, 0);
nums.Insert(2, 1);
print(nums);

//////////////////////////////////
///Dictionary

Console.WriteLine("\nDictionary");
Dictionary<int, string> id_name = new Dictionary<int, string>() { [1] = "rana"} ;

id_name.Add(2, "mona");
if (id_name.TryGetValue(2, out string name))
    Console.WriteLine(name);
Console.WriteLine(id_name.ContainsKey(3) ? "key 3 is found" : "key 3 not found");
print(id_name);

//////////////////////
///// hashset

Console.WriteLine("\n hashset");
HashSet<int> uniqe = [1, 2, 3, 3 ,4];
uniqe.Add(1);
print(uniqe);
//////////
//stack
Console.WriteLine("\n         stack");
Stack<string> words = new Stack<string>();

words.Push("sum");
words.Push("sub");
words.Push("devid");
print(words);
Console.WriteLine("\n");
words.Pop();
print(words);
Console.WriteLine("peek is "+words.Peek());

////////
///queue
Console.WriteLine("\n         queue");

Queue<int> fifo = [];
fifo.Enqueue(1);
fifo.Enqueue(2);
fifo.Enqueue(3);

print(fifo);
Console.WriteLine("\n");
fifo.Dequeue();
print(fifo);
Console.WriteLine("peek is " + fifo.Peek());
























