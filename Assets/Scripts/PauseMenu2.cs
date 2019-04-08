using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu2 : MonoBehaviour
{
    private bool activated = false;
    public GameObject PauseUI;
    public Button continueBtn;
    public Button backBtn;

    // Start is called before the first frame update
    void Start()
    {
        activated = false;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(activated);
        if (Input.GetKeyDown(KeyCode.Escape) && activated == false)
        {
            activated = true;
            PauseUI.SetActive(true);
            Time.timeScale = 0f;

        }
        else if(Input.GetKeyDown(KeyCode.Escape) && activated == true)
        {
            activated = false;
            PauseUI.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    public void Continue()
    {
        activated = false;
        PauseUI.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        activated = false;
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }
}
