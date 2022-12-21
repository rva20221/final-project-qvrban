using System;
using HintSystem;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class HintPanel : MonoBehaviour
    {
        #region Private Properties

        [SerializeField] private GameObject uiGameObject;
        [SerializeField] private TextMeshProUGUI headerField;
        [SerializeField] private TextMeshProUGUI textField;
        [SerializeField] private Button previousButton;
        [SerializeField] private Button nextButton;

        [SerializeField] private string eventTrigger;
        [SerializeField] private bool isTriggeredByEvent;
        private bool isEnableSequence;

        private HintCollection currentHintCollection;
        private int _currentHintIndex;


        private bool isVisible;
        
        #endregion
        

        #region Public Methods

        public void CloseHint()
        {
            isVisible = false;
            uiGameObject.SetActive(isVisible);
        }

        public void OpenHint(HintCollection hintCollection)
        {
            isVisible = true;
            uiGameObject.SetActive(isVisible);
            SetCollection(hintCollection);
            
        }

        #endregion


        #region Private Methods

        private void Start()
        {
            if (!isTriggeredByEvent) return;

            EventManager.AddHintListener(eventTrigger, delegate(HintEventData hintEventData)
            {
                OpenHint(hintEventData.HintCollection);
            });
        }

        private void NextHint()
        {
            _currentHintIndex++;
            UpdateHintPanel(_currentHintIndex);
        }

        private void PreviousHint()
        {
            _currentHintIndex--;
            UpdateHintPanel(_currentHintIndex);
        }
        
        private void SetCollection(HintCollection hintCollection)
        {
            currentHintCollection = hintCollection;
            _currentHintIndex = 0;
            
            isEnableSequence = currentHintCollection.Hints.Count > 1;
            
            if (isEnableSequence)
            {
                nextButton.onClick.AddListener(NextHint);
                previousButton.onClick.AddListener(PreviousHint);
            }
            
            UpdateHintPanel(_currentHintIndex);
        }

        private void UpdateHintPanel(int index)
        {
            if (!IsIndexValid(index))
            {
                return;
            }
            
            Hint hint = currentHintCollection.Hints[index];
            textField.text = hint.Text;
            headerField.text = hint.Header;
            
            if (!isEnableSequence) return;

            bool isNextActive = true;
            bool isPreviousActive = true;

            if (index == currentHintCollection.Hints.Count - 1)
            {
                isNextActive = false;
            }
            
            if (index == 0)
            {
                isPreviousActive = false;
            }
            
            nextButton.gameObject.SetActive(isNextActive);
            previousButton.gameObject.SetActive(isPreviousActive);
        }

        private bool IsIndexValid(int index)
        {
            int count = currentHintCollection.Hints.Count;
            return index >= 0 || index < count;
        }

        #endregion
        
    }
}
