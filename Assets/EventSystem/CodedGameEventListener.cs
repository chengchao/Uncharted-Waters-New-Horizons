using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable]
public class CodedGameEventListener : IGameEventListener
{
    [SerializeField] private GameEvent _gameEvent;
    private Action _action;

    public void OnEventRaised()
    {
        _action?.Invoke();
    }

    public void OnEnable(Action action)
    {
        if (_gameEvent != null)
        {
            _gameEvent.RegisterListener(this);
            _action = action;
        }
    }

    public void OnDisable()
    {
        if (_gameEvent != null)
        {
            _gameEvent.UnregisterListener(this);
            _action = null;
        }

    }
}
