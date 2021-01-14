using Plugins.ParallaxScroller.Scripts.Background;
using UnityEngine;

namespace Plugins.ParallaxScroller.Scripts{
    [ExecuteInEditMode]
    public class BackgroundManager : MonoBehaviour{
        
        [Header("Sprite settings")]
        [SerializeField] Sprite sprite;
        [SerializeField] int orderInLayer;
        [Tooltip("Choose tiled if repeating background")]
        [SerializeField] SpriteDrawMode spriteDrawMode;
        
        [Header("Background settings")]
        [Tooltip("1:fixed to camera, 0: relative player movement, -1: closest to camera")]
        [SerializeField,Range(-1,1)] float depthRelativeToPlayer;
        [SerializeField] bool backgroundFollowCamera;
        [Tooltip("Check if background should scroll and repeat")]
        [SerializeField] bool repeatingBackgroundX = true;
        //[SerializeField] bool repeatingBackgroundY;
        
        public void InstantiateGameObject(){
           
            var instance = new GameObject();
            instance.AddComponent<SpriteRenderer>();
            instance.AddComponent<ParallaxBackground>();
            instance.transform.parent = this.transform;
            
            var spriteRenderer = instance.GetComponent<SpriteRenderer>();
            
            
            spriteRenderer.sprite = sprite;
            spriteRenderer.sortingOrder = orderInLayer;
            spriteRenderer.drawMode = spriteDrawMode;
            instance.GetComponent<ParallaxBackground>().RepeatingBackgroundX = repeatingBackgroundX;
            //instance.GetComponent<ParallaxBackground>().RepeatingBackgroundY = repeatingBackgroundY;
            instance.GetComponent<ParallaxBackground>().BackgroundFollowCamera = backgroundFollowCamera;
            instance.GetComponent<ParallaxBackground>().DepthRelativeToPlayer = depthRelativeToPlayer;

            instance.name = spriteRenderer.sprite.name;
        }
    }
}
