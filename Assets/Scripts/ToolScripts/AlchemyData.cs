using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class AlchemyData : IEnumerable<AlchemyItemInstance>, ICollection<AlchemyItemInstance>, IEnumerable, IList<AlchemyItemInstance>, IReadOnlyCollection<AlchemyItemInstance>, IReadOnlyList<AlchemyItemInstance>, ICollection, IList
{
    [SerializeField]
    List<AlchemyItemInstance> _items = new List<AlchemyItemInstance>();
    [SerializeField]
    public AlchemyItemInstance ToolType;
    [SerializeField]
    public TransformEvent OnStartCraft;
    [SerializeField]
    public TransformEvent OnCrafted;
    [SerializeField]
    public Color CurrentColor;
    [SerializeField]
    public AlchemyItemInstance rejectItem;
    [SerializeField]
    public int capacity = -1;

    public int Count => ((ICollection<AlchemyItemInstance>)_items).Count;

    public bool IsReadOnly => ((ICollection<AlchemyItemInstance>)_items).IsReadOnly;

    public bool IsSynchronized => ((ICollection)_items).IsSynchronized;

    public object SyncRoot => ((ICollection)_items).SyncRoot;

    public bool IsFixedSize => ((IList)_items).IsFixedSize;

    AlchemyItemInstance IReadOnlyList<AlchemyItemInstance>.this[int index] => ((IReadOnlyList<AlchemyItemInstance>)_items)[index];

    AlchemyItemInstance IList<AlchemyItemInstance>.this[int index] { get => ((IList<AlchemyItemInstance>)_items)[index]; set => ((IList<AlchemyItemInstance>)_items)[index] = value; }
    object IList.this[int index] { get => ((IList)_items)[index]; set => ((IList)_items)[index] = value; }
    public AlchemyItemInstance this[int index] { get => ((IList<AlchemyItemInstance>)_items)[index]; set => ((IList<AlchemyItemInstance>)_items)[index] = value; }

    public IEnumerator<AlchemyItemInstance> GetEnumerator()
    {
        return ((IEnumerable<AlchemyItemInstance>)_items).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable)_items).GetEnumerator();
    }

    public void Add(AlchemyItemInstance item)
    {
        ((ICollection<AlchemyItemInstance>)_items).Add(item);
    }

    public void Clear()
    {
        ((ICollection<AlchemyItemInstance>)_items).Clear();
    }

    public bool Contains(AlchemyItemInstance item)
    {
        return ((ICollection<AlchemyItemInstance>)_items).Contains(item);
    }

    public void CopyTo(AlchemyItemInstance[] array, int arrayIndex)
    {
        ((ICollection<AlchemyItemInstance>)_items).CopyTo(array, arrayIndex);
    }

    public bool Remove(AlchemyItemInstance item)
    {
        return ((ICollection<AlchemyItemInstance>)_items).Remove(item);
    }

    public int IndexOf(AlchemyItemInstance item)
    {
        return ((IList<AlchemyItemInstance>)_items).IndexOf(item);
    }

    public void Insert(int index, AlchemyItemInstance item)
    {
        ((IList<AlchemyItemInstance>)_items).Insert(index, item);
    }

    public void RemoveAt(int index)
    {
        ((IList<AlchemyItemInstance>)_items).RemoveAt(index);
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