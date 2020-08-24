using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ScriptableObjectList<T> : ScriptableObject, ICollection<T>, IEnumerable<T>, IEnumerable, IList<T>, IReadOnlyCollection<T>, IReadOnlyList<T>, ICollection, IList
{
    [SerializeField]
    List<T> ts = new List<T>();

    public T this[int index] { get => ((IList<T>)ts)[index]; set => ((IList<T>)ts)[index] = value; }
    object IList.this[int index] { get => ((IList)ts)[index]; set => ((IList)ts)[index] = value; }

    public int Count => ((ICollection<T>)ts).Count;

    public bool IsReadOnly => ((ICollection<T>)ts).IsReadOnly;

    public bool IsSynchronized => ((ICollection)ts).IsSynchronized;

    public object SyncRoot => ((ICollection)ts).SyncRoot;

    public bool IsFixedSize => ((IList)ts).IsFixedSize;

    public void Add(T item)
    {
        ((ICollection<T>)ts).Add(item);
    }

    public int Add(object value)
    {
        return ((IList)ts).Add(value);
    }

    public void Clear()
    {
        ((ICollection<T>)ts).Clear();
    }

    public bool Contains(T item)
    {
        return ((ICollection<T>)ts).Contains(item);
    }

    public bool Contains(object value)
    {
        return ((IList)ts).Contains(value);
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        ((ICollection<T>)ts).CopyTo(array, arrayIndex);
    }

    public void CopyTo(Array array, int index)
    {
        ((ICollection)ts).CopyTo(array, index);
    }

    public IEnumerator<T> GetEnumerator()
    {
        return ((IEnumerable<T>)ts).GetEnumerator();
    }

    public int IndexOf(T item)
    {
        return ((IList<T>)ts).IndexOf(item);
    }

    public int IndexOf(object value)
    {
        return ((IList)ts).IndexOf(value);
    }

    public void Insert(int index, T item)
    {
        ((IList<T>)ts).Insert(index, item);
    }

    public void Insert(int index, object value)
    {
        ((IList)ts).Insert(index, value);
    }

    public bool Remove(T item)
    {
        return ((ICollection<T>)ts).Remove(item);
    }

    public void Remove(object value)
    {
        ((IList)ts).Remove(value);
    }

    public void RemoveAt(int index)
    {
        ((IList<T>)ts).RemoveAt(index);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable)ts).GetEnumerator();
    }
}
