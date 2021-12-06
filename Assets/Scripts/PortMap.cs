using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortMap
{
    private PortData _data;
    private PortData.Port _port;
    private SOState _state;
    public PortMap(PortData data)
    {
        _data = data;
        _port = _data.ports[_state.PortID.ToString()];
    }

    public bool HasCollisionAt(Vector3 position)
    {
        Debug.Log($"collision at {position}");
        return false;
    }

    public bool HasBuildingAt(Vector2Int position)
    {
        foreach (var item in _port.buildings)
        {
            var building = item.Value;
            if (building.x == position.x && building.y == position.y)
            {
                return true;
            }
        }

        Debug.Log($"building at {position}");
        return false;
    }
}
