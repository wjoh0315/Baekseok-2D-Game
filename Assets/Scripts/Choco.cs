using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choco : MonoBehaviour
{
    public GameManager gameManager;
    public bool isBlue = false;

    private void OnTriggerEnter2D(Collider2D other) {
        if ((other.tag == "Red" && !isBlue) || (other.tag == "Blue" && isBlue))
        {
            gameManager.ChocoAdded(other.tag == "Blue");
            Destroy(gameObject);
        }
    }
}
