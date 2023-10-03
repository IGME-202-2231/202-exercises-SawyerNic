using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    [SerializeField]
    List<SpriteInfo> collidables;

    

    // Start is called before the first frame update
    void Start()
    {
        collidables = new List<SpriteInfo>(GameObject.FindObjectsOfType<SpriteInfo>());
        

    }

    // Update is called once per frame
    void Update()
    {
        // Set all spriteinfo.iscolliding to false




        for (int i = 0; i < collidables.Count; i++)
        {
            for (int j = i + 1; j < collidables.Count; j++)
            {
                // Compare myList[i] with myList[j]
                // Perform your desired comparison operation here
                // For example:
                collidables[i].isColliding = AABBCheck(collidables[i], collidables[j]);
                
                    
                
            }
        }


    }

    bool AABBCheck(SpriteInfo spriteA, SpriteInfo spriteB)
    {
        return spriteB.RectMin.x < spriteA.RectMax.x &&
            spriteB.RectMax.x > spriteA.RectMin.x &&
            spriteB.RectMin.y < spriteA.RectMax.y &&
            spriteB.RectMax.y > spriteA.RectMin.y;

    }
}

