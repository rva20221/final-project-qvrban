using System;
using System.Collections.Generic;
using UnityEngine.Events;

namespace HintSystem
{
    [Serializable]
    public class HintCollection
    {
        public List<Hint> Hints;
        public string EventName;

        public HintCollection(List<Hint> hints, string eventName)
        {
            Hints = hints;
            EventName = eventName;
        }
    }
}