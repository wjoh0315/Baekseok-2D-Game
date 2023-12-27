using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teacher : MonoBehaviour
{
    public bool isBlue = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if ((other.tag == "Red" && isBlue) || (other.tag == "Blue" && !isBlue))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
