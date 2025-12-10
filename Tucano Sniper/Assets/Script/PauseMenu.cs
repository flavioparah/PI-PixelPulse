using System.Collections.Generic;

using UnityEngine;

using UnityEngine.SceneManagement;



public class PauseMenu : MonoBehaviour

{

    public Transform Pause;

    public Transform pauseMenu;



    public Transform optionsMenu;

    void Update()

    {

        if (Input.GetKeyDown(KeyCode.Escape))

        {

            if (Pause.gameObject.activeSelf)

            {

                Pause.gameObject.SetActive(false);

                Time.timeScale = 1;

            }

            else

            {

                Pause.gameObject.SetActive(true);

                Time.timeScale = 0;

            }

        }

    }



    public void ResumeGame()

    {

        Pause.gameObject.SetActive(false);

        Time.timeScale = 1;

    }

    public void IrMenu()

    {

        SceneManager.LoadScene("Menu");

        Time.timeScale = 1;

    }

    public void Voltar()

    {

        SceneManager.LoadScene("Tucano");

        Time.timeScale = 1;

    }



    public void telaOptions()

    {

        pauseMenu.gameObject.SetActive(false);



        optionsMenu.gameObject.SetActive(true);



    }



    public void closeB()

    {

        pauseMenu.gameObject.SetActive(true);



        optionsMenu.gameObject.SetActive(false);



    }



}