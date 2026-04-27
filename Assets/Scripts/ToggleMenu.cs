using Microsoft.Unity.VisualStudio.Editor;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class ToggleMenu : MonoBehaviour
{
    public GameObject menu, map, inv;
    public bool menuUp, mapUp = false;
    public UIInventoryPage page;


    void Update()
    {
        if (Input.GetKeyDown("escape") && mapUp == false && page.invUp == false)
            {
                menuUp = !menuUp;
                menu.SetActive(menuUp);
            }
        
        if (Input.GetKeyDown("m") && menuUp == false && page.invUp == false)
            {
                mapUp = !mapUp;
                map.SetActive(mapUp);
            }
        PauseGame();
    }

    void PauseGame()
    {
        if(menuUp == true || mapUp == true || page.invUp == true)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }
}
