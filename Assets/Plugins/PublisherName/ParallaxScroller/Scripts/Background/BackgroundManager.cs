using System;
using UnityEngine;

namespace Plugins.ParallaxScroller.Scripts.Background {
    [ExecuteInEditMode]
    public class BackgroundManager : MonoBehaviour {
        [Header("Sprite settings")]
        [SerializeField] Sprite sprite;

        [SerializeField] int orderInLayer;

        [Header("Background parallax settings")]
        [Tooltip("  1: fixed to camera\n 0: relative player movement\n-1: closest to camera")]
        [SerializeField] [Range(-1, 1)] float depthRelativeToPlayer;

        [SerializeField] bool backgroundFollowsCamera;

        [Tooltip("Check if background should scroll and repeat")]
        [SerializeField] bool repeatingBackgroundX = true;

        public void InstantiateGameObject() {
            if (sprite == null)
                throw new Exception("Must add sprite before pressing 'Add Layer'");

            var instance = new GameObject();
            instance.AddComponent<SpriteRenderer>();
            instance.AddComponent<ParallaxBackground>();
            instance.transform.parent = transform;

            var spriteRenderer = instance.GetComponent<SpriteRenderer>();
            var parallaxBackground = instance.GetComponent<ParallaxBackground>();

            spriteRenderer.sprite = sprite;
            spriteRenderer.sortingOrder = orderInLayer;
            spriteRenderer.drawMode = SpriteDrawMode.Tiled;

            parallaxBackground.RepeatingBackgroundX = repeatingBackgroundX;
            parallaxBackground.BackgroundFollowCamera = backgroundFollowsCamera;
            parallaxBackground.DepthRelativeToPlayer = depthRelativeToPlayer;

            instance.name = spriteRenderer.sprite.name;
        }
    }
}