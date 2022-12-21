using System;
using System.Collections.Generic;
using HintSystem;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    private Dictionary<string, UnityEvent> _events;
    private Dictionary<string, HintEvent> _hintEvents;
    
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
            _hintEvents = new Dictionary<string, HintEvent>();
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

    public static void AddHintListener(string eventName, UnityAction<HintEventData> listener)
    {
        HintEvent evt = null;
        if (instance._hintEvents.TryGetValue(eventName, out evt))
        {
            evt.AddListener(listener);
        }
        else
        {
            evt = new HintEvent();
            evt.AddListener(listener);
            instance._hintEvents.Add(eventName, evt);
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
    
    public static void TriggerHintEvent(string eventName, HintEventData hintEventData)
    {
        HintEvent evt = null;
        if (instance._hintEvents.TryGetValue(eventName, out evt))
        {
            evt.Invoke(hintEventData);
        }
    }
    
    public static void RemoveHintListener(string eventName, UnityAction<HintEventData> listener)
    {
        if (_eventManager == null)
        {
            return;
        }

        HintEvent evt = null;
        if (instance._hintEvents.TryGetValue(eventName, out evt))
        {
            evt.RemoveListener(listener);
        }
    }


    private void OnDestroy()
    {
        _events.Clear();
    }
}
