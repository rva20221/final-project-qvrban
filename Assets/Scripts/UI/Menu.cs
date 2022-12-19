using UnityEngine;
using UnityEngine.InputSystem;

namespace UI
{
    public class Menu : MonoBehaviour
    {

        public GameObject menu;
        public InputActionProperty showButton;

        protected void Update()
        {
            if (showButton.action.WasPressedThisFrame())
            {
                menu.SetActive(!menu.activeSelf);
                
            }
        }
    }
}
