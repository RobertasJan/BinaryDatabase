using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryDatabase.Structures.Trees
{
    [Serializable]
    internal class ObjectNode<TKey, TObject> where TKey : IComparable
    {
        public TObject Data { get; set; }
        public TKey Key { get; set; }
        public ObjectNode<TKey, TObject> LeftNode { get; set; }
        public ObjectNode<TKey, TObject> RightNode { get; set; }

        public ObjectNode(TKey key, TObject objectData) {
            Key = key;
            Data = objectData;
        }
    }
}
