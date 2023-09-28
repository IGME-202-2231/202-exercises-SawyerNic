using System;
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
        collidables = new List<SpriteInfo>(GetComponents<SpriteInfo>());
    }

    // Update is called once per frame
    void Update()
    {
        // Set all spriteinfo.iscolliding to false

        foreach (var coll in collidables)
        {
            coll.IsColliding = false;
        }

        for (int i = 0; i < collidables.Count; i++)
        {
            for (int j = 0; j < collidables.Count; j++)
            {
                collidables[i].IsColliding = AABBCheck(collidables[i], collidables[j + i + 1]);
                
            }
            
        }


        //loop through collidables
        //check each sprite for collisions against each other sprite
            //if they are, set iscolliding to true

        
    }

    bool AABBCheck(SpriteInfo spriteA, SpriteInfo spriteB)
    {
        return spriteB.RectMin.x < spriteA.RectMax.x &&
            spriteB.RectMax.x > spriteA.RectMin.x &&
            spriteB.RectMax.y < spriteA.RectMin.y &&
            spriteB.RectMax.y > spriteA.RectMin.y;

    }
}
