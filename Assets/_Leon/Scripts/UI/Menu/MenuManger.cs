using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManger : MonoBehaviour
{
    //public GameObject navCanvas;
    public GameObject bgPanel;
    //public Button closeBtn;

    private Image _helpImg;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        
        //_helpImg.gameObject.SetActive(false);

        //closeBtn.onClick.AddListener(() =>
        //{
        //    _helpImg.gameObject.SetActive(false);
        //});
    }

    public void GoHome()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void Register()
    {

    }

    public void Help()
    {
        //bgPanel.transform.GetChild(0).gameObject.SetActive(false);

        //Image img = bgPanel.GetComponent<Image>();

        //img.sprite = Resources.Load<Sprite>("Texture/MainMenu/help_text");
        //_helpImg = GameObject.Find("HelpImg").GetComponent<Image>();
        //_helpImg.gameObject.SetActive(true);

        _helpImg = GameObject.Find("HelpImg").GetComponent<Image>();
        _helpImg.gameObject.transform.SetAsLastSibling();

    }

    public void GoFunScene()
    {
        SceneManager.LoadScene("FunScene");
    }

    public void GoInspectionScene()
    {
        SceneManager.LoadScene("InspectionScene");
    }

    public void GoAcupointScene()
    {
        SceneManager.LoadScene("AcupointScene");
    }
}
