using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int NowLevel = 1;
    public int ChocoToClear = 1;
    public bool isKeyCard = false;

    int NowChoco = 0;
    int DoorOpened = 0;
    bool isGetKeycard = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Restart();
    }

    public void ChocoAdded()
    {
        NowChoco += 1;
    }

    public void SetDoor(bool isOpen)
    {
        if (isOpen)
            DoorOpened += 1;
        else
            DoorOpened -= 1;

        if (DoorOpened >= 2 && NowChoco >= ChocoToClear)
        {
            if (isKeyCard && !isGetKeycard)
                return;
            GameClear();
        }
    }

    void GameClear()
    {
        if (NowLevel <= 2)
            SceneManager.LoadScene("Stage " + (NowLevel + 1));
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GetKeyCard()
    {
        isGetKeycard = true;
    }
}
