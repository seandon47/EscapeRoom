﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingStation : MonoBehaviour
{
    public MaterialPad MaterialPad1;
    public MaterialPad MaterialPad2;
    public ResultPad ResultPad;
    public ItemFactory ItemCreator;

    private Item Material1;
    private Item Material2;

    private List<CraftingRecipe> Recipes = new List<CraftingRecipe>();

    // Start is called before the first frame update
    void Start()
    {
        // Load Crafting Recipes
        // From Disk? From someplace?
        Recipes.Add(new CraftingRecipe("NoiseMaker", "ColaCan", "ScrapMetal"));
        Recipes.Add(new CraftingRecipe("Flare", "Pipe", "RedPowder"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TryCraft()
    {
        // If Material1 and Material2 match up to a recipe
        // Create the result of the recipe on the result pad.
        if (!CanCraft())
            return;

        CraftingRecipe currentRecipe = FindCraftingRecipe(Material1.Name, Material2.Name);

        if (currentRecipe == null)
            return;

        GameObject result = ItemCreator.Create(currentRecipe.ResultName);
        GameObject CraftedItem = Instantiate(result, ResultPad.transform.position, new Quaternion(0, 0, 0, 0));        
        CraftedItem.GetComponent<Rigidbody>().isKinematic = true;
        ResultPad.SetResultItem(CraftedItem);
        
        MaterialPad1.UseUpMaterial();
        MaterialPad2.UseUpMaterial();
    }

    private CraftingRecipe FindCraftingRecipe(string name1, string name2)
    {
        foreach (CraftingRecipe recipe in Recipes)
        {
            if (CheckRecipe(recipe, name1, name2))
            {
                return recipe;
            }
        }
        return null;
    }

    private bool CheckRecipe(CraftingRecipe recipe, string name1, string name2)
    {
        return recipe.Components.Contains(name1) && recipe.Components.Contains(name2);
    }

    private bool CanCraft()
    {
        if (!MaterialPad1.HasObject || !MaterialPad2.HasObject)
            return false;

        GameObject gameObject1 = MaterialPad1.GetObject();
        GameObject gameObject2 = MaterialPad2.GetObject();

        Material1 = gameObject1.GetComponent<Item>();
        Material2 = gameObject2.GetComponent<Item>();

        if (Material1 == null || Material2 == null)
            return false;

        return true;
    }
}
