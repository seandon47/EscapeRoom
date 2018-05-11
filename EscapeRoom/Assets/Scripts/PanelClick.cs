using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PanelClick : MonoBehaviour, IPointerClickHandler
{
    public ShipSystemClass system;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnPointerClick(PointerEventData eventData)
    {
        if (system == null)
            return;

        string RepairInstructions = system.GetRepairInstructions();
        GameController.Instance.AppendToConsole(RepairInstructions);
        system.ClickEvent();
    }
}
