﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryClass : MonoBehaviour
{
    [SerializeField]
    private int MaxCharge;
    
    [SerializeField]
    private int Charge;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UseCharge(int draw)
    {
        Charge -= draw;
        if (Charge < 0)
            Charge = 0;
    }

    public float GetBatteryPercent()
    {
        return (Charge / (float)MaxCharge) * 100;
    }
}
