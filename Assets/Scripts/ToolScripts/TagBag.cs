using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Collections;

[Serializable]
public class TagBag : ICollection<Tag>, IEnumerable<Tag>, IEnumerable, IReadOnlyCollection<Tag>, ISet<Tag>
{

    [SerializeField]
    private List<TagAmount> items;

    public int Count => ((ICollection<Tag>)items.Select(i => i.item)).Count;

    public bool IsReadOnly => ((ICollection<Tag>)items.Select(i => i.item)).IsReadOnly;

    public void Add(Tag item)
    {
        (this as ISet<Tag>).Add(item);
    }

    public void Clear()
    {
        items.Clear();
    }

    public bool Contains(Tag item)
    {
        return items.Any(i => i.item.Equals(item));
    }

    public void CopyTo(Tag[] array, int arrayIndex)
    {
        items.Select(i => i.item).ToArray().CopyTo(array, arrayIndex);
    }

    public void ExceptWith(IEnumerable<Tag> other)
    {
        foreach (var o in other)
            Remove(o);
    }

    public IEnumerator<Tag> GetEnumerator()
    {
        return items.Select(i => i.item).GetEnumerator();
    }

    public void IntersectWith(IEnumerable<Tag> other)
    {
        items.Select(i => i.item).Intersect(other);
    }

    public bool IsProperSubsetOf(IEnumerable<Tag> other)
    {
        return IsSubsetOf(other) && other.Count() != items.Count() && other.Count() != 0;
    }

    public bool IsProperSupersetOf(IEnumerable<Tag> other)
    {
        return IsSupersetOf(other) && other.Count() != items.Count() && other.Count() != 0;
    }

    public bool IsSubsetOf(IEnumerable<Tag> other)
    {
        return other.Distinct().Intersect(items.Select(i => i.item)).Count() == other.Count();
    }

    public bool IsSupersetOf(IEnumerable<Tag> other)
    {
        var x = items.Select(i => i.item);
        return x.Distinct().Intersect(other).Count() == x.Count();
    }

    public bool Overlaps(IEnumerable<Tag> other)
    {

        var x = items.Select(i => i.item);
        return x.Distinct().Intersect(other).Any();
    }

    public bool Remove(Tag item)
    {
        var exsisting = items.Find(i => i.item.Equals(item));

        if (exsisting.Equals(default(Tag)))
        {
            return false;
        }
        else
        {
            exsisting.count--;
            if (exsisting.count <= 0)
                items.Remove(exsisting);
        }
        return true;
    }
    public void SetCount(Tag item, int n)
    {
        var existing = items.Find(i => i.item.Equals(item));
        if (existing.Equals(default(Tag)))
        {
            items.Add(new TagAmount { item = item, count = n });
        }
        else
        {
            if (n <= 0)
                items.Remove(existing);
            existing.count = n;
        }
    }

    public bool SetEquals(IEnumerable<Tag> other)
    {
        return items.Select(i => i.item).Intersect(other).Count() == items.Count();
    }

    public void SymmetricExceptWith(IEnumerable<Tag> other)
    {
        foreach (var item in items.Select(i => i.item).Intersect(other))
            SetCount(item, 0);
    }

    public void UnionWith(IEnumerable<Tag> other)
    {
        foreach (var i in other)
            Add(i);
    }
    public void UnionWith(IEnumerable<TagAmount> other)
    {
        foreach (var i in other)
            Add(i.item,i.count);
    }

    bool ISet<Tag>.Add(Tag item)
    {
        return Add(item, 1);
    }
    bool Add(Tag item, int n)
    {
        var exsisting = items.Find(i => i.item.Equals(item));

        if (exsisting.Equals(default(Tag)))
        {
            items.Add(new TagAmount { item = item, count = 1 });
        }
        else
        {
            exsisting.count+=n;
        }
        return true;
    }

    public int GetAmount(Tag item)
    {
        var exsists = items.Find(i => i.item.Equals(item));
        if (exsists.Equals(default(Tag)))
            return 0;
        return exsists.count;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return items.Select(i => i.item).ToArray().GetEnumerator();
    }
}