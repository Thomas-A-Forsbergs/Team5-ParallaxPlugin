using System;
using UnityEngine;

namespace Plugins.ParallaxScroller.Scripts.Background {
    public class ParallaxBackground : MonoBehaviour {
        [SerializeField] [Range(-1, 1)] float depthRelativeToPlayer;
        [SerializeField] bool repeatingBackgroundX;
        [SerializeField] bool backgroundFollowCamera;

        Transform cameraTransform;
        Vector3 lastCameraPosition;
        Vector3 offset;
        float screenWidthUnits;
        float textureUnitSizeX;

        public bool RepeatingBackgroundX {
            get => repeatingBackgroundX;
            set => repeatingBackgroundX = value;
        }

        public bool BackgroundFollowCamera {
            get => backgroundFollowCamera;
            set => backgroundFollowCamera = value;
        }

        public float DepthRelativeToPlayer {
            get => depthRelativeToPlayer;
            set => depthRelativeToPlayer = value;
        }

        void Start() {
            if (Camera.main == null) throw new Exception("Scene must include a camera with tag 'MainCamera'");

            cameraTransform = Camera.main.transform;
            var position = cameraTransform.position;
            lastCameraPosition = position;
            var spriteRenderer = GetComponent<SpriteRenderer>();
            var sprite = spriteRenderer.sprite;
            var texture2D = sprite.texture;
            textureUnitSizeX = texture2D.width / sprite.pixelsPerUnit * transform.localScale.x;
            offset = position - transform.position;
            screenWidthUnits = 2 * Camera.main.orthographicSize * Screen.width / Screen.height;

            CalculateSpriteRepeat(spriteRenderer);
        }

        void LateUpdate() {
            if (backgroundFollowCamera) {
                transform.position = cameraTransform.position - offset;
                return;
            }

            var deltaMovement = cameraTransform.position - lastCameraPosition;
            transform.position += new Vector3(deltaMovement.x * depthRelativeToPlayer, 0, 0);

            lastCameraPosition = cameraTransform.position;

            if (repeatingBackgroundX)
                if (Mathf.Abs(cameraTransform.position.x - transform.position.x) >= textureUnitSizeX) {
                    var offsetPositionX = (cameraTransform.position.x - transform.position.x) % textureUnitSizeX;
                    transform.position =
                        new Vector3(cameraTransform.position.x + offsetPositionX, transform.position.y);
                }
        }

        void CalculateSpriteRepeat(SpriteRenderer spriteRenderer) {
            if (BackgroundFollowCamera || DepthRelativeToPlayer >= 1) return;

            var numberOfRepeats = Mathf.RoundToInt(4 * screenWidthUnits / textureUnitSizeX);
            if (numberOfRepeats < 3)
                numberOfRepeats = 3;
            else
                numberOfRepeats = numberOfRepeats % 2 == 0 ? numberOfRepeats + 1 : numberOfRepeats;

            spriteRenderer.size *= new Vector2(numberOfRepeats, 1);
        }
    }
}