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

    float lerpTime = 0.25f;
    float currentLerpTime;
    Vector3 LocationContracted = new Vector3(-590, 277, 0); 
    Vector3 LocationExpanded = new Vector3(0, 0, 0);

    Vector2 SizeContracted = new Vector2(200, 200);
    Vector2 SizeExpanded = new Vector2(400, 400);

    // Use this for initialization
    void Start () {
        CurrentState = MiniMapStates.Contracted;
        MiniMapRT = GetComponent<RectTransform>();
    }
	
	// Update is called once per frame
	void Update () {
        float NewX = MiniMapRT.localPosition.x;
        float NewY = MiniMapRT.localPosition.y;
        float SizeDelta = 0;

        currentLerpTime += Time.deltaTime;
        if (currentLerpTime > lerpTime)
        {
            currentLerpTime = lerpTime;
        }
        float t = currentLerpTime / lerpTime;

        switch (CurrentState)
        {
            case MiniMapStates.Expanding:
                if (currentLerpTime == lerpTime)
                    CurrentState = MiniMapStates.Expanded;

                MiniMapRT.localPosition = Vector3.Lerp(LocationContracted, LocationExpanded, t);
                MiniMapRT.sizeDelta = Vector2.Lerp(SizeContracted, SizeExpanded, t);
                break;
            case MiniMapStates.Expanded:
                break;
            case MiniMapStates.Contracting:
                if (currentLerpTime == lerpTime)
                    CurrentState = MiniMapStates.Contracted;

                MiniMapRT.localPosition = Vector3.Lerp(LocationExpanded, LocationContracted, t);
                MiniMapRT.sizeDelta = Vector2.Lerp(SizeExpanded, SizeContracted, t);
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
        currentLerpTime = 0;
    }
}
