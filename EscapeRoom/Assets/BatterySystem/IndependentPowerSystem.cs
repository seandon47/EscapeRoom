using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndependentPowerSystem : MonoBehaviour
{
    public BatteryClass Battery;
    private int Draw;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
        Battery.
    }
}
