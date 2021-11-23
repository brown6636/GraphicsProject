using UnityEngine.InputSystem;
using UnityEngine;

namespace BrownBronson.Lab1
{
    public class MovementController : MonoBehaviour
    {
        [SerializeField] private Rigidbody playerToMove;
        [SerializeField] private float speed = 5f;
        private InputAction moveAction;
        Vector3 RFL;
        Vector3 RFR;
        public void Initialize(InputAction moveAction)
        {
            this.moveAction = moveAction;
            this.moveAction.Enable();
            RFL = new Vector3(0, -60, 0);
            RFR = new Vector3(0, 60, 0);
        }
        private void FixedUpdate()
        {
            var rInput =  moveAction.ReadValue<Vector2>().x;
            if (rInput > 0)
            {
                playerToMove.MoveRotation(playerToMove.rotation * Quaternion.Euler(RFR * Time.fixedDeltaTime));
                    playerToMove.AddForce(Vector3.right * 15 * (playerToMove.rotation.eulerAngles.y % 180));
                    print(playerToMove.rotation.eulerAngles.y % 180);
            }
            else if (rInput < 0)
            {
                playerToMove.MoveRotation(playerToMove.rotation * Quaternion.Euler(RFL * Time.fixedDeltaTime));
                playerToMove.AddForce(Vector3.left * 15 * ((playerToMove.rotation.eulerAngles.y % 180)/2));
                print((playerToMove.rotation.eulerAngles.y % 180) / 2);
            }
        }
    }
}