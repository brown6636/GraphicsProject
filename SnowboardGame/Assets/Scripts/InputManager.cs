using BrownBronson;
using BrownBronson.Input;
using UnityEngine;

namespace SnowboardGame
{
    public class InputManager : MonoBehaviour
    {
        [SerializeField] private MovementController movementController;
        [SerializeField] private CameraSwitcher cameraSwitcher;
        [SerializeField] private Respawner respawner;
        [SerializeField] private JumpAction jumpAction;
        private BrownInputActions inputScheme;
        private RespawnHandler respawnHandler;
        private JumpHandler jumpHandler;
        private void Awake()
        {
            inputScheme = new BrownInputActions();
            movementController.Initialize(inputScheme.Player.Move);
            respawnHandler = new RespawnHandler(inputScheme.Player.Reset, respawner);
            jumpHandler = new JumpHandler(inputScheme.Player.Jump, jumpAction);
        }
        private void OnEnable()
        {
            var _ = new QuitHandler(inputScheme.Player.Quit);
            var nextCameraHandler = new NextCameraHandler(inputScheme.Player.CameraSwitch, this.cameraSwitcher);
        }
    }
}