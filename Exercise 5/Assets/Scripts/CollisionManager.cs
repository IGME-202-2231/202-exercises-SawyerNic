using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    [SerializeField]
    List<SpriteInfo> collidables = new List<SpriteInfo>();

    // Start is called before the first frame update
    void Start()
    {
        // collidables = new List<SpriteInfo>(GetComponents<SpriteInfo>());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    bool AABBCheck(SpriteInfo spriteA, SpriteInfo spriteB)
    {
        if (spriteB.RectMin.x < spriteA.RectMax.x && 
            spriteB.RectMax.x > spriteA.RectMin.x && 
            spriteB.RectMax.y < spriteA.RectMin.y && 
            spriteB.RectMax.y > spriteA.RectMin.y)
        {
            return true;
        }
        return false;

    }
}
