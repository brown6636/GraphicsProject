using UnityEngine.InputSystem;
using UnityEngine;

namespace BrownBronson.Lab1
{
    public class MovementController : MonoBehaviour
    {
        [SerializeField] private Rigidbody playerToMove;
        [SerializeField] private float speed = 5f;
        private InputAction moveAction;
        Vector3 angVel;
        public void Initialize(InputAction moveAction)
        {
            this.moveAction = moveAction;
            this.moveAction.Enable();
            angVel = new Vector3(0, 100, 0);
        }
        private void FixedUpdate()
        {
            var rInput =  moveAction.ReadValue<Vector2>().x;
            playerToMove.MoveRotation(playerToMove.rotation * Quaternion.Euler(angVel * rInput * Time.fixedDeltaTime));
            angleLock();
            applyForce();
        }
        private void applyForce()
        {
            if (playerToMove.rotation.eulerAngles.y < 360 && playerToMove.rotation.eulerAngles.y > 270) 
                playerToMove.AddForce(Vector3.left * 5 * ((360 - playerToMove.rotation.eulerAngles.y)));
            if (playerToMove.rotation.eulerAngles.y > 0 && playerToMove.rotation.eulerAngles.y < 90) 
                playerToMove.AddForce(Vector3.right * 5 *  (playerToMove.rotation.eulerAngles.y));
        }
        private void angleLock()
        {
            if (playerToMove.rotation.eulerAngles.y > 90)
            {
                if (playerToMove.rotation.eulerAngles.y < 270 && playerToMove.rotation.eulerAngles.y > 180) playerToMove.rotation = Quaternion.Euler(playerToMove.rotation.eulerAngles.x, 269, playerToMove.rotation.eulerAngles.z);
            }
            if (playerToMove.rotation.eulerAngles.y < 270)
            {
                if (playerToMove.rotation.eulerAngles.y > 90 && playerToMove.rotation.eulerAngles.y < 180) playerToMove.rotation = Quaternion.Euler(playerToMove.rotation.eulerAngles.x, 89, playerToMove.rotation.eulerAngles.z);
            }
        }
    }
}