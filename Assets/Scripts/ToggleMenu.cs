using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class ToggleMenu : MonoBehaviour
{
    public GameObject menu, map, inventory;
    public bool menuUp, mapUp, invUp = false;


    void Update()
    {
        if (Input.GetKeyDown("escape") && invUp == false && mapUp == false)
            {
                menuUp = !menuUp;
                menu.SetActive(menuUp);
            }
        if (Input.GetKeyDown("q") && menuUp == false && mapUp == false)
            {
                invUp = !invUp;
                inventory.SetActive(invUp);
            }
        
        if (Input.GetKeyDown("m") && menuUp == false && invUp == false)
            {
                mapUp = !mapUp;
                map.SetActive(mapUp);
            }
            
            PauseGame();
    }

    void PauseGame()
    {
        if(menuUp == true || mapUp == true || invUp == true)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }
}
