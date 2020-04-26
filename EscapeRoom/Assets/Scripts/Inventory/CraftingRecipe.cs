using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingRecipe
{
    public List<string> Components;
    public string ResultName;

    public CraftingRecipe(string name, params string[] components)
    {
        ResultName = name;
        Components = new List<string>(components); 
    }
}