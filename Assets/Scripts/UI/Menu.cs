using UnityEngine;
using UnityEngine.InputSystem;

namespace UI
{
    public class Menu : GUIObject
    {

        public GameObject menu;
        public InputActionProperty showButton;

        protected override void Update()
        {
            base.Update();
            
            if (showButton.action.WasPressedThisFrame())
            {
                menu.SetActive(!menu.activeSelf);
                
            }
        }
    }
}
