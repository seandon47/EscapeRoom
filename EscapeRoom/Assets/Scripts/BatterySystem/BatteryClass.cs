using System.Collections;
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

    public void AddCharge(int charge)
    {
        Charge += charge;
        if (Charge > MaxCharge)
        {
            // Add problem counter
            Charge = MaxCharge;
        }
    }

    public virtual int GetBatteryPercent()
    {
        return (int)(Charge / (float)MaxCharge * 100);
    }
}
