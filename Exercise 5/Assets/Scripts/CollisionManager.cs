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

        foreach (var coll in collidables)
        {
            coll.IsColliding = false;
        }

        for (int i = 0; i < collidables.Count-1; i++)
        {
            for (int j = i; j < collidables.Count - 1; j++)
            {
                collidables[i].IsColliding = AABBCheck(collidables[i], collidables[j + 1]);

            }

        }

        Debug.Log(collidables[1].isColliding + " " + (collidables[3].RectMax.x - collidables[3].RectMin.x) + " " + collidables[3].isColliding);
        

        //loop through collidables
        //check each sprite for collisions against each other sprite
        //if they are, set iscolliding to true


    }

    bool AABBCheck(SpriteInfo spriteA, SpriteInfo spriteB)
    {
        return spriteB.RectMin.x < spriteA.RectMax.x &&
            spriteB.RectMax.x > spriteA.RectMin.x &&
            spriteB.RectMin.y < spriteA.RectMax.y &&
            spriteB.RectMax.y > spriteA.RectMin.y;

    }
}
