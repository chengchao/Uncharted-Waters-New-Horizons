using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PortMapLoader : MonoBehaviour
{
    [SerializeField] private Tilemap _tilemap;
    [SerializeField] private int _portId;

    private PortData.Port _port;

    private Tile[] _portTiles;

    void Start()
    {
        _portTiles = new Tile[6720];
        Load(_portId, TimeOfDay.DAY);
    }

    private void Load(int portId, TimeOfDay timesOfDay)
    {
        var data = DataSystem.Instance.Data;
        _port = data.ports[portId.ToString()];

        _portTiles = DataSystem.Instance.PortTiles;

        var portTilemapsBin = DataSystem.Instance.PortTilemapsBin;
        byte[] portMap = new byte[9216];
        Array.Copy(portTilemapsBin.bytes, portId * 9216 - 9216, portMap, 0, 9216);

        DrawMap(portMap, timesOfDay);
    }

    private void DrawMap(byte[] portMap, TimeOfDay timeOfDay)
    {
        Debug.Log($"DrawMap {portMap[0]}, {_portTiles.Length}");
        for (int i = 0; i < 96; i++)
        {
            for (int j = 0; j < 96; j++)
            {
                _tilemap.SetTile(new Vector3Int(i, -j, 0), _portTiles[TilesetOffset(timeOfDay) * 240 + Tiles(portMap, i, j)]);
            }
        }
    }

    private int Tiles(byte[] portMap, int i, int j)
    {
        return portMap[j * 96 + i];
    }

    private int TilesetOffset(TimeOfDay timeOfDay)
    {
        return _port.tileset * Enum.GetNames(typeof(TimeOfDay)).Length + Array.IndexOf(Enum.GetValues(timeOfDay.GetType()), timeOfDay); ;
    }

    public enum TimeOfDay
    {
        DAWN,
        DAY,
        DUSK,
        NIGHT,
    }
}
