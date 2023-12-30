using UnityEngine;

public class Fixed : MonoBehaviour
{
    private void Start()
    {
        Screen.SetResolution(Screen.width, (Screen.width * 16) / 9, true);
    }
}