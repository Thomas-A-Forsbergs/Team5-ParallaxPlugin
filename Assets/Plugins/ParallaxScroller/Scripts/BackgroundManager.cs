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
        [SerializeField] GameObject backgroundPrefab;
        public void InstantiateGameObject(){
            var instance = Instantiate(backgroundPrefab, transform);
            //TODO:Setup!
        }
    }
}
