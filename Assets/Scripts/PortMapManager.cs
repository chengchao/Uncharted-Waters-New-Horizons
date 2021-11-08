using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEditor;
using System.Linq;

public class PortMapManager : MonoBehaviour
{
    [SerializeField] private Tilemap _portMap;
    [SerializeField] private int _portId;

    public void SaveMap()
    {
        var newPort = ScriptableObject.CreateInstance<ScriptablePort>();
        newPort.PortId = _portId;
        newPort.name = $"Port_{_portId}";
        newPort.Tiles = GetTilesFromMap(_portMap).ToList();
        ScriptableObjectUtils.SavePortFile(newPort);

        static IEnumerable<SavedTile> GetTilesFromMap(Tilemap map)
        {
            foreach (var pos in map.cellBounds.allPositionsWithin)
            {
                if (map.HasTile(pos))
                {
                    var tile = map.GetTile<Tile>(pos);
                    yield return new SavedTile()
                    {
                        Position = pos,
                        Tile = tile
                    };
                }
            }
        }
    }

    public void LoadMap()
    {
        var port = Resources.Load<ScriptablePort>($"Ports/Port_{_portId}");
        if (port == null)
        {
            return;
        }

        ClearMap();

        foreach (var savedTile in port.Tiles)
        {
            _portMap.SetTile(savedTile.Position, savedTile.Tile);
        }
    }

    public void ClearMap()
    {
        var maps = FindObjectsOfType<Tilemap>();

        foreach (var tilemap in maps)
        {
            tilemap.ClearAllTiles();
        }
    }
}

#if UNITY_EDITOR

public static class ScriptableObjectUtils
{
    public static void SavePortFile(ScriptablePort port)
    {
        AssetDatabase.CreateAsset(port, $"Assets/PortMap/Resources/Ports/{port.name}.asset");
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }
}

#endif
