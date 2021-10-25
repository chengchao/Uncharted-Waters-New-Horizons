using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Tilemaps;

public class PortMapLoaderEditor : MonoBehaviour
{
    [MenuItem("AssetDatabase/LoadAssetExample")]
    static void ImportExample()
    {
        var tiles = Resources.LoadAll<Tile>("Palettes");
        Debug.Log(tiles);

        var data = Resources.Load<TextAsset>("parsable_data");
        // var data = AssetDatabase.LoadAssetAtPath<TextAsset>("Assets/PortMap/Resources/parsable_data.json");
        Debug.Log(data);

        // var partData = PortMap.Load(data.ToString());
        // Debug.Log(partData.ports["1"]);


    }
}
