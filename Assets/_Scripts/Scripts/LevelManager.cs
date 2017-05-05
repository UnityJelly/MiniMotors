using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public Transform UIPermanent;
    public Camera mainCamera;
    public Menu menu;
    public Text carSpeed;

     public Car[] cars;

    void Awake()
    {
        GameManager.Instance.LevelManager = this;
        GameManager.Instance.isInGame = true;
    }

    void Start()
    {
        // Let's find all the cars in the scene
        cars = GameObject.FindObjectsOfType<Car>();

        CameraFollow followScript = mainCamera.GetComponent<CameraFollow>();
        followScript.enabled = true;

        //PauseGame();
        UnpauseGame();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (menu.IsMenuActive("MenuInGame"))
                UnpauseGame();
            else
                PauseGame();
        }
    }

    public void UnpauseGame()
    {
        UIPermanent.gameObject.SetActive(true);
        menu.HideMenu();
        menu.ClearHistory();
        GameManager.Instance.UnpauseGame();

        // Let's make all the cars in the menu uncontrollable by the keyboard
        foreach (Car car in cars)
        {
            car.StartSounds();
        }
    }

    public void PauseGame()
    {
        UIPermanent.gameObject.SetActive(false);
        menu.ShowMenuPage("MenuInGame");
        GameManager.Instance.PauseGame();
    }

    public void GoToScene(string scene)
    {
        Application.LoadLevel(scene);
    }
}