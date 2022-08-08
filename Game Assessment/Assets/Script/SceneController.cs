using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class SceneController : MonoBehaviour
{
    [Header("UI")]
    [SerializeField]
    private Button menuButton;

    [SerializeField]
    private Button closeButton;

    [SerializeField]
    private Image menu;

    [SerializeField]
    private Button RocketOneButton;

    [SerializeField]
    private Button RocketTwoButton;

    [SerializeField]
    private Button RocketThreeButton;

    [SerializeField]
    private Button closeButtonOne;

    [SerializeField]
    private Button closeButtonTwo;

    [SerializeField]
    private Button closeButtonThree;

    [SerializeField]
    private Image RocketOneMenu;

    [SerializeField]
    private Image RocketTwoMenu;

    [SerializeField]
    private Image RocketThreeMenu;

    [SerializeField]
    private Button launchButton;

    [SerializeField]
    private Image launchMenu;

    [SerializeField]
    private Button launchButtonOne;

    [SerializeField]
    private Button launchButtonTwo;

    [SerializeField]
    private Button launchButtonThree;

    [SerializeField]
    private Slider rocketSpeedOne;

    [SerializeField]
    private Slider rocketSpeedTwo;

    [SerializeField]
    private Slider rocketSpeedThree;

    private CanvasGroup currentCanvasGroup;

    [Header("Rockets")]
    [SerializeField]
    private GameObject rocketOne;

    [SerializeField]
    private GameObject rocketTwo;

    [SerializeField]
    private GameObject rocketThree;

    [SerializeField]
    private GameObject flameOne;

    [SerializeField]
    private GameObject flameTwo;

    [SerializeField]
    private GameObject flameThree;

    [SerializeField]
    private TMP_Dropdown colorDropDownOne;

    [SerializeField]
    private TMP_Dropdown colorDropDownTwo;

    [SerializeField]
    private TMP_Dropdown colorDropDownThree;

    [SerializeField]
    private Material[] rocketMaterials;

    [SerializeField]
    private float speedParameter;

    [Header("Models")]
    [SerializeField]
    private GameObject modelOne;

    [SerializeField]
    private GameObject modelTwo;

    [SerializeField]
    private GameObject modelThree;

   

    private void Start()
    {
        menuButton.onClick.AddListener(OpenMainMenu);
        closeButton.onClick.AddListener(CloseMainMenu);
        menu.gameObject.SetActive(false);
        launchMenu.gameObject.SetActive(false);

        RocketOneButton.onClick.AddListener(OpenMenuRocketOne);
        RocketTwoButton.onClick.AddListener(OpenMenuRocketTwo);
        RocketThreeButton.onClick.AddListener(OpenMenuRocketThree);

        RocketOneMenu.gameObject.SetActive(false);
        RocketTwoMenu.gameObject.SetActive(false);
        RocketThreeMenu.gameObject.SetActive(false);

        closeButtonOne.onClick.AddListener(CloseMenuRocketOne);
        closeButtonTwo.onClick.AddListener(CloseMenuRocketTwo);
        closeButtonThree.onClick.AddListener(CloseMenuRocketThree);

        launchButton.onClick.AddListener(OpenLaunchMenu);
        launchButtonOne.onClick.AddListener(LaunchRocketOne);
        launchButtonTwo.onClick.AddListener(LaunchRocketTwo);
        launchButtonThree.onClick.AddListener(LaunchRocketThree);

        colorDropDownOne.value = 1;
        colorDropDownTwo.value = 0;
        colorDropDownThree.value = 6;

        rocketSpeedOne.value = rocketSpeedTwo.value = rocketSpeedThree.value = 0.4f;

        flameOne.gameObject.SetActive(false);
        flameTwo.gameObject.SetActive(false);
        flameThree.gameObject.SetActive(false);

    }

    private void OpenMainMenu()
    {
        launchButton.gameObject.SetActive(false);
        menuButton.gameObject.SetActive(false);
        menu.gameObject.SetActive(true);

        StartCoroutine(FadeIn(menu.gameObject.GetComponent<CanvasGroup>()));
        
    }

    private void CloseMainMenu()
    {
        menuButton.gameObject.SetActive(true);
        launchButton.gameObject.SetActive(true);

        StartCoroutine(FadeOut(menu.gameObject));
    }

    private void OpenMenuRocketOne()
    {
        RocketOneMenu.gameObject.SetActive(true);
    }

    private void OpenMenuRocketTwo()
    {
        RocketTwoMenu.gameObject.SetActive(true);
    }

    private void OpenMenuRocketThree()
    {
        RocketThreeMenu.gameObject.SetActive(true);
    }

    private void CloseMenuRocketOne()
    {
        rocketOne.GetComponent<MeshRenderer>().material = rocketMaterials[colorDropDownOne.value];
        RocketOneMenu.gameObject.SetActive(false);
    }

    private void CloseMenuRocketTwo()
    {
        rocketTwo.GetComponent<MeshRenderer>().material = rocketMaterials[colorDropDownTwo.value];
        RocketTwoMenu.gameObject.SetActive(false);
    }

    private void CloseMenuRocketThree()
    {
        rocketThree.GetComponent<MeshRenderer>().material = rocketMaterials[colorDropDownThree.value];
        RocketThreeMenu.gameObject.SetActive(false);
    }

    private void OpenLaunchMenu()
    {
        menuButton.gameObject.SetActive(false);
        launchMenu.gameObject.SetActive(true);

        StartCoroutine(FadeIn(launchMenu.gameObject.GetComponent<CanvasGroup>()));
    }

    private void LaunchRocketOne()
    {
        DisableLaunchMenu();
        flameOne.gameObject.SetActive(true);
        rocketOne.GetComponent<Rigidbody>().velocity = modelOne.transform.position * rocketSpeedOne.value * speedParameter;
    }

    private void LaunchRocketTwo()
    {
        DisableLaunchMenu();
        flameTwo.gameObject.SetActive(true);
        rocketTwo.GetComponent<Rigidbody>().velocity = modelTwo.transform.position * rocketSpeedTwo.value * speedParameter;
    }

    private void LaunchRocketThree()
    {
        DisableLaunchMenu();
        flameThree.gameObject.SetActive(true);
        rocketThree.GetComponent<Rigidbody>().velocity = modelThree.transform.position * rocketSpeedThree.value * speedParameter;
    }

    private void DisableLaunchMenu()
    { 
        menuButton.gameObject.SetActive(true);
        StartCoroutine(FadeOut(launchMenu.gameObject));
    }

    IEnumerator FadeIn(CanvasGroup canvasGroup)
    {
        canvasGroup.alpha = 0;
        while(canvasGroup.alpha < 1)
        {
            canvasGroup.alpha += 0.05f;
            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator FadeOut(GameObject panel)
    {
        CanvasGroup canvasGroup = panel.GetComponent<CanvasGroup>();
        while (canvasGroup.alpha > 0)
        {
            canvasGroup.alpha -= 0.05f;
            yield return new WaitForEndOfFrame();
        }
        panel.SetActive(false);
    }
}
