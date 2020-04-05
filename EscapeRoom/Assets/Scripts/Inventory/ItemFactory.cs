using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFactory : MonoBehaviour
{
    public GameObject NoiseMaker;
    public GameObject Flare;
    public GameObject FlashBomb;
    public GameObject PipeBomb;

    internal GameObject Create(string resultName)
    {
        switch(resultName)
        {
            case "NoiseMaker":
                return NoiseMaker;
            default:
                return null;
        }
    }
}
