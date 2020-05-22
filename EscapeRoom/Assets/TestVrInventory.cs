using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestVrInventory : MonoBehaviour
{
    public Shrinkable InventoryWidget;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadMinus))
            InventoryWidget.ShrinkObject();

        if (Input.GetKeyDown(KeyCode.KeypadPlus))
            InventoryWidget.GrowObject();
    }
}