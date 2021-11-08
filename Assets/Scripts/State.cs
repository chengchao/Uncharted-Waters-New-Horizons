using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SpawnManagerScriptableObject", order = 1)]
public class State : ScriptableObject
{
    public int BuildingID;
    public void EnterBuilding(int buildingID)
    {
        BuildingID = buildingID;
    }

    public void ExitBuilding()
    {
        BuildingID = 0;
    }
}
