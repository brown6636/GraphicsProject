using UnityEngine;

namespace SnowboardGame
{
    public class FollowWithOffset : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private Vector3 offset;

        private void Update()
        {
            transform.position =  offset + target.position;
        }
    }
}