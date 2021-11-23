using BrownBronson;
using BrownBronson.Input;
using UnityEngine;

namespace BrownBronson.Lab1
{
    public class InputManager : MonoBehaviour
    {
        [SerializeField] private MovementController movementController;
        [SerializeField] private CameraSwitcher cameraSwitcher;
        [SerializeField] private Respawner respawner;
        private BrownInputActions inputScheme;
        private RespawnHandler respawnHandler;
        private void Awake()
        {
            inputScheme = new BrownInputActions();
            movementController.Initialize(inputScheme.Player.Move);
            respawnHandler = new RespawnHandler(inputScheme.Player.Reset, respawner);
        }
        private void OnEnable()
        {
            var _ = new QuitHandler(inputScheme.Player.Quit);
            var nextCameraHandler = new NextCameraHandler(inputScheme.Player.CameraSwitch, this.cameraSwitcher);
        }
    }
}