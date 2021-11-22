using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// [System.Serializable]
// public class MyStringEvent : UnityEvent<string>
// {
// }

[CreateAssetMenu(fileName = "State", menuName = "ScriptableObject/State")]
public class SOState : ScriptableObject
{
    public BUILDING_STATE BuildingState;
    [SerializeField] private GameEvent _enterBuildingEvent;
    [SerializeField] private GameEvent _leaveBuildingEvent;

    public void EnterBuilding(BUILDING_STATE building)
    {
        BuildingState = building;
        _enterBuildingEvent.Raise();
    }

    public void LeaveBuilding()
    {
        BuildingState = BUILDING_STATE.NOT_IN_BUILDING;
        _leaveBuildingEvent.Raise();
    }
}

[Serializable]
public enum BUILDING_STATE
{
    NOT_IN_BUILDING = 0,
    HARBOR = 1,
}



