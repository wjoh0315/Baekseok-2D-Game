using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teacher : MonoBehaviour
{
    public string teacherColor = "Red"; // Red Blue Green

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if ((other.tag == "Red" && teacherColor == "Blue") || (other.tag == "Blue" && teacherColor == "Red") || (teacherColor == "Green")) 
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
