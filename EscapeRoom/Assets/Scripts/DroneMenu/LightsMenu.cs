using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsMenu : BaseSystemMenu {

	// Use this for initialization
	protected override void Start () {
        base.Start();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            base.CloseAllSystemMenus();
        }
    }
}
