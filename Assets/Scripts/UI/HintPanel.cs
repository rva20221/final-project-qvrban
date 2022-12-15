using HintSystem;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class HintPanel : GUIObject
    {
        #region Private Properties
        
        [SerializeField] private TextMeshProUGUI textField;
        [SerializeField] private Button previousButton;
        [SerializeField] private Button nextButton;
        
        private HintCollection currentHintCollection;
        private int _currentHintIndex;
        
        #endregion

        #region Public Methods

        public void SetCollection(HintCollection hintCollection)
        {
            currentHintCollection = hintCollection;
            _currentHintIndex = 0;
            UpdateHintPanel(_currentHintIndex);
        }

        public void CloseHint()
        {
            gameObject.SetActive(false);
        }

        public void OpenHint()
        {
            gameObject.SetActive(true);
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

        private void UpdateHintPanel(int index)
        {

            textField.text = currentHintCollection.Hints[index].Text;

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
