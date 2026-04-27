using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class ToggleMenu : MonoBehaviour
{
    public GameObject menu, map, inv;
    public bool menuUp, mapUp, invUp = false;


    void Update()
    {
        if (Input.GetKeyDown("escape") && mapUp == false && invUp == false)
            {
                menuUp = !menuUp;
                menu.SetActive(menuUp);
            }
        
        if (Input.GetKeyDown("m") && menuUp == false && invUp == false)
            {
                mapUp = !mapUp;
                map.SetActive(mapUp);
            }
        if (Input.GetKeyDown("e") && menuUp == false && mapUp == false)
            {
                invUp = !invUp;
                inv.SetActive(invUp);
                
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
