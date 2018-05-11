using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapClass : MonoBehaviour {

    enum MiniMapStates
    {
        Expanding,
        Expanded,
        Contracting,
        Contracted
    }

    MiniMapStates CurrentState;
    RectTransform MiniMapRT = null;
    float Delta = 10.0f;

    // Use this for initialization
    void Start () {
        CurrentState = MiniMapStates.Contracted;
        MiniMapRT = GetComponent<RectTransform>();
    }
	
	// Update is called once per frame
	void Update () {
        float NewX = MiniMapRT.localPosition.x;
        float NewY = MiniMapRT.localPosition.y;
        switch (CurrentState)
        {
            case MiniMapStates.Expanding:
                if (NewX < 0)
                {
                    NewX += Delta * 2.1892f;
                }
                else
                {
                    NewX = 0;
                }
                if (NewY > 0)
                {
                    NewY -= Delta ;
                }
                else
                {
                    NewY = 0;
                }
                if (NewX == 0 && NewY == 0)
                    CurrentState = MiniMapStates.Expanded;
                MiniMapRT.localPosition = new Vector3(NewX, NewY, MiniMapRT.localPosition.z);
                break;
            case MiniMapStates.Expanded:
                break;
            case MiniMapStates.Contracting:
                if (NewX > -590)
                {
                    NewX -= Delta * 2.1892f;
                }
                else
                {
                    NewX = -590;
                }
                if (NewY < 277)
                {
                    NewY += Delta;
                }
                else
                {
                    NewY = 277;
                }
                if (NewX <= -590 && NewY >= 277)
                    CurrentState = MiniMapStates.Contracted;
                MiniMapRT.localPosition = new Vector3(NewX, NewY, MiniMapRT.localPosition.z);
                break;
            case MiniMapStates.Contracted:
                break;
            default:
                break;
        }
    }

    public void ToggleState()
    {
        switch (CurrentState)
        {
            case MiniMapStates.Expanding:
                CurrentState = MiniMapStates.Contracting;
                break;
            case MiniMapStates.Expanded:
                CurrentState = MiniMapStates.Contracting;
                break;
            case MiniMapStates.Contracting:
                CurrentState = MiniMapStates.Expanding;
                break;
            case MiniMapStates.Contracted:
                CurrentState = MiniMapStates.Expanding;
                break;
            default:
                break;
        }
    }
}
