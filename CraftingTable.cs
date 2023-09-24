using System;
using System.Linq;
using UnityEngine;

public class CraftingTable : MonoBehaviour
{
    public TCraftableItem Craft<TCraftableItem>(ICraftingSource craftingSource)
        where TCraftableItem : ICraftable, new()
    {
        if(!CanCraft<TCraftableItem>(craftingSource))
            throw new CraftingException($"Could not craft {typeof(TCraftableItem)}");

        var item =  new TCraftableItem();

        foreach (var ingredient in RecipeBook.Recipes[typeof(TCraftableItem)])
            craftingSource.Inventory.TryUse(ingredient.Key, ingredient.Value);
        
        craftingSource.Inventory.Add<TCraftableItem>();

        return item;
    }

    private bool CanCraft<TCraftableItem>(ICraftingSource craftingSource) 
        where TCraftableItem : ICraftable, new()
    {
        if(!RecipeBook.Recipes.ContainsKey(typeof(TCraftableItem)))
            throw new ArgumentOutOfRangeException($"Could not find recipe for {typeof(TCraftableItem)}");

        return RecipeBook
            .Recipes[typeof(TCraftableItem)]
            .All(recipe => craftingSource.Inventory.HasItems(recipe.Key, recipe.Value));
    }
}
