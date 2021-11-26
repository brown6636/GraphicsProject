using UnityEngine.InputSystem;

namespace SnowboardGame
{
    public class RespawnHandler
    {
        private Respawner respawner;
        private InputAction respawnAction;
        public RespawnHandler(InputAction respawnAction, Respawner respawner)
        {
            this.respawnAction = respawnAction;
            this.respawnAction.Enable();
            this.respawner = respawner;
            respawnAction.performed += RespawnAction_performed;
            respawnAction.Enable();
        }

        private void RespawnAction_performed(InputAction.CallbackContext obj)
        {
            respawner.respawn();
        }

    }
}