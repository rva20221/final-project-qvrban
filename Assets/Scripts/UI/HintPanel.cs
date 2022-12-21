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

        [SerializeField] private TextMeshProUGUI headerField;
        [SerializeField] private TextMeshProUGUI textField;
        [SerializeField] private Button previousButton;
        [SerializeField] private Button nextButton;
        
        private HintCollection currentHintCollection;
        private int _currentHintIndex;
        
        #endregion

        #region Public Methods
        
        public void CloseHint()
        {
            gameObject.SetActive(false);
        }

        public void OpenHint(HintCollection hintCollection)
        {
            gameObject.SetActive(true);
            SetCollection(hintCollection);
        }

        #endregion


        #region Private Methods

        private void Start()
        {
            nextButton.onClick.AddListener(NextHint);
            previousButton.onClick.AddListener(PreviousHint);
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
            UpdateHintPanel(_currentHintIndex);
        }

        private void UpdateHintPanel(int index)
        {
            Hint hint = currentHintCollection.Hints[index];
            textField.text = hint.Text;
            headerField.text = hint.Header;

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

        #endregion
        
    }
}
