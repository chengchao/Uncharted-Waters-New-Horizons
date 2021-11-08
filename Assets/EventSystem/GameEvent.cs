using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Event", menuName = "Events/Game Event")]
public class GameEvent : ScriptableObject
{
    private readonly List<IGameEventListener> _eventListeners = new List<IGameEventListener>();

    public void Raise()
    {
        for (int i = _eventListeners.Count - 1; i >= 0; i--)
        {
            _eventListeners[i].OnEventRaised();
        }
    }

    public void RegisterListener(IGameEventListener listener)
    {
        if (_eventListeners.Contains(listener))
        {
            return;
        }
        _eventListeners.Add(listener);
    }

    public void UnregisterListener(IGameEventListener listener)
    {
        if (!_eventListeners.Contains(listener))
        {
            return;
        }
        _eventListeners.Remove(listener);
    }
}
