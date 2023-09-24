using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class CraftingException : Exception
{
    public CraftingException(string message) : base(message) { } 
}