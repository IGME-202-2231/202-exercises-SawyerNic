using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteInfo : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer m_Sprite;

    [SerializeField]
    float radius = 1.0f;

    bool isColliding = false;

    public Vector2 RectMin
    {
        get { return transform.position - m_Sprite.bounds.extents; }
    }

    public Vector2 RectMax
    {
        get { return transform.position + m_Sprite.bounds.extents; }
    }

    public bool IsColliding { set { isColliding = value; } }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isColliding)
        {
            m_Sprite.color = Color.red;
        }
        else
        {
            m_Sprite.color = Color.white;
        }
    }
}
