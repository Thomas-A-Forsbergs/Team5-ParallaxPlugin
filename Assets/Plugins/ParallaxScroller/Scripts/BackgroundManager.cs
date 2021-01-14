using Plugins.ParallaxScroller.Scripts.Background;
using UnityEngine;

namespace Plugins.ParallaxScroller.Scripts{
    [ExecuteInEditMode]
    public class BackgroundManager : MonoBehaviour{
        /*
        TODO:
        Add/update button
        
        repeatingBackground x and/or y:
        Simple:
        tile:
        */

        [Header("Cool box")]
        [SerializeField] GameObject backgroundPrefab;
        [SerializeField] Sprite sprite;
        [Tooltip("Values larger than 0 is closer to camera")]
        [SerializeField] int orderInLayer;
        [SerializeField] SpriteDrawMode spriteDrawMode;
        
        [Header("Background settings")]
        [Tooltip("")]
        [SerializeField,Range(-1,1)] float depthRelativeToPlayer;
        [SerializeField] bool backgroundFollowCamera;
        [SerializeField] bool repeatingBackgroundX = true;
        [SerializeField] bool repeatingBackgroundY;
        
        public void InstantiateGameObject(){
            var instance = Instantiate(backgroundPrefab, transform);
            var spriteRenderer = instance.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = sprite;
            spriteRenderer.sortingOrder = orderInLayer;
            spriteRenderer.drawMode = spriteDrawMode;
            instance.GetComponent<ParallaxBackground>().RepeatingBackgroundX = repeatingBackgroundX;
            instance.GetComponent<ParallaxBackground>().RepeatingBackgroundY = repeatingBackgroundY;
            instance.GetComponent<ParallaxBackground>().BackgroundFollowCamera = backgroundFollowCamera;
            instance.GetComponent<ParallaxBackground>().DepthRelativeToPlayer = depthRelativeToPlayer;
        }
    }
}
