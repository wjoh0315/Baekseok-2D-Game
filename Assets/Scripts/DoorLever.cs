using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLever : MonoBehaviour
{
    public Transform Door;
    public Transform target;
    Vector3 Origin;
    Vector3 Target;
    bool isOpen = false;
    bool isActive = false;
    Collider2D Temp;

    private void Awake()
    {
        Origin = Door.position;
        Target = target.position;
    }

    private void Update() {
        if (isOpen)
        {
            Door.position = Vector3.MoveTowards(Door.position, Target, Time.deltaTime);
            //Debug.Log(Door.position + " " + Target);
        }
        else
        {
            Door.position = Vector3.MoveTowards(Door.position, Origin, Time.deltaTime);
        }

        if (isActive && ((Temp.tag == "Blue" && Input.GetKeyDown(KeyCode.S)) || (Temp.tag == "Red" && Input.GetKeyDown(KeyCode.DownArrow))))
            isOpen = !isOpen;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        isActive = true;
        Temp = other;
    }

    private void OnTriggerExit2D(Collider2D other) {
        isActive = false;
    }
}
