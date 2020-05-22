using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Shrinkable))]
public class VrInventory : MonoBehaviour
{
    public List<MountPoint> MountPoints;
    private Shrinkable ShrinkableComponent;

    // Start is called before the first frame update
    void Start()
    {
        ShrinkableComponent = GetComponent<Shrinkable>();
        ShrinkableComponent.ShrinkObject();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleDisplay()
    {
        if (ShrinkableComponent.IsShrunk)
            ShrinkableComponent.GrowObject();
        else
            ShrinkableComponent.ShrinkObject();
    }
}
