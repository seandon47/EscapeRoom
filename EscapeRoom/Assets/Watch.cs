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

    Dictionary<int, GameObject> MountedControls = new Dictionary<int, GameObject>();

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
        ItemBehaviour behavior = equipedItem.GetBehavior();
        behavior.EquipToVrPlayer(this);
        Debug.Log($"{behavior.name} was equipped : {behavior.GetInstanceID()}");
    }

    public void OnUnequipped(Mountable unequippedItem)
    {
        ItemBehaviour behavior = unequippedItem.GetBehavior();
        int ID = behavior.GetInstanceID();
        Debug.Log($"{unequippedItem.name} was unequipped : {ID}");

        DisplayName.SetText("(EMPTY)");

        GameObject buttonToDestroy = MountedControls[ID];
        buttonToDestroy.transform.SetParent(null);
        Destroy(buttonToDestroy);

        MountedControls.Remove(ID);
    }

    public void AddButton(GameObject buttonObject, int objectId)
    {
        buttonObject.transform.SetParent(WatchBody.transform, false);
        buttonObject.transform.localPosition = new Vector3(0.4f, 0.75f, 0.4f);

        Debug.Log($"Object ID Added: {objectId}");
        MountedControls.Add(objectId, buttonObject);
    }

    public void AddDisplay(GameObject displayObject)
    {

    }
}
