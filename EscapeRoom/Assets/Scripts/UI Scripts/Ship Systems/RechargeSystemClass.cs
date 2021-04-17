//
//  Copyright 2018 Disi Studios LLC
//
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;


public class RechargeSystemClass : ShipSystemClass
{
    List<RechargePoint> rechargePoints = new List<RechargePoint>();

    void Start()
    {

    }

    public void AddRechargePoint(RechargePoint rechargePoint)
    {
        rechargePoints.Add(rechargePoint);
    }

    public override void TimeUpdate(int CurrentTime)
    {
        
    }

    public override double PowerRequested()
    {
        double power = 0;

        foreach (RechargePoint recharger in rechargePoints)
        {
            power += recharger.GetRequestedPower();
        }

        return power;
    }

    public override void ChargeFailed()
    {
        // Blow something up?
    }
}

