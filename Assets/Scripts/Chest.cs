using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public Sprite openSprite;
    bool opened = false;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!opened && GameController.instance.OpenChest(this))
        {
            GetComponent<SpriteRenderer>().sprite = openSprite;
            opened = true;

            GameController.instance.EndGame();
        }
    }
}
