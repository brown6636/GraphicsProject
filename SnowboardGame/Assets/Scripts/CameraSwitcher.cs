using UnityEngine;

namespace SnowboardGame
{
    public class CameraSwitcher : MonoBehaviour
    {
        [SerializeField] private Camera[] cameras;
        [SerializeField] private Camera defaultCamera;
        private int index = 0;

        private void Start()
        {
            index = 0;
            foreach (Camera camera in cameras)
            {
                camera.enabled = false;
            }
            defaultCamera.enabled = true;
        }

        public void NextCamera()
        {
            if (index == 3) 
            {
                cameras[0].enabled = true;
                cameras[3].enabled = false;
                index = 0;
            }
            else
            {
                cameras[index + 1].enabled = true;
                cameras[index].enabled = false;
                index++;
            }
        }

    }
}
