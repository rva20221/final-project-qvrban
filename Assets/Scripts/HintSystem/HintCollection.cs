using System;
using System.Collections.Generic;
using UnityEngine.Events;

namespace HintSystem
{
    [Serializable]
    public class HintCollection
    {
        public string CollectionId;
        public List<Hint> Hints;

        public HintCollection(string collectionId, List<Hint> hints)
        {
            CollectionId = collectionId;
            Hints = hints;
        }
    }
}