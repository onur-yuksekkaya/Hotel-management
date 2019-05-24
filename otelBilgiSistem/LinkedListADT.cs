using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace otelBilgiSistem
{
    public abstract class LinkedListADT
    {
        public Node Head;
        public int Size = 0;
        public abstract void InsertFirst(List<string> value);
        public abstract void InsertLast(List<string> value);
        public abstract void InsertPos(int position, List<string> value);
        public abstract void DeleteFirst();
        public abstract void DeleteLast();
        public abstract void DeletePos(int position);
        public abstract Node GetElement(int position);

        public abstract List<List<string>> DisplayElements();
    }
}
