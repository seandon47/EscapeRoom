using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryOverlay : MonoBehaviour
{
    public Fadable BlackoutImage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    internal void PowerDown()
    {
        BlackoutImage.Show();
    }

    public void PowerUp()
    {
        BlackoutImage.Fade();
    }
}
