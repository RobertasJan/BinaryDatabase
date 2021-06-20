using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Text;

namespace BinaryDatabase.Structures.Trees
{
    [Serializable]
    public class BinaryTree<TKey, TObject> where TKey : IComparable
    {
        Int32 abc;
        private ObjectNode<TKey, TObject> _rootNode;
        public void Insert(TKey key, TObject obj)
        {
            if (_rootNode == null)
            {
                _rootNode = new ObjectNode<TKey, TObject>(key, obj);
                return;
            }

            InsertObject(_rootNode, new ObjectNode<TKey, TObject>(key, obj));
        }
        // needed for recursion down the binary tree
        private void InsertObject(ObjectNode<TKey, TObject> parentNode, ObjectNode<TKey, TObject> newNode)
        {
            if (_rootNode == null)
            {
                parentNode = newNode;
            }

            // recursion to left side of tree
            if (newNode.Key.CompareTo(parentNode.Key) < 1)
            {
                if (parentNode.LeftNode == null)
                {
                    parentNode.LeftNode = newNode;
                }
                else
                {
                    InsertObject(parentNode.LeftNode, newNode);
                }
            } else
            {
                if (parentNode.RightNode == null)
                {
                    parentNode.RightNode = newNode;
                }
                else
                {
                    InsertObject(parentNode.RightNode, newNode);
                }
            }
        }

        public IEnumerable<Tuple<TKey, TObject>> AsEnumerable()
        {
            var list = new List<Tuple<TKey, TObject>>();
            return ReturnNodeValues(_rootNode, list);
        }

        public TObject Find(TKey key)
        {
            if (_rootNode == null)
            {
                throw new KeyNotFoundException($"Tree does not contain element with key {key.ToString()}");
            }
            return FindNode(_rootNode, key);
        }
        private TObject FindNode(ObjectNode<TKey, TObject> parentNode, TKey key)
        {
            if (parentNode == null)
            {
                throw new KeyNotFoundException($"Tree does not contain element with key {key.ToString()}");
            }
            if (key is string)
            {
                if (parentNode.Key.ToString().ToLower().Contains(key.ToString().ToLower())) {    
                    return parentNode.Data;
                }
            }
            if (parentNode.Key.CompareTo(key) == 0)
            {
                return parentNode.Data;
            } else if (parentNode.Key.CompareTo(key) > 0) {
                return FindNode(parentNode.LeftNode, key);
            } else
            {
                return FindNode(parentNode.RightNode, key);
            }
        }

        private IEnumerable<Tuple<TKey, TObject>> ReturnNodeValues(ObjectNode<TKey, TObject> parentNode, List<Tuple<TKey, TObject>> list)
        {
            if (parentNode == null)
            {
                return list;
            }
            ReturnNodeValues(parentNode.LeftNode, list);
            list.Add(new Tuple<TKey, TObject>(parentNode.Key, parentNode.Data));
            ReturnNodeValues(parentNode.RightNode, list);

            return list;
        }
    }
}
