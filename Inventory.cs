using System;
using System.Collections.Generic;
using System.Linq;

public class Inventory
{
    private Dictionary<Type, int> _items { get; set; } = new Dictionary<Type, int>();

    public bool HasItems(Type type, int amount = 1) => 
        _items.ContainsKey(type) && _items[type] >= amount;

    public bool TryUse(Type type, int amount =  1)
    {
        if(!_items.ContainsKey(type))
            return false;

        var itemAmount = _items[type];
        
        if(itemAmount >= amount)
        {
            _items[type] -= amount;
            return true;
        }

        return false;
    }

    public void Add<TItem>(int amount = 1)
    {
        if(_items.ContainsKey(typeof(TItem)))
            _items[typeof(TItem)] += amount;
        else
            _items[typeof(TItem)] = amount;
    }

    public override string ToString()
    {
        return string.Join(", ", _items.Select(item => $"{item.Key}: {item.Value}"));
    }
}