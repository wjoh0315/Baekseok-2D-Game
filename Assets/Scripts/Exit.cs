using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    public GameManager gameManager;
    public bool isBlue = false;

    private void OnTriggerEnter2D(Collider2D other) {
        if ((other.tag == "Red" && !isBlue) || (other.tag == "Blue" && isBlue))
            gameManager.SetDoor(true);
    }

    private void OnTriggerExit2D(Collider2D other) {
        if ((other.tag == "Red" && !isBlue) || (other.tag == "Blue" && isBlue))
            gameManager.SetDoor(false);
    }
}
