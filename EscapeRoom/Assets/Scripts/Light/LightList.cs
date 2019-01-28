using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LightList
{
    public List<LightClass> Lights;
    public Breaker CircuitBreaker;

    public void Setup()
    {
        CircuitBreaker.TopButton.Pressed += TopButton_Pressed;
        CircuitBreaker.BottomButton.Pressed += BottomButton_Pressed;
    }

    private void TopButton_Pressed()
    {
        foreach (LightClass LC in Lights)
        {
            LC.SetState(LightClass.LightState.ON);
        }
        CircuitBreaker.BottomButton.gameObject.GetComponent<MeshRenderer>().material =
            GameController.Instance.LightingSystem.DimGreen;

        CircuitBreaker.TopButton.gameObject.GetComponent<MeshRenderer>().material =
            GameController.Instance.LightingSystem.BrightRed;
    }

    private void BottomButton_Pressed()
    {
        foreach (LightClass LC in Lights)
        {
            LC.SetState(LightClass.LightState.OFF);
        }
        CircuitBreaker.BottomButton.gameObject.GetComponent<MeshRenderer>().material =
            GameController.Instance.LightingSystem.BrightGreen;

        CircuitBreaker.TopButton.gameObject.GetComponent<MeshRenderer>().material =
            GameController.Instance.LightingSystem.DimRed;
    }

    public void TripBreaker()
    {
        BottomButton_Pressed();
    }

    public void ResetBreaker()
    {
        TopButton_Pressed();
    }
}
