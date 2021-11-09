using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PortMapLoader : MonoBehaviour
{
    [SerializeField] private Tilemap _tilemap;
    [SerializeField] private int _portId;

    public PortData Data { get; private set; }
    private PortData.Port _port;

    private Tile[] _portTiles;

    void Start()
    {
        _portTiles = new Tile[6720];
        Load(_portId, TimeOfDay.DAY);
    }

    private void Load(int portId, TimeOfDay timesOfDay)
    {
        var tiles = Resources.LoadAll<Tile>("Palettes");
        foreach (Tile tile in tiles)
        {
            // the name looks like "port-tilesets_0"
            string tileIndexString = tile.name.Substring("port-tilesets_".Length, tile.name.Length - "port-tilesets_".Length);
            int tileIndex = Int16.Parse(tileIndexString);
            _portTiles[tileIndex] = tile;
        }

        Data = PortDataLoader.Load();
        _port = Data.ports[portId.ToString()];

        var portTilemapsBin = Resources.Load<TextAsset>("port-tilemaps.bin");
        byte[] portMap = new byte[9216];
        Array.Copy(portTilemapsBin.bytes, portId * 9216 - 9216, portMap, 0, 9216);
        DrawMap(portMap, timesOfDay);
    }

    private void DrawMap(byte[] portMap, TimeOfDay timeOfDay)
    {
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
