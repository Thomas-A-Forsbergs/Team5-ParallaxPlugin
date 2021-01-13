using UnityEngine;

namespace Plugins.ParallaxScroller.Scripts{
    [ExecuteInEditMode]
    public class BackgroundManager : MonoBehaviour{
        /*
        Sprite
        order in layer
        FollowCamera:
        (sprite renderer draw mode: Simple)
        Add/update button
        
        Follow x and/or y:
        Speed multiplier x and/or y
        Simple:
        tile:
        Repeat width and/or height x times
        */

        [Header("Cool box")]
        [SerializeField] GameObject backgroundPrefab;
        [SerializeField] Sprite sprite;
        [Tooltip("Values larger than 0 is closer to camera")]
        [SerializeField] int orderInLayer;
        [SerializeField] SpriteDrawMode spriteDrawMode;
        [Header("Background settings")]
        [Tooltip("X means: Y means:")]
        [SerializeField] Vector2 backgroundSpeed;
        //TODO: hover tooltip
        
        [SerializeField] bool backgroundFollowCamera;
        [SerializeField] bool repeatingBackgroundX;
        [SerializeField] bool repeatingBackgroundY;
        
        public void InstantiateGameObject(){
            var instance = Instantiate(backgroundPrefab, transform);
            var spriteRenderer = instance.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = sprite;
            spriteRenderer.sortingOrder = orderInLayer;
            spriteRenderer.drawMode = spriteDrawMode;
            //TODO:Setup!
        }
    }
}
