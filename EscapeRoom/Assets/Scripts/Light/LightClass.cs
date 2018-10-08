using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightClass : MonoBehaviour {

    public enum LightState
    {
        ON,
        OFF,
        FLICKERING,
        BROKEN
    }

    public Light PointLight;
    public Color lightColor;
    public float intensity;
    public float range;
    public float rangeStep;
    public float intensityStep;
    public float chanceThreshold;
    LightState CurrentState;
    
	// Use this for initialization
	void Start () {
        rangeStep = 0.1f;
        intensityStep = 0.1f;
        chanceThreshold = 0.5f;
        CurrentState = LightState.ON;
	}

    public void LoadAllValues()
    {
        if (PointLight == null)
            return;

        lightColor = PointLight.color;
        intensity = PointLight.intensity;
        range = PointLight.range;
    }
	
	// Update is called once per frame
	void Update () {
        if (PointLight == null)
            return;

        switch (CurrentState)
        {
            case LightState.ON:
                OnUpdate();
                break;
            case LightState.OFF:
                // Do nothing
                break;
            case LightState.FLICKERING:
                FlickerUpdate();
                break;
            case LightState.BROKEN:
                BrokenUpdate();
                break;
            default:
                break;
        }
	}

    void OnUpdate()
    {
        PointLight.intensity = GameController.StepValue(PointLight.intensity, intensity, intensityStep);
        PointLight.range = GameController.StepValue(PointLight.range, range, rangeStep);
    }

    void FlickerUpdate()
    {
        float Chances = Random.Range(0.0f, 1.0f);

        if (Chances > chanceThreshold)
        {
            PointLight.gameObject.SetActive(false);
        }
        else
        {
            PointLight.gameObject.SetActive(true);
        }
    }

    void BrokenUpdate()
    {
        // Maybe spark once in a while

        // Maybe start to fall off the ceiling?
    }

    public void SetState(LightState NewState)
    {
        CurrentState = NewState;
        switch (CurrentState)
        {
            case LightState.ON:
                PointLight.gameObject.SetActive(true);
                break;
            case LightState.OFF:
                PointLight.gameObject.SetActive(false);
                break;
            case LightState.FLICKERING:
                PointLight.gameObject.SetActive(true);
                break;
            case LightState.BROKEN:
                PointLight.gameObject.SetActive(false);
                break;
            default:
                break;
        }
    }

    public LightState GetLightState()
    {
        return CurrentState;
    }

    public string GetStateString()
    {
        string retVal = "ON";
        switch (CurrentState)
        {
            case LightState.ON:
                retVal = "ON";
                break;
            case LightState.OFF:
                retVal = "OFF";
                break;
            case LightState.FLICKERING:
                retVal = "FLICKERING";
                break;
            case LightState.BROKEN:
                retVal = "BROKEN";
                break;
            default:
                retVal = "ON";
                break;
        }
        return retVal;
    }
}
