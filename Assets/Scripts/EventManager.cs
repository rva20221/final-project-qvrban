using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    private delegate void Hint();
    private Dictionary<string, UnityEvent> _events;
    private static EventManager _eventManager;
    
    public static EventManager instance
    {
        get
        {
            if (!_eventManager)
            {
                _eventManager = FindObjectOfType<EventManager>();

                if (!_eventManager)
                {
                    Debug.LogError("There needs to be one active EventManager script on a GameObject in your scene.");
                }
                else
                {
                    _eventManager.Init();
                }
            }

            return _eventManager;
        }
    }

    private void Init()
    {
        if (_events == null)
        {
            _events = new Dictionary<string, UnityEvent>();
        }
    }

    public static void AddListener(string eventName, UnityAction listener)
    {
        UnityEvent evt = null;
        if (instance._events.TryGetValue(eventName, out evt))
        {
            evt.AddListener(listener);
        }
        else
        {
            evt = new UnityEvent();
            evt.AddListener(listener);
            instance._events.Add(eventName, evt);
        }
    }
    
    public static void RemoveListener(string eventName, UnityAction listener)
    {
        if (_eventManager == null)
        {
            return;
        }

        UnityEvent evt = null;
        if (instance._events.TryGetValue(eventName, out evt))
        {
            evt.RemoveListener(listener);
        }
    }

    public static void TriggerEvent(string eventName)
    {
        UnityEvent evt = null;
        if (instance._events.TryGetValue(eventName, out evt))
        {
            evt.Invoke();
        }
    }
}
