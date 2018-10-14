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
    protected List<SubSystemClass> SubSystemList;
    protected Dictionary<SystemStatusEnum, string> SubSystemNames = new Dictionary<SystemStatusEnum, string>();
    protected static Dictionary<SystemStatusEnum, Color> StatusColorMap = new Dictionary<SystemStatusEnum, Color>
    {
        { SystemStatusEnum.Functioning, Color.green },
        { SystemStatusEnum.Compromised, Color.yellow },
        { SystemStatusEnum.Malfunctioning, Color.red },
        { SystemStatusEnum.Offline, Color.grey },
    };

    public ShipSystemClass()
    {
        SubSystemList = new List<SubSystemClass>();
        status = SystemStatusEnum.Functioning;
        percentFunctional = 100;
    }

    public static string GetStatusString(SystemStatusEnum Status)
    {
        string retval = string.Empty;
        switch (Status)
        {
            case SystemStatusEnum.Functioning:
                retval = "Functioning";
                break;
            case SystemStatusEnum.Compromised:
                retval = "Compromised";
                break;
            case SystemStatusEnum.Malfunctioning:
                retval = "Malfunctioning";
                break;
            case SystemStatusEnum.Offline:
                retval = "Offline";
                break;
            default:
                break;
        }
        return retval;
    }

    private static void Setup()
    {

    }

    public void SetStatus(SystemStatusEnum NewStatus)
    {
        status = NewStatus;
        StatusChanged();
    }

    public SystemStatusEnum GetStatus()
    {
        return status;
    }

    protected virtual void StatusChanged()
    {
        // Override me in derived class!!!!!!!!!!$#^#$^&48yroidfh;goarjh;foi
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

    public virtual string GetRepairInstructions()
    {
        // Override in derived classes!
        return "No repairs necessary at this time";
    }

    public virtual void ClickEvent()
    {
        // Override in derived classes!
    }
}
