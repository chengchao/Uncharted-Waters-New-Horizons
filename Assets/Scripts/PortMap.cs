using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortMap
{
    private PortData _data;
    public PortMap(PortData data)
    {
        _data = data;
    }

    public bool CollisionAt(Vector3 position)
    {
        Debug.Log(position);
        return false;
    }
}
