using System;
using UnityEngine;

namespace Background{
    
    [Serializable]
    public class BackgroundSprite{
        [SerializeField]private Sprite backgroundSprite;
        [SerializeField]private bool flipSprite;
        [SerializeField]private float cameraRelativeSpeed;
    }
    public class MoveBackground : MonoBehaviour{
        [SerializeField] private BackgroundSprite[] backgroundSprites;
        
        // Start is called before the first frame update
        void Start()
        {
            foreach (var background in backgroundSprites){
                
            }
            //check if sprites need to be flipped
            
        
            //check if background sprite needs to be cloned to fill entire screen with margin
            
            
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
