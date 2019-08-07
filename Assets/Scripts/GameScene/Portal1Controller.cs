using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal1Controller : MonoBehaviour
{
    [SerializeField]
    private GameController gameController;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            gameController.setParte1(true);
            gameController.setAtivarParte1(false);
        }
    }
}
