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
        for(int i = 0; i < collidables.Count; i++)
        {
            collidables[i].isColliding = false;
        }
        
        for (int i = 0; i < collidables.Count-1; i++)
        {

            for (int j = i + 1; j < collidables.Count; j++)
            {
                if(AABBCheck(collidables[i], collidables[j]))
                {
                    collidables[i].isColliding = true;
                    collidables[j].isColliding = true;
                }
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

