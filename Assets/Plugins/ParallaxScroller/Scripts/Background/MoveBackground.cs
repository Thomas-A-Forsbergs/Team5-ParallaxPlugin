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
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
