using UnityEngine;

public class ToggleMenu : MonoBehaviour
{
    public GameObject menu;
    public bool menuUp = false;


    void Update()
    {
        if (Input.GetKeyDown("q")) menuUp = !menuUp;

        menu.SetActive(menuUp);
        PauseGame();
    }

    void PauseGame()
    {
        if(menuUp == true)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }
}
