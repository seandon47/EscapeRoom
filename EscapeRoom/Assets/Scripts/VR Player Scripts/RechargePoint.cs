//
//  Copyright 2018 Disi Studios LLC
//
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RechargePoint : MountPoint
{
    [SerializeField]
    private BatteryClass Battery;
    public RechargeSystemClass RechargeSystem;

    private double CurrentPower = 100;

    // Start is called before the first frame update
    void Start()
    {
        base.Initialize();

        SphereCollider collider = gameObject.AddComponent<SphereCollider>();
        collider.radius = 0.05f;
        collider.isTrigger = true;

        if (RechargeSystem != null)
            RechargeSystem.AddRechargePoint(this);
    }

    internal int GetCurrentBatteryPercent()
    {
        if (Battery == null)
            return 0;

        return Battery.GetBatteryPercent();
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentPower > 10 && Battery != null)
        {
            Battery.AddCharge(10);
            Debug.Log($"Charged Battery! New charge: {Battery.GetBatteryPercent()}");
        }
    }

    public void SystemUpdate()
    {

    }

    public double GetRequestedPower()
    {
        // Factor in chance for malfunction here.
        CurrentPower += 50;
        if (CurrentPower > 100)
            CurrentPower = 100;
        return 50;
    }

    public override void Mount(Mountable mountable)
    {
        BatteryClass battery = mountable.gameObject.GetComponent<BatteryClass>();

        if (battery != null)
        {
            Battery = battery;
        }

        base.Mount(mountable);
    }
}
