using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeSupportMenu : BaseSystemMenu {
    public GameObject SubsystemPanelPrefab;

    // Use this for initialization
    protected override void Start () {
        base.Start();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void AddSubsystemToMenu(SubSystemClass SubSystem)
    {
        GameObject NewSubsystemPanel = Instantiate(SubsystemPanelPrefab);
        NewSubsystemPanel.transform.SetParent(Content, false);

        SubsystemPanel SP = NewSubsystemPanel.GetComponent<SubsystemPanel>();
        SP.Setup(SubSystem);
    }
}
