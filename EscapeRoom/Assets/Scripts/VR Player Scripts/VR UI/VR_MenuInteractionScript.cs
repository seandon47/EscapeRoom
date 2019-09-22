using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class VR_MenuInteractionScript : MonoBehaviour
{
    public SteamVR_Action_Boolean MenuOnOff;
    public SteamVR_Input_Sources HandType;
    public GameObject Menu;

    // Start is called before the first frame update
    void Start()
    {
        MenuOnOff.AddOnChangeListener(ButtonDown, HandType);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonDown(SteamVR_Action_In fromAction)
    {
        if (fromAction.GetChanged(HandType))
        {
            if(MenuOnOff.GetStateDown(HandType))
            {
                Menu.SetActive(!Menu.activeInHierarchy);
                Debug.Log("Menu Button Click");
            }
        }
    }
}
