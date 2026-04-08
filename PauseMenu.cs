using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [Header("UI Panels")]
    public GameObject pauseMenuUI;
    public GameObject optionsMenuUI;

    private bool isPaused = false;

    void Start()
    {
        pauseMenuUI.SetActive(false);
        optionsMenuUI.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (optionsMenuUI.activeSelf)
            {
                CloseOptions();
            }
            else if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        optionsMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        optionsMenuUI.SetActive(false);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void OpenOptions()
    {
        optionsMenuUI.SetActive(true);
        pauseMenuUI.SetActive(false);
    }

    public void CloseOptions()
    {
        optionsMenuUI.SetActive(false);
        pauseMenuUI.SetActive(true);
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
       // Application.Quit();
    }
}
/*
 Create a Canvas in the Hierarchy (+ > UI Canvas > Canvas) and name it something like PauseUI, set render mode to screen space overlay if not by default, set ui scale mode to scale with screen size, set refrence resolution to something 16:9, ie 1920x1080
 Right click the PauseUI then UI canvas > Panel, name it PauseMenuUI, click on the stretch stretch box, hold shift and alt and click the bottom right icon in the submenu, set the color to rgba 0,0,0,150.
 Duplicate this panel and name it OptionsMenuUI, set the color to 50,50,50,150 for distinction
 Right click PauseMenuUI and UI canvas > Button TextMeshPro, rename it ResumeButton and in the dropdown hierarchy set the text value to RESUME. duplicate this button 3 times for the other buttons, Options, Quit, Back, set their text fields. 
 Add an empty gameobject to the PauseMenuUI and title it container, add the vertical layout group Component and duplicate it once. drag only the Resume, Options, and Quit into the container's hierarchy
 Drag the duplicated container into the OptionsMenuUI, drag the Back button into the container, create an empty object in the root hierarchy named PauseManager or smthn, hook this script to it, set the fields to the two created Panels
 On each of the buttons, in the On Click () field, drag PauseManager into the object field, and set the function to the specific PauseMenu function per button, ie. Back & CloseOptions(), Quit & QuitGame(), Options & OpenOptions(), Resume & Resume()
 In the inspector for the 2 panels, click on the checkbox directly under the inspector tab / next to the panel's name to deactivate them by default. run the game and press esc to test functionality, text me if problem
 
 */