using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloomFIlter
{
    internal class BloomFlower<T>
    {
       
            public int Cap;
            public byte[] Filter;
            List<Func<T,int>> Funcs;
            public BloomFlower(int cap,int StartNumOfFuncs)
            {
                Cap = cap;
                Filter = new byte[cap];
                Funcs = new List<Func<T, int>>();

                if (Math.Abs(StartNumOfFuncs) >= 3)
                {
                    Funcs.Add(HashFuncThree);
                    StartNumOfFuncs = 2;
                } 
                if(Math.Abs(StartNumOfFuncs) == 2)
                {
                    Funcs.Add(HashFuncTwo);
                    StartNumOfFuncs = 1;
                }
                if (Math.Abs(StartNumOfFuncs) == 1)
                {
                    Funcs.Add(HashFuncOne);
                }

            }

            public void LoadHashFunc(Func<T, int> hashFunc)
            {
                Funcs.Add(hashFunc);
            }

            public void Insert(T item)
            {
                foreach(var thing in Funcs)
                {
                    Filter[thing(item) % Cap] = 1;
                }
            }

            public bool ProbablyContains(T item)
            {
                foreach(var thing in Funcs)
                {
                    int index = thing(item) % Cap;
                    if (Filter[index] != 1)
                    {
                        return false;
                    }
                }
                return true;
            }

            private int HashFuncOne(T item)
            {
                return item.GetHashCode() % Cap;
            }

            private int HashFuncTwo(T item)
            {
                return ((item.GetHashCode() + 3) / 5) % Cap;
            }

            private int HashFuncThree(T item)
            {
                return ((item.GetHashCode() + 5) * 3) % Cap;
            }
        

    }
}
