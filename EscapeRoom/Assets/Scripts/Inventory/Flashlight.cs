using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public Light WhiteLight;

    // Start is called before the first frame update
    void Start()
    {
        if (WhiteLight == null)
            throw new NullReferenceException("Flashlight doesn't have WhiteLight set");
        Toggle();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Toggle()
    {
        if (WhiteLight.enabled)
            TurnOff();
        else
            TurnOn();
    }

    private void TurnOn()
    {
        WhiteLight.enabled = true;
    }

    private void TurnOff()
    {
        WhiteLight.enabled = false;
    }
}
