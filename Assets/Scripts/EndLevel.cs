using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevel : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        //If the game object that entered the trigger is our player, then load the next level.
        if (other.gameObject.name == "Player")
        {
            GameManager.instance.LoadNextScene();
        }
    }
}
