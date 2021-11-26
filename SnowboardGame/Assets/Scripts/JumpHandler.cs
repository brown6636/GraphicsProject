using UnityEngine.InputSystem;
using UnityEngine;

namespace SnowboardGame
{
    public class JumpHandler
    {
        private JumpAction jumpAction;
        private InputAction jumpButton;
        // Start is called before the first frame update
        public JumpHandler(InputAction jumpButton, JumpAction jumpAction)
        {
            this.jumpButton = jumpButton;
            this.jumpButton.Enable();
            this.jumpAction = jumpAction;
            jumpButton.performed += JumpAction_performed;
            jumpButton.Enable();
        }
        private void JumpAction_performed(InputAction.CallbackContext obj)
        {
            jumpAction.jump();
        }
    }
}