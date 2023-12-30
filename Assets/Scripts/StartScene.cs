using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour
{
    public Animator animator;
    public GameManager gameManager;
    public string NextScene;
    public bool IsDescription;
    public bool isClearScene = false;
 
    void Start()
    {
        animator.SetBool("FadeOut", true);

        if (IsDescription)
            Invoke("SceneEnd", 3f);
    }

    void Update()
    {
        if (IsDescription)
            return;

        if (isClearScene && Input.GetKeyDown(KeyCode.Escape))
            gameManager.SetTotalTimeZero();

        if((!isClearScene && Input.anyKeyDown) || (isClearScene && Input.GetKeyDown(KeyCode.Escape)))
            SceneEnd();
    }

    void SceneEnd()
    {
        animator.SetBool("FadeIn", true);
        Invoke("GoToScene", 1.25f);
    }

    void GoToScene()
    {
        SceneManager.LoadScene(NextScene);
    }
}
