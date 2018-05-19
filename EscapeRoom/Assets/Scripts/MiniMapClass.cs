//
//  MiniMapClass.cs
//  Class to handle Minimap operations
//  Copyright 2018 Disi Studios LLC
//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MiniMapClass : MonoBehaviour, IPointerClickHandler
{

    enum MiniMapStates
    {
        Expanding,
        Expanded,
        Contracting,
        Contracted
    }

    public Camera MiniMapCamera;
    public LayerMask StatusIconMask;

    MiniMapStates CurrentState;
    RectTransform MiniMapRT = null;
    int OldCullingMask = 0;

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
                {
                    CurrentState = MiniMapStates.Expanded;
                    OldCullingMask = MiniMapCamera.cullingMask;
                    MiniMapCamera.cullingMask = (1 << LayerMask.NameToLayer("DoorStatus") | MiniMapCamera.cullingMask);
                }

                MiniMapRT.localPosition = Vector3.Lerp(LocationContracted, LocationExpanded, t);
                MiniMapRT.sizeDelta = Vector2.Lerp(SizeContracted, SizeExpanded, t);
                break;
            case MiniMapStates.Expanded:
                break;
            case MiniMapStates.Contracting:
                if (currentLerpTime == lerpTime)
                {
                    CurrentState = MiniMapStates.Contracted;
                    MiniMapCamera.cullingMask = OldCullingMask;
                }

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

    public void OnPointerClick(PointerEventData eventData)
    {
        RectTransform RT = GetComponent<RectTransform>();

        Vector2 V2 = eventData.pointerCurrentRaycast.screenPosition;
        Vector2 LocalPosition = transform.InverseTransformPoint(V2);

        LocalPosition.x += RT.sizeDelta.x / 2;
        LocalPosition.y += RT.sizeDelta.y / 2;

        LocalPosition.x = LocalPosition.x / RT.sizeDelta.x * 256;
        LocalPosition.y = LocalPosition.y / RT.sizeDelta.y * 256;
        Ray ray = MiniMapCamera.ScreenPointToRay(LocalPosition);
        //Debug.DrawRay(ray.origin, ray.direction * 1000, Color.magenta, 10f);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, StatusIconMask))
        {
            if (hit.collider.gameObject != null)
            {
                Debug.Log(hit.collider.gameObject.name);
            }
            DoorStatusIcon DSI = hit.collider.gameObject.GetComponent<DoorStatusIcon>();
            if (DSI != null)
            {
                DSI.Clicked();
            }
        }
    }
}
