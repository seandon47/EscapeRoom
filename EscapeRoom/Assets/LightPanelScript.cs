using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightPanelScript : MonoBehaviour {
    LightClass MyLight;
    public Text NameLabel;
    public Text StatusLabel;
    public Button ChangeStateButton;
    public Button ChangeColor;

	// Use this for initialization
	void Start ()
    {
        ChangeStateButton.onClick.AddListener(ChangeStateButtonClick);
        ChangeColor.onClick.AddListener(ChangeColorButtonClick);
        ChangeStateButton.GetComponentInChildren<Text>().text = "Change State";
        ChangeColor.GetComponentInChildren<Text>().text = "Color?";
    }

    public void Setup(string Name, int CircuitNumber, int LightNumber, LightClass NewLight)
    {
        MyLight = NewLight;
        CircuitNumber++;
        LightNumber++;
        // NameLabel.text = MyLight.gameObject.name;
        NameLabel.text = "Circuit: " + CircuitNumber.ToString() + " Light: " + LightNumber.ToString();
        StatusLabel.text = MyLight.GetStateString();
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void ChangeStateButtonClick()
    {
        switch (MyLight.GetLightState())
        {
            case LightClass.LightState.ON:
                MyLight.SetState(LightClass.LightState.OFF);
                break;
            case LightClass.LightState.OFF:
                MyLight.SetState(LightClass.LightState.FLICKERING);
                break;
            case LightClass.LightState.FLICKERING:
                MyLight.SetState(LightClass.LightState.BROKEN);
                break;
            case LightClass.LightState.BROKEN:
                MyLight.SetState(LightClass.LightState.ON);
                break;
            default:
                MyLight.SetState(LightClass.LightState.ON);
                break;
        }
        StatusLabel.text = MyLight.GetStateString();
    }

    public void ChangeColorButtonClick()
    {

    }
}
