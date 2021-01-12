using System;
using UnityEngine;

namespace Background{
    
    [Serializable]
    public class BackgroundSprite{
        [SerializeField]public Sprite backgroundSprite;
        [SerializeField]public bool flipSprite;
        [SerializeField]public float cameraRelativeSpeed;
    }
    public class MoveBackground : MonoBehaviour{
        [SerializeField] private BackgroundSprite[] backgroundSprites;
        
        // Start is called before the first frame update
        void Start()
        {
            foreach (var background in backgroundSprites){
                //check if sprite need to be flipped
            
        
                //check if background sprite needs to be cloned to fill entire screen with margin
                int numberClones = Screen.width / background.backgroundSprite;
                
            }

            
            
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
