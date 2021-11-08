using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ScriptablePort : ScriptableObject
{
    public int PortId;
    public List<SavedTile> Tiles;
}

[Serializable]
public class SavedTile
{
    public Vector3Int Position;
    public Tile Tile;
}
