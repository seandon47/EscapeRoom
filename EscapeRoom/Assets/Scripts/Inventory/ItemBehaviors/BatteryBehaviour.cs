using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BatteryBehaviour : ItemBehaviour
{
    public WatchDisplay BatteryReadout;
    public UnityEvent BatteryUpdate;

    BatteryClass Battery;
    WatchDisplay Display;

    // Start is called before the first frame update
    void Start()
    {
        Battery = GetComponent<BatteryClass>();
        if (Battery == null)
            Battery = new GameObject().AddComponent<RemovedBatteryClass>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Display == null)
            return;

        Display.UpdateDisplayText($"{Battery.GetBatteryPercent()}%");
    }
    public override void EquipToVrPlayer(Watch watch)
    {
        // Show battery percentage on watch
        Display = Instantiate(BatteryReadout);
        watch.AddButton(Display.gameObject);
    }

    public override void Input()
    {
        // Come up with something fun to do here
        throw new System.NotImplementedException();
    }
}
