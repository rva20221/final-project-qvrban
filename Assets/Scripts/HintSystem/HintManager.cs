using System;
using System.Collections.Generic;
using UI;
using UnityEngine;

namespace HintSystem
{
    public class HintManager : MonoBehaviour
    {
        [SerializeField] private HintPanel hintPanel;
    
        [SerializeField] private List<HintCollection> hintCollections;

        void Start()
        {
            RegisterCollectionEvents();
        }

        private void RegisterCollectionEvents()
        {
            if (hintCollections.Count == 0) return;

            foreach (HintCollection hintCollection in hintCollections)
            {
                EventManager.AddListener(hintCollection.EventName, delegate
                {
                    UpdateUI(hintCollection);
                });
            }
            
            EventManager.TriggerEvent("onTest");
        }

        private void UpdateUI(HintCollection hintCollection)
        {
            hintPanel.OpenHint(hintCollection);
        }

        private void OnDestroy()
        {
            hintCollections.Clear();
        }
    }
}
