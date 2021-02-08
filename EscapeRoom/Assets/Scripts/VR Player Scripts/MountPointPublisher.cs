using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class MountPointPublisher
{
    private static MountPointPublisher InternalInstance;

    public static MountPointPublisher Instance
    {
        get
        {
            if (InternalInstance == null)
                InternalInstance = new MountPointPublisher();
            return InternalInstance;
        }
    }

    public event Action<GameObject> OnShowMountPoints = delegate { };
    public event Action<GameObject> OnHideMountPoints = delegate { };

    public void ShowMountPoints(GameObject mountableObject)
    {
        OnShowMountPoints(mountableObject);
    }

    public void HideMountPoints(GameObject mountableObject)
    {
        OnHideMountPoints(mountableObject);
    }
}

