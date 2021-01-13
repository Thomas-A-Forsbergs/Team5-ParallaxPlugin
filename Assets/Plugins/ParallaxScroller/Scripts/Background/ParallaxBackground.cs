using UnityEngine;

namespace Plugins.ParallaxScroller.Scripts.Background{
    public class ParallaxBackground : MonoBehaviour{
        //TODO: Refactor code!!!!!!!!!!!
        Vector2 backgroundSpeed => new Vector2(depth,depth) + movementSpeed;
        // depth relative to player, perspective depth relative to player
        [SerializeField,Range(-1,1)] float depth;
        
        //[SerializeField,Range(-1,1)] float depthY;
        [SerializeField] Vector2 movementSpeed; //special feature, a could have
        [SerializeField] bool repeatingBackgroundX;
        [SerializeField] bool repeatingBackgroundY;
        [SerializeField] bool backgroundFollowCamera;
        Transform cameraTransform;
        Vector3 lastCameraPosition;
        Vector3 offset;
        float textureUnitSizeX;
        float textureUnitSizeY;
        
        void Start(){
            cameraTransform = Camera.main.transform;
            lastCameraPosition = cameraTransform.position;
            var sprite = GetComponent<SpriteRenderer>().sprite;
            var texture2D = sprite.texture;
            textureUnitSizeX = texture2D.width / sprite.pixelsPerUnit;
            textureUnitSizeY = texture2D.height / sprite.pixelsPerUnit;
            offset = cameraTransform.position - transform.position;
        }
        
        void LateUpdate(){
            if (backgroundFollowCamera){
                transform.position = cameraTransform.position - offset;
                return;
            }
            var deltaMovement = cameraTransform.position - lastCameraPosition;
            transform.position += new Vector3(deltaMovement.x * backgroundSpeed.x,
                deltaMovement.y * backgroundSpeed.y, 0);
            lastCameraPosition = cameraTransform.position;
            if (repeatingBackgroundX)
                if (Mathf.Abs(cameraTransform.position.x - transform.position.x) >= textureUnitSizeX){
                    var offsetPositionX = (cameraTransform.position.x - transform.position.x) % textureUnitSizeX;
                    transform.position = new Vector3(cameraTransform.position.x + offsetPositionX, transform.position.y);
                }

            if (repeatingBackgroundY)
                if (Mathf.Abs(cameraTransform.position.y - transform.position.y) >= textureUnitSizeY){
                    var offsetPositionY = (cameraTransform.position.y - transform.position.y) % textureUnitSizeY;
                    transform.position = new Vector3(cameraTransform.position.x, transform.position.y + offsetPositionY);
                }

        }

        ///Inspector:
        ///Add layer:
        ///Sprite, layer order, static, speed
        ///Update button.
    }
}
