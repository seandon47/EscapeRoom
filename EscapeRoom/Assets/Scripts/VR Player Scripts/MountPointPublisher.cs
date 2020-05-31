using System;
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

    public event Action OnShowMountPoints = delegate { };
    public event Action OnHideMountPoints = delegate { };

    public void ShowMountPoints()
    {
        OnShowMountPoints();
    }

    public void HideMountPoints()
    {
        OnHideMountPoints();
    }
}

