using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortMap
{
    public static PortData Load(String data)
    {
        var rawPortData = RawPortData.FromJson(data);
        var portData = PortData.FromRawPortData(rawPortData);
        return portData;
    }
}

public class PortData
{
    public Dictionary<String, Port> ports;
    public Dictionary<String, Tileset> tilesets;
    public Dictionary<String, Character> characters;
    public Dictionary<String, Building> buildings;
    public String[] regions;
    public String[] markets;

    public static PortData FromRawPortData(RawPortData rawPortData)
    {
        Dictionary<String, Port> ports = new Dictionary<string, Port>();
        foreach (RawPortData.Port rawPort in rawPortData.ports)
        {
            Port port = new Port();
            port.name = rawPort.name;
            port.x = rawPort.x;
            port.y = rawPort.y;
            port.economy = rawPort.economy;
            port.industry = rawPort.industry;
            port.allegiances = rawPort.allegiances;
            port.itemShop = new Port.ItemShop
            {
                regular = rawPort.itemShop.regular
            };
            port.economyId = rawPort.economyId;
            port.industryId = rawPort.industryId;

            if (rawPort.buildings != null)
            {
                port.buildings = new Dictionary<string, Port.Building>();
                foreach (RawPortData.Port.Building rawPortBuilding in rawPort.buildings)
                {
                    Port.Building portBuilding = new Port.Building();
                    portBuilding.x = rawPortBuilding.x;
                    portBuilding.y = rawPortBuilding.y;
                    port.buildings[rawPortBuilding.id] = portBuilding;
                }
            }

            port.tileset = rawPort.tileset;
            ports[rawPort.id] = port;
        }

        Dictionary<String, Tileset> tilesets = new Dictionary<string, Tileset>();
        foreach (RawPortData.Tileset rawTileset in rawPortData.tilesets)
        {
            Tileset tileset = new Tileset();
            tileset.collisionIndices = new Dictionary<string, CollisionIndex>();
            if (rawTileset.collisionIndices != null)
            {
                foreach (RawPortData.Tileset.CollisionIndex rawTilesetCollisionIndex in rawTileset.collisionIndices)
                {
                    CollisionIndex collisionIndex = new CollisionIndex();
                    collisionIndex.left = rawTilesetCollisionIndex.left;
                    collisionIndex.right = rawTilesetCollisionIndex.right;
                    collisionIndex.either = rawTilesetCollisionIndex.either;
                    tileset.collisionIndices[rawTilesetCollisionIndex.id] = collisionIndex;
                }
            }

            tilesets[rawTileset.id] = tileset;
        }

        Dictionary<String, Character> characters = new Dictionary<string, Character>();
        foreach (RawPortData.Character rawCharacter in rawPortData.characters)
        {
            Character character = new Character();
            character.spawn = new Spawn();
            character.spawn.building = rawCharacter.spawn.building;
            character.spawn.offset = new Offset();
            character.spawn.offset.x = rawCharacter.spawn.offset.x;
            character.spawn.offset.y = rawCharacter.spawn.offset.y;
            character.startFrame = rawCharacter.startFrame;
            character.isPlayer = rawCharacter.isPlayer;
            characters[rawCharacter.id] = character;
        }

        Dictionary<String, Building> buildings = new Dictionary<string, Building>();
        foreach (RawPortData.Building rawBuilding in rawPortData.buildings)
        {
            Building building = new Building();
            building.menu = rawBuilding.menu;
            building.name = rawBuilding.name;
            buildings[rawBuilding.id] = building;
        }

        PortData portData = new PortData()
        {
            ports = ports,
            tilesets = tilesets,
            characters = characters,
            buildings = buildings,
            regions = rawPortData.regions,
            markets = rawPortData.markets
        };

        return portData;
    }

    public class Port
    {
        public String name;
        public int x, y, economy, industry;
        public int[] allegiances;
        public int regionId;
        public ItemShop itemShop;
        public int economyId;
        public int industryId;
        public Dictionary<String, Building> buildings;
        public int tileset;

        public class ItemShop
        {
            public int[] regular;
        }

        public class Building
        {
            public int x, y;
        }
    }

    public class Tileset
    {
        public Dictionary<String, CollisionIndex> collisionIndices;
    }

    public class CollisionIndex
    {
        public int right, left, either;
    }

    public class Character
    {
        public int startFrame;
        public Spawn spawn;
        public bool isPlayer;
    }

    public class Spawn
    {
        public int building;
        public Offset offset;
    }

    public class Offset
    {
        public int x, y;
    }

    public class Building
    {
        public String name;
        public String[] menu;
    }
}

[System.Serializable]
public class RawPortData
{
    public Port[] ports;
    public Tileset[] tilesets;
    public Character[] characters;
    public Building[] buildings;
    public String[] regions;
    public String[] markets;

    public static RawPortData FromJson(String json)
    {
        return JsonUtility.FromJson<RawPortData>(json);
    }

    [System.Serializable]
    public class Port
    {
        public String name;
        public int x, y, economy, industry;
        public int[] allegiances;
        public int regionId;
        public ItemShop itemShop;
        public int economyId;
        public int industryId;
        public Building[] buildings;
        public int tileset;
        public String id;

        [System.Serializable]
        public class ItemShop
        {
            public int[] regular;
        }

        [System.Serializable]
        public class Building
        {
            public int x, y;
            public String id;
        }
    }

    [System.Serializable]
    public class Tileset
    {
        public CollisionIndex[] collisionIndices;
        public String id;
        [System.Serializable]
        public class CollisionIndex
        {
            public int right, left, either;
            public String id;
        }
    }

    [System.Serializable]
    public class Character
    {
        public int startFrame;
        public Spawn spawn;
        public bool isPlayer;
        public String id;
    }

    [System.Serializable]
    public class Spawn
    {
        public int building;
        public Offset offset;
    }

    [System.Serializable]
    public class Offset
    {
        public int x, y;
    }

    [System.Serializable]
    public class Building
    {
        public String name;
        public String[] menu;
        public String id;
    }
}
