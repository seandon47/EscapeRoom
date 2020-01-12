using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Valve.VR;
using Valve.VR.Extras;

[RequireComponent(typeof(LaserPointer))]
public class VrUiInput : MonoBehaviour
{
    public SteamVR_ActionSet ActionSetEnable;
    public SteamVR_Action_Boolean MenuPressAction;
    public SteamVR_Action_Boolean TriggerPressAction;
    public SteamVR_Input_Sources HandType;
    public GameObject VrMenu;

    private LaserPointer LaserPointer;
    private PointerEventData PointerEventData = new PointerEventData(EventSystem.current);
    private Button SelectedButton = null;

    private void OnEnable()
    {
        ActionSetEnable.Activate();
        MenuPressAction.AddOnChangeListener(MenuPress, HandType);
        TriggerPressAction.AddOnChangeListener(TriggerPress, HandType);

        LaserPointer = GetComponent<LaserPointer>();
        LaserPointer.PointerIn += HandlePointerIn;
        LaserPointer.PointerOut += HandlePointerOut;
        LaserPointer.PointerClickDown += LaserPointer_PointerClickDown;
        LaserPointer.PointerClickUp += LaserPointer_PointerClickUp;
    }

    private void LaserPointer_PointerClickDown(object sender, PointerEventArgs e)
    {
        var button = e.target.GetComponent<Button>();
        if (button != null)
        {
            //Debug.Log("HandlePointerClickDown", e.target.gameObject);
        }
    }

    private void LaserPointer_PointerClickUp(object sender, PointerEventArgs e)
    {
        var button = e.target.GetComponent<Button>();
        if (button != null)
        {
            //Debug.Log("HandlePointerClickUp", e.target.gameObject);
        }
    }

    private void HandlePointerIn(object sender, PointerEventArgs e)
    {
        var button = e.target.GetComponent<Button>();
        if (button != null)
        {
            button.Select();
            SelectedButton = button;
            //Debug.Log("HandlePointerIn", e.target.gameObject);
        }
    }

    private void HandlePointerOut(object sender, PointerEventArgs e)
    {

        var button = e.target.GetComponent<Button>();
        if (button != null)
        {
            EventSystem.current.SetSelectedGameObject(null);
            SelectedButton = null;
            //Debug.Log("HandlePointerOut", e.target.gameObject);
        }
    }

    private void MenuPress(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource, bool newState)
    {
        if (newState)
        {
            LaserPointer.Active = !LaserPointer.Active;
            VrMenu.SetActive(!VrMenu.activeInHierarchy);
        }
    }

    private void TriggerPress(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource, bool newState)
    {
        if (newState && fromAction.GetStateDown(fromSource) && SelectedButton != null)
        {
            SelectedButton.OnPointerClick(PointerEventData);
        }
    }
}
