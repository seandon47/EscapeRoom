﻿using UnityEngine;
using UnityEngine.Events;
using Valve.VR.InteractionSystem;

public class OnOffBehavior : ItemBehaviour
{
    public GameObject OnOffButton;
    public UnityEvent ButtonPressed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void HoverButtonPress(Hand hand)
    {
        ButtonPressed?.Invoke();
    }

    GameObject CreateVrButton()
    {
        GameObject buttonObject = Instantiate(OnOffButton);
        HoverButton buttonComponent = buttonObject.GetComponent<HoverButton>();
        buttonComponent.onButtonDown.AddListener(HoverButtonPress);
        return buttonObject;
    }

    public override void Input()
    {
        ButtonPressed.Invoke();
    }

    public override GameObject GetVrBehaviorComponent()
    {
        return CreateVrButton();
    } 
}
