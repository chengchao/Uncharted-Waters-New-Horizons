using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DataSystem : AbstractSingleton<DataSystem>
{
    public PortData Data { get; private set; }
    public Tile[] PortTiles { get; private set; }
    public TextAsset PortTilemapsBin { get; private set; }

    public override void Init()
    {
        Load();
    }

    private void Load()
    {
        LoadPortTiles();
        LoadData();
        LoadPortTilemapsBin();
    }

    private void LoadPortTiles()
    {
        PortTiles = new Tile[6720];
        var tiles = Resources.LoadAll<Tile>("Palettes");
        foreach (Tile tile in tiles)
        {
            // the name looks like "port-tilesets_0"
            string tileIndexString = tile.name.Substring("port-tilesets_".Length, tile.name.Length - "port-tilesets_".Length);
            int tileIndex = Int16.Parse(tileIndexString);
            PortTiles[tileIndex] = tile;
        }
    }

    private void LoadData()
    {
        Data = PortDataLoader.Load();
    }

    private void LoadPortTilemapsBin()
    {
        PortTilemapsBin = Resources.Load<TextAsset>("port-tilemaps.bin");
    }
}
