using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class Watch : MonoBehaviour
{
    public List<MountPoint> MountPointList;
    public TextMeshPro DisplayName;
    public GameObject WatchBody;

    Dictionary<int, List<GameObject>> MountedControls = new Dictionary<int, List<GameObject>>();

    // Start is called before the first frame update
    void Start()
    {
        foreach(MountPoint mountPoint in MountPointList)
        {
            mountPoint.OnItemMounted.AddListener(OnEquipped);
            mountPoint.OnItemUnmounted.AddListener(OnUnequipped);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnEquipped(Mountable equipedItem)
    {
        DisplayName.SetText(equipedItem.name);

        foreach (ItemBehaviour behaviour in equipedItem.BehaviourList)
        {
            behaviour.EquipToVrPlayer(this, equipedItem.GetInstanceID());
            Debug.Log($"{behaviour.name} was equipped : {behaviour.GetInstanceID()}");
        }
    }

    public void OnUnequipped(Mountable unequippedItem)
    {
        int ID = unequippedItem.GetInstanceID();
        Debug.Log($"{unequippedItem.name} was unequipped : {ID}");

        DisplayName.SetText("(EMPTY)");

        if (MountedControls.ContainsKey(ID))
        {
            RemoveBehaviorControls(ID);
        }
    }

    public void AddButton(GameObject buttonObject, int mounteableId)
    {
        buttonObject.transform.SetParent(WatchBody.transform, false);
        buttonObject.transform.localPosition = new Vector3(0.4f, 0.75f, 0.4f);

        Debug.Log($"Object ID Added: {mounteableId}");
        if (!MountedControls.ContainsKey(mounteableId))
            MountedControls.Add(mounteableId, new List<GameObject>());

        MountedControls[mounteableId].Add(buttonObject);
    }

    public void AddDisplay(GameObject displayObject)
    {

    }

    private void RemoveBehaviorControls(int ID)
    {
        foreach (GameObject objectToDestroy in MountedControls[ID])
        {
            objectToDestroy.transform.SetParent(null);
            Destroy(objectToDestroy);
        }

        MountedControls.Remove(ID);
    }
}
