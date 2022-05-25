using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItem : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetSprite(SpriteRenderer updatedSprite) 
    {
        spriteRenderer.sprite = updatedSprite.sprite;
    }

    public void RemoveSprite()
    {
        spriteRenderer.sprite = null;
    }
}
