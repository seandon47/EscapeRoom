using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RechargeStation : MonoBehaviour
{
    public RechargePoint RechargeMount;
    public TextMeshPro PercentCharged;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int percentCharged = RechargeMount.GetCurrentBatteryPercent();
        PercentCharged.text = $"Charge {percentCharged}%";
    }
}
