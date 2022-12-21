using UnityEngine.Events;

namespace HintSystem
{
    public class HintEventData
    {
        public HintCollection HintCollection;

        public HintEventData(HintCollection hintCollection)
        {
            HintCollection = hintCollection;
        }
    }

    [System.Serializable]
    public class HintEvent : UnityEvent<HintEventData> {}
}