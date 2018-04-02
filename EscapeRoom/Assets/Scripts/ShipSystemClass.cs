//
//  ShipSystemClass.cs
//  Base class for all ship systems to provide similar functionality
//  Copyright 2018 Disi Studios LLC
//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipSystemClass : MonoBehaviour {

    public enum SystemStatusEnum
    {
        Functioning,
        Compromised,
        Malfunctioning,
        Offline
    }

    public GameObject PanelObject;
    protected SystemStatusEnum status;
    protected double percentFunctional;
    protected string systemName;
    protected List<SystemStatusEnum> SubSystemList;
    protected static Dictionary<SystemStatusEnum, Color> StatusColorMap = new Dictionary<SystemStatusEnum, Color>
    {
        { SystemStatusEnum.Functioning, Color.green },
        { SystemStatusEnum.Compromised, Color.yellow },
        { SystemStatusEnum.Malfunctioning, Color.red },
        { SystemStatusEnum.Offline, Color.grey },
    };

    public ShipSystemClass()
    {
        SubSystemList = new List<SystemStatusEnum>();
        status = SystemStatusEnum.Functioning;
        percentFunctional = 100;
    }

    private static void Setup()
    {

    }

    public SystemStatusEnum GetStatus()
    {
        return status;
    }

    public double GetPercentFunctional()
    {
        return percentFunctional;
    }

    public string GetSystemName()
    {
        return systemName;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public virtual void TimeUpdate(int CurrentTime)
    {
        PanelObject.GetComponent<Image>().color = StatusColorMap[status];
    }

    public virtual double PowerRequested()
    {
        // Override in derived class!
        return 0;
    }

    public virtual void ChargeFailed()
    {
        // Override in derived class!
    }
}
