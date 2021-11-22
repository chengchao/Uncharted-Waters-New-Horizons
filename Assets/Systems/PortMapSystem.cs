using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortMapSystem : AbstractSingleton<PortMapSystem>
{
    [SerializeField] private CodedGameEventListener _dataLoadedEventListener;
    [SerializeField] private SOState _state;
    private PortMap _map;

    private void OnEnable()
    {
        _dataLoadedEventListener?.OnEnable(OnDataLoadedEventRaised);
    }

    private void OnDisable()
    {
        _dataLoadedEventListener?.OnDisable();
    }

    private void OnDataLoadedEventRaised()
    {
        Debug.Log($"OnDataLoadedEventRaised");
        //TODO: init port map
    }

    public override void Init()
    {
        Debug.Log("PortMapSystem Init");
    }

    public bool HasCollisionAt(Vector2Int position)
    {
        return _map.HasBuildingAt(position);
    }
}
