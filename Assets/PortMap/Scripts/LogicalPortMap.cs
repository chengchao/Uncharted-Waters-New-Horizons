using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicalPortMap
{
  private readonly PortData.CollisionIndices _collisionIndices;
  private Dictionary<string, PortData.Port.Building> _buildings;
  private readonly byte[] _tilemap;
  public LogicalPortMap(int portID)
  {
    var port = DataSystem.Instance.Data.ports[portID.ToString()];

    _buildings = port.buildings;
    _collisionIndices = DataSystem.Instance.Data.tilesets[port.tileset.ToString()].collisionIndices;
    _tilemap = new byte[9216];
    Array.Copy(DataSystem.Instance.PortTilemapsBin.bytes, portID * 9216 - 9216, _tilemap, 0, 9216);
  }

  public bool CollisionAt(Vector2Int position)
  {
    var offsetsToCheck = new int[] { 0, 1 };

    for (int i = 0; i < offsetsToCheck.Length; i++)
    {
      var tile = Tiles(position + new Vector2Int(offsetsToCheck[i], 1));
      if (tile >= _collisionIndices.either)
      {
        return true;
      }

      if (i == 0)
      {
        if (tile >= _collisionIndices.left)
        {
          return true;
        }
        else
        {
          continue;
        }
      }

      if (tile >= _collisionIndices.right && tile < _collisionIndices.left)
      {
        return true;
      }
    }

    Debug.Log($"collision at {position}");
    return false;
  }

  public int BuildingAt(Vector3Int position)
  {
    foreach (var item in _buildings)
    {
      var id = item.Key;
      var building = item.Value;
      if (position.x == building.x && position.y == building.y)
      {
        Debug.Log($"building at {position}");
        return int.Parse(id);
      }
    }
    return 0;
  }

  private byte Tiles(Vector2Int position)
  {
    var x = position.x;
    var y = position.y;
    Debug.Log($"tile {position}");
    return _tilemap[y * 96 + x];
  }

}
