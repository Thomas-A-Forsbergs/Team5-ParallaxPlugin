using UnityEngine;

namespace Plugins.ParallaxScroller.Scripts.Player {
    public class SamplePlayerController : MonoBehaviour {
        [SerializeField] Transform player;
        public float playerSpeed = 5f;

        void Update() {
            if (Input.GetAxis("Horizontal") >= 0.1)
                player.rotation = Quaternion.LookRotation(Vector3.left);
            else if (Input.GetAxis("Horizontal") < 0.1)
                player.rotation = Quaternion.LookRotation(Vector3.right);

            transform.position += new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0) * (playerSpeed * Time.deltaTime);
        }
    }
}