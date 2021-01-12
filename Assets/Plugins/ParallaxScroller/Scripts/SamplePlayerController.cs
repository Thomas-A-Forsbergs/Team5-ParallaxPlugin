using UnityEngine;

namespace Plugins.ParallaxScroller.Scripts{
    public class SamplePlayerController : MonoBehaviour{
    
        public float playerSpeed = 0.1f;
    

        // Update is called once per frame
        void Update()
        {
            transform.position += new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"),0) * (playerSpeed * Time.deltaTime);
        }
    }
}
