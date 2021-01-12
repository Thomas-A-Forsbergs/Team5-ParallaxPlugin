using UnityEngine;

public class ParallaxBackground : MonoBehaviour{
    [SerializeField] Vector2 parallaxEffectMultiplier;
    [SerializeField] bool infiniteHorizontal;
    [SerializeField] bool infiniteVertical;
    Transform cameraTransform;
    Vector3 lastCameraPosition;
    float textureUnitSizeX;
    float textureUnitSizeY;
    
    void Start(){
        cameraTransform = Camera.main.transform;
        lastCameraPosition = cameraTransform.position;
        var sprite = GetComponent<SpriteRenderer>().sprite;
        var temp = sprite.bounds.size.x;
        
        var texture2D = sprite.texture;
        textureUnitSizeX = texture2D.width / sprite.pixelsPerUnit;
    }
    void LateUpdate(){
        var deltaMovement = cameraTransform.position - lastCameraPosition;
        transform.position += new Vector3(deltaMovement.x * parallaxEffectMultiplier.x, deltaMovement.y * parallaxEffectMultiplier.y,0);
        lastCameraPosition = cameraTransform.position;
        
        if(Mathf.Abs(cameraTransform.position.x - transform.position.x) >= textureUnitSizeX){
            var offsetPositionX = (cameraTransform.position.x - transform.position.x) % textureUnitSizeX;
            transform.position = new Vector3(cameraTransform.position.x + offsetPositionX, transform.position.y,0);
        }
        if(Mathf.Abs(cameraTransform.position.y - transform.position.y) >= textureUnitSizeY){
            var offsetPositionY = (cameraTransform.position.y - transform.position.y) % textureUnitSizeY;
            transform.position = new Vector3(cameraTransform.position.x, transform.position.y + offsetPositionY,0);
        }

    }
    ///Inspector:
    ///Add layer:
    ///Sprite, layer order, static, speed
    ///Update button.
    ///Sprite, layer order, static, speed
    ///Update button.
}
