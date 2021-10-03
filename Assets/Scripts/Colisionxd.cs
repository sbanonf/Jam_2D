using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colisionxd : MonoBehaviour
{
    public GameObject Siguiente;
    public PlayerMovement player;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (enabled) {
            if (collision.tag == "Player") {
                player.target = Siguiente;     
            }
            
        }
        gameObject.SetActive(false);
    }

}
