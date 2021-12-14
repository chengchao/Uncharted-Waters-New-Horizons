using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortStateManager : MonoBehaviour
{
  [SerializeField] private CodedGameEventListener _enterBuildingListener;
  [SerializeField] private CodedGameEventListener _leaveBuildingListener;

  [SerializeField] private SOState _state;

  [SerializeField] private GameObject _port;
  [SerializeField] private GameObject _building;

  private void OnEnable()
  {
    _enterBuildingListener?.OnEnable(OnEnterBuildingEventRaised);
    _leaveBuildingListener?.OnEnable(OnLeaveBuildingEventRaised);
  }

  private void OnDisable()
  {
    _enterBuildingListener?.OnDisable();
    _leaveBuildingListener?.OnDisable();
  }

  private void OnEnterBuildingEventRaised()
  {
    Debug.Log($"OnEnterBuildingEventRaised {_state.BuildingState}");
    _port.SetActive(false);
    _building.SetActive(true);
  }

  private void OnLeaveBuildingEventRaised()
  {
    Debug.Log("OnLeaveBuildingEventRaised");
    _building.SetActive(false);
    _port.SetActive(true);
  }

  public void EnterBuilding()
  {
    _state.EnterBuilding(BUILDING_STATE.HARBOR);
  }

  public void LeaveBuilding()
  {
    _state.LeaveBuilding();
  }
}
