using UnityEngine.InputSystem;

namespace SnowboardGame
{
    public class NextCameraHandler
    {
        private CameraSwitcher CameraSwitcher;
        private InputAction nextCameraAction;
        public NextCameraHandler(InputAction nextCameraAction, CameraSwitcher cameraSwitcher)
        {
            this.nextCameraAction = nextCameraAction;
            this.nextCameraAction.Enable();
            this.CameraSwitcher = cameraSwitcher;
            nextCameraAction.performed += NextCameraAction_performed;
            nextCameraAction.Enable();
        }

        private void NextCameraAction_performed(InputAction.CallbackContext obj)
        {
            CameraSwitcher.NextCamera();
        }

    }
}