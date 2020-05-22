using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class VrPlayerInventoryInput : MonoBehaviour
{
    public SteamVR_Action_Boolean InventoryPressAction;
    public VrInventory VrInventory;
    public SteamVR_Input_Sources HandType;

    // Start is called before the first frame update
    void Start()
    {
        InventoryPressAction.AddOnChangeListener(DisplayInventoryPress, HandType);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void DisplayInventoryPress(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource, bool newState)
    {
        if (fromAction.stateDown)
            VrInventory.ToggleDisplay();
    }
    
}
