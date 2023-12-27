using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButton : MonoBehaviour
{
    public Transform Door;
    public Transform target;
    public DoorButton OtherButton;
    Vector3 Origin;
    Vector3 Target;
    public bool isOpen = false;
    //bool isActive = false;
    string tempTag = "";

    private void Awake()
    {
        Origin = Door.position;
        Target = target.position;
    }

    private void Update() {
        if (OtherButton != null)
        {
            if (isOpen || OtherButton.isOpen)
            {
                Door.position = Vector3.MoveTowards(Door.position, Target, Time.deltaTime);
                //Debug.Log(Door.position + " " + Target);
            }
            else
            {
                Door.position = Vector3.MoveTowards(Door.position, Origin, Time.deltaTime);
            }

            return;
        }

        if (isOpen)
        {
            Door.position = Vector3.MoveTowards(Door.position, Target, Time.deltaTime);
            Debug.Log(Door.position + " " + Target);
        }
        else
        {
            Door.position = Vector3.MoveTowards(Door.position, Origin, Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        isOpen = true;
        if (tempTag != "")
            return;
        tempTag = other.tag;
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.tag == tempTag)
        {
            isOpen = false;
            tempTag = "";
        }
    }
}
