using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryMountPoint : MountPoint
{
    [SerializeField]
    private BatteryClass Battery;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetCurrentBatteryPowerPercentage()
    {
        return Battery.GetBatteryPercent();
    }

    protected override void Instance_OnShowMountPoints(GameObject mountableObject)
    {
        if (mountableObject.GetComponent<BatteryClass>() != null)
            base.Instance_OnShowMountPoints(mountableObject);
    }

    protected override void Instance_OnHideMountPoints(GameObject mountableObject)
    {
        if (mountableObject.GetComponent<BatteryClass>() != null)
            base.Instance_OnHideMountPoints(mountableObject);
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

    public void UseCharge(int draw)
    {
        Battery.UseCharge(draw);
    }

    public override void UnMount()
    {
        Battery = new RemovedBatteryClass();
        base.UnMount();
    }
}
