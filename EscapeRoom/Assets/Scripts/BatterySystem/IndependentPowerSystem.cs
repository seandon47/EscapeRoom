using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class IndependentPowerSystem : MonoBehaviour
{
    public UnityEvent PowerDown;
    public UnityEvent PowerUp;

    public BatteryMountPoint BatteryPoint;
    private int Draw;
    private int PreviousPower;    


    // Start is called before the first frame update
    void Start()
    {
        GameController.Instance.AddIndependentPowerSystem(this);
        PreviousPower = BatteryPoint.GetCurrentBatteryPowerPercentage();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool HasPower()
    {
        if (BatteryPoint.GetCurrentBatteryPowerPercentage() > 0)
            return true;

        return false;
    }

    public string GetPercent()
    {
        return $"{BatteryPoint.GetCurrentBatteryPowerPercentage()}%";
    }

    public void AddDraw(int draw)
    {
        Draw += draw;
    }

    public void SubtractDraw(int draw)
    {
        Draw -= draw;
        if (Draw < 0)
            Draw = 0;
    }

    public void SystemUpdate()
    {
        int CurrentPower = BatteryPoint.GetCurrentBatteryPowerPercentage();

        if (PreviousPower <= 0 && CurrentPower > 0)
            PowerUp.Invoke();

        if (PreviousPower > 0 && CurrentPower <= 0)
            PowerDown.Invoke();

        PreviousPower = CurrentPower;
        BatteryPoint.UseCharge(Draw);
    }
}
