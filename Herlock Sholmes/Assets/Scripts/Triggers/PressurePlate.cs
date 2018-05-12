using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Collider2D))]
public class PressurePlate : Trigger {

    public bool sticky = false;
    public bool timed = false;
    public float amountOfTime = 1f;

    public Sprite stickySprite;
    public Sprite timedSprite;
    public Sprite defaultSprite;

    SpriteRenderer spriteRenderer;
    Collider2D pressurePlateCollider;

    void Awake()
    {
        if (sticky && timed)
        {
            Debug.LogWarning("Pressure plate cannot be sticky and timed");
        }

        pressurePlateCollider = gameObject.GetComponent<Collider2D>();

        SetSprite();
    }

    void SetSprite()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        if (sticky)
        {
            spriteRenderer.sprite = stickySprite;
        }
        else if (timed)
        {
            spriteRenderer.sprite = timedSprite;
        }
        else
        {
            spriteRenderer.sprite = defaultSprite;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (sticky)
        {
            StickyEnter(col);
        }
        else if (timed)
        {
            TimedEnter(col);
        }
        else
        {
            DefaultEnter(col);
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if ( !sticky && !timed )
        {
            DefaultExit(col);
        }
    }

    void StickyEnter(Collider2D col)
    {
        if ( col.tag != "Hitbox" )
        {
            triggered = !triggered;
        }
    }

    void TimedEnter(Collider2D col)
    {
        pressurePlateCollider.enabled = false;
        triggered = true;

        StopCoroutine( TimedPressurePlate() );
        StartCoroutine( TimedPressurePlate() );
    }

    IEnumerator TimedPressurePlate()
    {
        yield return new WaitForSeconds(amountOfTime);

        triggered = false;
        pressurePlateCollider.enabled = true;
    }

    void DefaultEnter(Collider2D col)
    {
        if ( col.tag != "Hitbox" )
        {
            triggered = true;
        }
    }

    void DefaultExit(Collider2D col)
    {
        if ( col.tag != "Hitbox" )
        {
            triggered = false;
        }
    }
}
