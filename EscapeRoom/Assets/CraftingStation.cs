using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingStation : MonoBehaviour
{
    public MaterialPad Material1;
    public MaterialPad Material2;
    public GameObject ResultPad;

    private List<CraftingRecipe> Recipes = new List<CraftingRecipe>();

    // Start is called before the first frame update
    void Start()
    {
        // Load Crafting Recipes
        // From Disk? From someplace?
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TryCraft()
    {
        // If Material1 and Material2 match up to a recipe
        // Create the result of the recipe on the result pad.

    }
}
