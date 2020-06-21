using System;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class BehaviorComponent
{
    Func<GameObject> VrButtonInstantiation;

    public BehaviorComponent(Func<GameObject> vrButtonInstantiation)
    {
        VrButtonInstantiation = vrButtonInstantiation;
    }

    public GameObject GetVrButton()
    {
        return VrButtonInstantiation();
    }
}