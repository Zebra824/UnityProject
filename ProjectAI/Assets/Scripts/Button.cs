using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public GameObject confirm_panel;

    void Start()
    {

    }

    void Update()
    {

    }

    public void set_confirm_panel_active()
    {
        confirm_panel.SetActive(true);
    }

    public void set_confirm_panel_inactive()
    {
        confirm_panel.SetActive(false);
    }

    public void load_scene()
    {
        SceneManager.LoadScene(1);
    }

    public void exit_game()
    {
        Application.Quit();
    }
}
