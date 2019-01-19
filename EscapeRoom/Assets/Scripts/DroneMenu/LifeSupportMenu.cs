using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeSupportMenu : BaseMenu {
    public Transform Content;
    public GameObject SubsystemPanelPrefab;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddSubsystemToMenu(SubSystemClass SubSystem)
    {
        GameObject NewSubsystemPanel = Instantiate(SubsystemPanelPrefab);
        NewSubsystemPanel.transform.SetParent(Content, false);

        SubsystemPanel SP = NewSubsystemPanel.GetComponent<SubsystemPanel>();
        SP.Setup(SubSystem);
    }
}
