using UnityEngine;

namespace BrownBronson.Lab1
{
    public class Respawner : MonoBehaviour
    {
        private Vector3 startPosition;
        private Quaternion startRotation;
        private void Start()
        {
            startPosition = transform.position;
            startRotation = transform.rotation;
        }

        public void respawn()
        {
            transform.position = startPosition;
            transform.rotation = startRotation;
        }

    }
}
