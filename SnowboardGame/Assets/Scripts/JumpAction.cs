using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SnowboardGame
{
    public class JumpAction : MonoBehaviour
    {
        [SerializeField] private Rigidbody jumpingPlayer;
        // Start is called before the first frame update
        public void jump()
        {
            jumpingPlayer.AddForce(Vector3.up * 300f, ForceMode.Impulse);
        }
    }
}