using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class ToggleMenu : MonoBehaviour
{
    public GameObject menu, map;
    public bool menuUp, mapUp = false;


    void Update()
    {
        if (Input.GetKeyDown("escape") && mapUp == false)
            {
                menuUp = !menuUp;
                menu.SetActive(menuUp);
            }
        
        if (Input.GetKeyDown("m") && menuUp == false)
            {
                mapUp = !mapUp;
                map.SetActive(mapUp);
            }
            
            PauseGame();
    }

    void PauseGame()
    {
        if(menuUp == true || mapUp == true)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }
}
