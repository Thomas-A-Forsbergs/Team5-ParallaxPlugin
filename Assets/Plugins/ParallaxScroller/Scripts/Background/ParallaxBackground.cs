using UnityEngine;

namespace Plugins.ParallaxScroller.Scripts.Background{
    public class ParallaxBackground : MonoBehaviour{
        //TODO: Refactor code!
        [SerializeField,Range(-1,1)] float depthRelativeToPlayer;
        [SerializeField] bool repeatingBackgroundX;
        [SerializeField] bool repeatingBackgroundY;
        [SerializeField] bool backgroundFollowCamera;
        Transform cameraTransform;
        Vector3 lastCameraPosition;
        Vector3 offset;
        float textureUnitSizeX;
        float textureUnitSizeY;
        float screenWidthUnits;
        
        void Start(){
            cameraTransform = Camera.main.transform;
            lastCameraPosition = cameraTransform.position;
            var spriteRenderer = GetComponent<SpriteRenderer>();
            var sprite = spriteRenderer.sprite;
            var texture2D = sprite.texture;
            textureUnitSizeX = texture2D.width / sprite.pixelsPerUnit;
            textureUnitSizeY = texture2D.height / sprite.pixelsPerUnit;
            offset = cameraTransform.position - transform.position;
            //var numberOfRepeats = 0.05f * Screen.width / textureUnitSizeX;
            screenWidthUnits = 2 * Camera.main.orthographicSize * Screen.width / Screen.height;
            var numberOfRepeats = 6 * screenWidthUnits / textureUnitSizeX;
            spriteRenderer.size *= new Vector2(numberOfRepeats,1);
            
            //
        }
        
        void LateUpdate(){
            if (backgroundFollowCamera){
                transform.position = cameraTransform.position - offset;
                return;
            }
            var deltaMovement = cameraTransform.position - lastCameraPosition;
            transform.position += new Vector3(deltaMovement.x * depthRelativeToPlayer, deltaMovement.y * depthRelativeToPlayer, 0);
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
    }
}
