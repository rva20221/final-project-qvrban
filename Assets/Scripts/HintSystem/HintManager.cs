using System;
using System.Collections.Generic;
using System.Linq;
using UI;
using UnityEngine;

namespace HintSystem
{
    public class HintManager : MonoBehaviour
    {
        [SerializeField] private List<HintCollection> hintCollections;
        
        private static HintManager _hintManager;

        public static HintManager instance
        {
            get
            {
                if (!_hintManager)
                {
                    _hintManager = FindObjectOfType<HintManager>();

                    if (!_hintManager)
                    {
                        Debug.LogError("There needs to be one active EventManager script on a GameObject in your scene.");
                    }
                    else
                    {
                        _hintManager.Init();
                    }
                }

                return _hintManager;
            }
        }

        private void Init()
        {
            if (hintCollections == null)
            {
                hintCollections = new List<HintCollection>();
            }
        }

        public static HintCollection TryGetHintCollection(string id)
        {
            return instance.hintCollections.FirstOrDefault(x => x.CollectionId == id);
        }
        
        private void OnDestroy()
        {
            hintCollections.Clear();
        }
    }
}
