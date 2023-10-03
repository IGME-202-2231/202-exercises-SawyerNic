using System;
using UnityEngine;

public class SpriteInfo : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer m_Sprite;

    //[SerializeField]
    //float radius = 1.0f;

    [SerializeField]
    Vector2 rectSize = Vector2.one;

    [SerializeField]
    bool useRendererBounds = true;

    public bool isColliding = false;

    public Vector2 RectMin
    {
        get { return (Vector2)transform.position - (rectSize / 2); }
    }

    public Vector2 RectMax
    {
        get { return (Vector2)transform.position + (rectSize / 2); }
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
        
        if (useRendererBounds)
        {
            //rectSize = m_Sprite.bounds.extends * 2;
        }
    }

    private void OnDrawGizmos()
    {
        //Gizmos.DrawLine(transform.position, rectSize);
    }
}
