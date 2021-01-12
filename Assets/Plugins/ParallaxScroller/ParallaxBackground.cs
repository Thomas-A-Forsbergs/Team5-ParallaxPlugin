using UnityEngine;

public class ParallaxBackground : MonoBehaviour{
    [SerializeField] Vector2 parallaxEffectMultiplier;
    [SerializeField] bool infiniteHorizontal;
    [SerializeField] bool infiniteVertical;
    [SerializeField] bool followCamera;
    Transform cameraTransform;
    Vector3 lastCameraPosition;
    float textureUnitSizeX;
    float textureUnitSizeY;

    Vector3 offset;
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
        if (followCamera){
            transform.position = cameraTransform.position - offset;
            return;
        }
        var deltaMovement = cameraTransform.position - lastCameraPosition;
        transform.position += new Vector3(deltaMovement.x * parallaxEffectMultiplier.x,
            deltaMovement.y * parallaxEffectMultiplier.y, 0);
        lastCameraPosition = cameraTransform.position;
        if (infiniteHorizontal)
            if (Mathf.Abs(cameraTransform.position.x - transform.position.x) >= textureUnitSizeX){
                var offsetPositionX = (cameraTransform.position.x - transform.position.x) % textureUnitSizeX;
                transform.position = new Vector3(cameraTransform.position.x + offsetPositionX, transform.position.y);
            }

        if (infiniteVertical)
            if (Mathf.Abs(cameraTransform.position.y - transform.position.y) >= textureUnitSizeY){
                var offsetPositionY = (cameraTransform.position.y - transform.position.y) % textureUnitSizeY;
                transform.position = new Vector3(cameraTransform.position.x, transform.position.y + offsetPositionY);
            }

    }

    ///Inspector:
    ///Add layer:
    ///Sprite, layer order, static, speed
    ///Update button.
    ///Sprite, layer order, static, speed
    ///Update button.
}
