using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class AlchemyData : IEnumerable<AlchemyItem>, ICollection<AlchemyItem>, IEnumerable, IList<AlchemyItem>, IReadOnlyCollection<AlchemyItem>, IReadOnlyList<AlchemyItem>, ICollection, IList
{
    [SerializeField]
    List<AlchemyItem> _items = new List<AlchemyItem>();
    [SerializeField]
    public AlchemyItem ToolType;
    [SerializeField]
    public TransformEvent OnStartCraft;
    [SerializeField]
    public TransformEvent OnCrafted;
    [SerializeField]
    public Color CurrentColor;
    [SerializeField]
    public AlchemyItem rejectItem;

    public int Count => ((ICollection<AlchemyItem>)_items).Count;

    public bool IsReadOnly => ((ICollection<AlchemyItem>)_items).IsReadOnly;

    public bool IsSynchronized => ((ICollection)_items).IsSynchronized;

    public object SyncRoot => ((ICollection)_items).SyncRoot;

    public bool IsFixedSize => ((IList)_items).IsFixedSize;

    object IList.this[int index] { get => ((IList)_items)[index]; set => ((IList)_items)[index] = value; }
    public AlchemyItem this[int index] { get => ((IList<AlchemyItem>)_items)[index]; set => ((IList<AlchemyItem>)_items)[index] = value; }


    public void Add(AlchemyItem item)
    {
        ((ICollection<AlchemyItem>)_items).Add(item);
    }

    public void Clear()
    {
        ((ICollection<AlchemyItem>)_items).Clear();
    }

    public bool Contains(AlchemyItem item)
    {
        return ((ICollection<AlchemyItem>)_items).Contains(item);
    }

    public void CopyTo(AlchemyItem[] array, int arrayIndex)
    {
        ((ICollection<AlchemyItem>)_items).CopyTo(array, arrayIndex);
    }

    public IEnumerator<AlchemyItem> GetEnumerator()
    {
        return ((IEnumerable<AlchemyItem>)_items).GetEnumerator();
    }

    public bool Remove(AlchemyItem item)
    {
        return ((ICollection<AlchemyItem>)_items).Remove(item);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable)_items).GetEnumerator();
    }

    public int IndexOf(AlchemyItem item)
    {
        return ((IList<AlchemyItem>)_items).IndexOf(item);
    }

    public void Insert(int index, AlchemyItem item)
    {
        ((IList<AlchemyItem>)_items).Insert(index, item);
    }

    public void RemoveAt(int index)
    {
        ((IList<AlchemyItem>)_items).RemoveAt(index);
    }

    public void CopyTo(Array array, int index)
    {
        ((ICollection)_items).CopyTo(array, index);
    }

    public int Add(object value)
    {
        return ((IList)_items).Add(value);
    }

    public bool Contains(object value)
    {
        return ((IList)_items).Contains(value);
    }

    public int IndexOf(object value)
    {
        return ((IList)_items).IndexOf(value);
    }

    public void Insert(int index, object value)
    {
        ((IList)_items).Insert(index, value);
    }

    public void Remove(object value)
    {
        ((IList)_items).Remove(value);
    }
}