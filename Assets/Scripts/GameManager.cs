using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int NowLevel = 1;
    public int lmitTime = 60;
    public int ChocoToClear_R = 1;
    public int ChocoToClear_B = 1;
    public bool isKeyCard = false;
    public TMP_Text time;
    public TMP_Text RedChoco;
    public TMP_Text BlueChoco;
    public TMP_Text Keycard;
    public Animator FadeAnimator;
    public GameObject ClearUI;

    int NowChoco_R = 0;
    int NowChoco_B = 0;
    int DoorOpened = 0;
    bool isGetKeycard = false;
    bool IsGameStart = false;

    float NowTime = 0;
    int RoundTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        BlueChoco.text = ChocoToClear_B.ToString();
        RedChoco.text = ChocoToClear_R.ToString();

        NowTime = lmitTime;
        FadeAnimator.SetBool("FadeOut", true);
        Invoke("GameStart", 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsGameStart)
            return;

        if (Input.GetKeyDown(KeyCode.Escape))
            Restart();
        
        if (NowTime <= 0)
            Restart();

        NowTime -= Time.deltaTime;
        RoundTime = Mathf.RoundToInt(NowTime);
        time.text = (RoundTime / 60).ToString() + ":" + (RoundTime % 60 < 10? "0" : "") + (RoundTime % 60).ToString();
    }

    void GameStart()
    {
        IsGameStart = true;
    }

    public void ChocoAdded(bool isBlue)
    {
        if (isBlue)
        {
            NowChoco_B++;
            BlueChoco.text = (ChocoToClear_B - NowChoco_B).ToString();
        }
        else
        {
            NowChoco_R++;
            RedChoco.text = (ChocoToClear_R - NowChoco_R).ToString();
        }
    }

    public void SetDoor(bool isOpen)
    {
        if (isOpen)
            DoorOpened += 1;
        else
            DoorOpened -= 1;

        if (DoorOpened >= 2 && NowChoco_R >= ChocoToClear_R && NowChoco_B >= ChocoToClear_B)
        {
            if (isKeyCard && !isGetKeycard)
                return;
            GameClear();
        }
    }

    void GameClear()
    {
        if (NowLevel <= 2)
            GoToStage(NowLevel + 1);
        else
            ClearUI.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoToStage(int level)
    {
        SceneManager.LoadScene("Stage " + level);
    }

    public void GoToStartScene()
    {
        SceneManager.LoadScene("Start");
    }

    public void FadeInvokeIn(string func)
    {
        FadeAnimator.SetBool("FadeIn", true);
        Invoke(func, 1.25f);
    }

    public void GetKeyCard()
    {
        isGetKeycard = true;
        Keycard.text = "0";
    }
}
