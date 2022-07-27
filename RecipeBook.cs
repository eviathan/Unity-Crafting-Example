using System;
using System.Collections.Generic;
using RecipeDictionary = System.Collections.Generic.Dictionary<System.Type, System.Collections.Generic.Dictionary<System.Type, int>>;

public static class RecipeBook
{
    public static readonly RecipeDictionary Recipes = new RecipeDictionary
    {
        { 
            typeof(Sword), new Dictionary<Type, int>
            { 
                { typeof(Wood), 1 },
                { typeof(Steel), 2 }
            } 
        }
    };
}