using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Basura_7
{
    public class Node<T>//implementar WeakReference en parent
    {
        //WeakReference<Node<T>> _parent;
        //Se trabaja con una copia
#nullable disable
        private T Content  /*Item*/;
        private List<Node<T>> _children;
#nullable enable
        //private Node<T>? _parent; /*(root tiene como _parent null)*/
        WeakReference<Node<T>?> _parent;
#nullable disable
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
            //for(int i = 0; i < children.Count; i++)
            //{
            //    Node<T> node = children[i];
            //    AddChild(node);
            //}

            foreach (var child in children)
                AddChild(child);

        }

        private Node<T>? Parent
        {
            get => GetParent();
            set => SetParent(this);
        }/*Set(hacer función);*/

        public bool IsRoot => _parent == null;
        public bool IsLeaf => _children == null;
        public int ChildCount 
        { 
            get {   return (!IsLeaf && _children!=null) ? _children.Count : 0;} 
        }
        public int Level => GetLevel();
        public Node<T>? Root => GetRoot();


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
            if (ContainsDescendant(node) || node.ContainsAncestor(this))
                return;
            else
            {
                Unlink();
                //node.AddChild(this);
                var parent = new WeakReference<Node<T>?>(node);
                _parent = parent;
            }
        }

        public int GetLevel()
        {
            //return (_parent == null) ? 0 : _parent.GetLevel() + 1;

            //if (_parent == null)
            //    return 0;
            //return _parent.GetLevel() + 1;

            //(más eficiente con while)
            int level = 0;
            var p = Parent;
            while (p != null)
            {
                level++;
                p = p.Parent;
            }
            return level;
        }

        public Node<T>? GetRoot()
        {
            //return (_parent == null) ? this : _parent.GetRoot();


            //if (_parent == null)
            //    return this;

            //return _parent.GetRoot();

            var p = Parent;
            while (p != null)
            {
                p = p.Parent;
            }
            return p;

        }

        public void Unlink()        /*(tambien se puede llamar Detach())*/
        {
            var parent = Parent;
            if (parent != null)
            {
                //var parent = GetParent();
                //parent?.RemoveChild(this); /*(Remove debe ser private)*/
                parent.RemoveChild(this);
#nullable disable
                _parent = null;
#nullable enable
            }

        }

        //public void SetParent(Node<T>? node) /*Podría ser bueno revisar si es null, para no confundirlo con un root*/
        //{
        //    if (node == null || node == this || ContainsDescendant(node) || ContainsAncestor(this))
        //        Unlink();
        //    else
        //        node.AddChild(this);
        //}

        public void AddChild(Node<T> node)
        {
            if (node == null|| node == this || node.ContainsDescendant(this) || ContainsAncestor(node))
                return;
            if(_children==null)
                _children = new List<Node<T>>();
            node.Parent = this;
            _children.Add(node);
        }

        private void RemoveChild(Node<T> child) 
        {
            int index = IndexOf(child);
            int count = _children.Count;
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
            int count = _children.Count;
           for(int i = 0; i < count; i++)
           {
                if(node == _children[i]  /*node.Equals(_children[i])*/)
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
#nullable disable
            return (GetParent() != null) ? Parent._children.Count > 1 : false;
#nullable enable
            //if (_parent != null)
            //    return _parent._children?.Count > 0;
            //return false;
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
            //for(int i = 0; i < _children.Count; i++)
            //{
            //    var child = _children[i];
            //    if(child.Equals(node))
            //        return true;
            //    child.ContainsDescendant(node);
            //}
            foreach(var child in _children)
            {
                if (child.Equals(node))
                    return true;
                child.ContainsDescendant(node);
            }
            return false;
        }
        //dado un nodo, invoca una función para él y todos sus descendientes
        delegate void VisitDelegate<t>(Node<T> node);

        void Visit(VisitDelegate<T> visitor)
        {
            if(visitor == null)
                return;
            visitor(this);
            //for(int i = 0; i < _children.Count; i++)
            //{
            //    _children[i].Visit(visitor);
            //}

            foreach(Node<T> node in _children)
            {
                node.Visit(visitor);
            }
        }

        public delegate bool CheckDelegate<t>(Node<T> node);
        public delegate bool CheckDelegate2<t>(T element);
        //public delegate bool CheckDelegate3<t>(List<Node<T>> node);

        public Node<T> FindNode(CheckDelegate<T> checker)
        {
            if (checker == null)
#nullable disable
                return null;
#nullable enable
            if (checker(this))
                return this;
            //for (int i = 0; i < _children.Count; i++)
            //{
            //    var child = _children[i];
            //    var found = child.FindNode(checker);
            //    if(found != null)
            //        return found;
            //}

            foreach (var child in _children)
            {
                var found = child.FindNode(checker);
                if (found != null)
                    return found;
            }
#nullable disable
            return null;
#nullable enable
        }

        public List<Node<T>>? FindListNode(CheckDelegate<T> checker)//modificar
        {
            var result = new List<Node<T>>();
            //result.FindNode(checker, result)

            if (checker == null)
                return null;
            if (checker(this))
                result.Add(this);
            //for (int i = 0; i < _children.Count; i++)
            //{
            //    var child = _children[i];
            //    var found = child.FindListNode(checker);
            //    if(found != null)
            //    {
            //        foreach (var foundNode in found)
            //            result.Add(foundNode);
            //    }
            //}

            foreach (var child in _children)
            {
                var found = child.FindListNode(checker);
                if (found != null)
                {
                    foreach (var foundNode in found)
                        result.Add(foundNode);
                }
            }
            return result;
        }

        public List<Node<T>>? Filter(CheckDelegate<T> checker) //hacer Filter (copia pega List FindNode y modificar)
        {
            var result = new List<Node<T>>();

            if (checker == null)
                return null;
            if (checker(this))
                result.Add(this);
            FindNodeInternal(checker, result);
            //for (int i = 0; i < _children.Count; i++)
            //{
            //    var child = _children[i];
            //    var found = child.Filter(checker);
            //    if (found != null)
            //        return found;
            //}
            return result;

        }

        private void FindNodeInternal(CheckDelegate<T> checker, List<Node<T>> list)//hace una lista a través del for, luego la copia a la list
        {
            for(int i= 0; i < _children.Count;i++)
            {
                var child = _children[i];
                var found = child.FindListNode(checker);
                if (found != null)
                {
                    foreach (var foundNode in found)
                        list.Add(foundNode);
                }
            }
        }

        public Node<T>? FindNode2(CheckDelegate2<T> element)
        {
            if (element == null)
                return null;
            if (element(Content))
                return this;
            for (int i = 0; i < _children.Count; i++)
            {
                var child = _children[i];
                var found = child.FindNode2(element);
                if(found != null)
                    return found;
            }
            return null;
        }
        

        public override string ToString()
        {
            T content = Content;
            string result = $"El contenido del nodo es: {content}";
            return result;
        }
    }

}
