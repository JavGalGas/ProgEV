using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Basura_7
{
    //dado un nodo, invoca una función para él y todos sus descendientes
    delegate void VisitDelegate<T>(Node<T> node);
    public delegate bool CheckDelegate<T>(Node<T> node);
    public delegate bool CheckDelegate2<T>(T element);
    public class Node<T>//implementar WeakReference en parent
    {
        //WeakReference<Node<T>> _parent;
        //Se trabaja con una copia
#nullable disable
        private T Content  /*Item*/;
        private List<Node<T>> _children;
#nullable enable
        //private Node<T>? _parent; /*(root tiene como _parent null)*/
        WeakReference<Node<T>?>? _parent;
#nullable disable

        private Node<T> Parent
        {
            get => GetParent();
            set => SetParent(value);
        }/*Set(hacer función);*/

        public bool IsRoot => _parent == null;
        public bool IsLeaf => _children == null || _children.Count == 0;
        public int ChildCount
        {
            get { return (!IsLeaf) ? _children.Count : 0; }
        }
        public int Level => GetLevel();
        public Node<T> Root => GetRoot();
        public Node(T content)
#nullable enable
        {
            Content = content;
        }

        public Node(T content, Node<T>? node)
        {
            Content = content;
            SetParent(node!);
        }

        public Node(Node<T>? node, List<Node<T>> children)
        {
            SetParent(node!);
            foreach (var child in children)
                AddChild(child);
        }

        public Node<T>? GetParent()
        {
            if (_parent == null)
                return null;

            Node<T>? result;
            if (_parent.TryGetTarget(out result))
                return result;
            return null;
        }

        public void SetParent(Node<T>? node)
        {
            if (node == null || node == this || node == GetParent())
                return;
            else if (node.ContainsAncestor(this))
                return;
            else
            {
                Unlink();
                var parent = new WeakReference<Node<T>?>(node);
                _parent = parent;
            }
        }

        public int GetLevel()
        {
            int level = 0;
            var p = Parent;
            while (p != null)
            {
                level++;
                p = p.Parent;
            }
            return level;
        }

        public Node<T> GetRoot()
        {
            var p = Parent;

            if (p == null)
                return this;
            return p.GetRoot();
        }

        public void Unlink()        /*(tambien se puede llamar Detach())*/
        {
            var parent = Parent;
            if (parent != null)
            {
                parent.RemoveChild(this);
                _parent = null;
            }

        }

        //public void SetParent(Node<T>? node) /*Podría ser bueno revisar si es null, para no confundirlo con un root*/
        //{
        //    if (node == null || node == this || ContainsAncestor(this))
        //        Unlink();
        //    else
        //        node.AddChild(this);
        //}

        public void AddChild(Node<T> node)
        {
            if (node == null|| node == this || ContainsAncestor(node))
                return;
            if(_children==null)
                _children = new List<Node<T>>();
            node.Parent = this;
            _children.Add(node);
        }

        private void RemoveChild(Node<T> child) 
        {
            int index = IndexOf(child);
            int count = ChildCount;
            if (index != -1 && index < count)
                _children.RemoveAt(index);
            if(count == 0)
                _children = null;
            return;
        }

        private int IndexOf(Node<T> node)
        {
            if(_children == null) 
                return -1;
            int count = ChildCount;
           for(int i = 0; i < count; i++)
           {
                if(node == _children[i])
                    return i;
           }
           return -1;
        }
        
        private Node<T>? GetChildAt(int index)
        {
            return (index <= 0 || index >= _children.Count || _children==null) ? null : _children[index];
        }

        public bool HasSibling()
        {
            return (GetParent() != null) && Parent._children.Count > 1;
        }

        public bool ContainsAncestor(Node<T> node)
        {
            var parent = GetParent();
            if (node == null || parent == null)
                return false;
            if(parent == node)
                return true;
            return parent.ContainsAncestor(node);
        }

        public bool ContainsDescendant(Node<T> node)
        {
            if(node == null || _children == null)
                return false ;
            foreach(var child in _children)
            {
                if (child.Equals(node))
                    return true;
                child.ContainsDescendant(node);
            }
            return false;
        }
        

        void Visit(VisitDelegate<T> visitor)
        {
            if(visitor == null)
                return;
            visitor(this);
            foreach(Node<T> node in _children)
                node.Visit(visitor);
        }

        public Node<T>? FindNode(CheckDelegate<T> checker)
        {
            if (checker == null || _children == null)
                return null;
            if (checker(this))
                return this;

            foreach (var child in _children)
            {
                var found = child.FindNode(checker);
                if (found != null)
                    return found;
            }
            return null;
        }

        public List<Node<T>>? FindListNode(CheckDelegate<T> checker)//modificar
        {
            var result = new List<Node<T>>();

            if (checker == null || _children == null)
                return null;
            if (checker(this))
                result.Add(this);

            foreach (var child in _children)
            {
                var found = child.FindListNode(checker);
                if (found != null)
                    foreach (var foundNode in found)
                        result.Add(foundNode);
            }
            return result;
        }

        public List<Node<T>>? Filter(CheckDelegate<T> checker) 
        {
            var result = new List<Node<T>>();

            if (checker == null)
                return null;
            if (checker(this))
                result.Add(this);
            FindNodeInternal(checker, ref result);
            return result;
        }

        private void FindNodeInternal(CheckDelegate<T> checker, ref List<Node<T>> list) //hace una lista a través del for, luego la copia a la list
        {
            for(int i= 0; i < ChildCount;i++)
            {
                var child = _children[i];
                if (checker(child))
                    list.Add(child);
                var found = child.FindListNode(checker);
                if (found != null)
                    foreach (var foundNode in found)
                        list.Add(foundNode);
            }
        }

        public Node<T>? FindNodeWithContent(CheckDelegate2<T> element)
        {
            if (element == null)
                return null;
            if (element(Content))
                return this;
            foreach(var child in _children)
            {
                var found = child.FindNodeWithContent(element);
                if (found != null)
                    return found;
            }
            return null;
        }

        public override bool Equals(object? obj)
        {
            if (this == obj)
                return true;
            if (obj is not Node<T>) 
                return false;
            var node = (Node<T>)obj;
            return node._children == _children && node._parent == _parent;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            T content = Content;
            string result = $"El contenido del nodo es: {content}";
            return result;
        }

        
    }

}
