using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DisplayAcupoint : MonoBehaviour
{
    public RectTransform acupointPanel;
    public Image acupointImg;
    public Button backBtn;
    public List<Button> btnList = new List<Button>();
    public List<Transform> zuzhiList = new List<Transform>();

    public GameObject acupoint;

    void Start()
    {
        acupointPanel.gameObject.SetActive(false);

        //backBtn.onClick.AddListener(() =>
        //{
        //    SceneManager.LoadScene("MainMenu");
        //});

        foreach (Button btn in btnList)
        {
            btn.onClick.AddListener(delegate
            {
                ShowOrHidden(btn);
            });
        }
    }

    void Update()
    {
        OpAcupoint();

        foreach (Transform item in zuzhiList)
        {
            foreach (Button btn in btnList)
            {
                if (item.name == btn.name)
                {
                    if (item.gameObject.activeSelf)
                    {
                        btn.GetComponent<Image>().color = Color.green;
                    }
                    else
                    {
                        btn.GetComponent<Image>().color = Color.white;
                    }
                }
            }
        }

    }

    /// <summary>
    /// 操作穴位
    /// </summary>
    private void OpAcupoint()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit,Mathf.Infinity))
            {
                if (hit.transform.tag == "Acupoint")
                {
                    acupointImg.sprite = Resources.Load<Sprite>("Acupoint/" + hit.transform.gameObject.name);
                    acupointPanel.gameObject.SetActive(true);
                    foreach (Transform item in acupoint.transform)
                    {
                        if (item.name == hit.transform.gameObject.name)
                        {
                            item.GetComponent<MeshRenderer>().material.color = Color.green;
                        }
                        else
                        {
                            item.GetComponent<MeshRenderer>().material.color = Color.yellow;
                        }
                    }
                }
            }
        }
    }


    public void ShowOrHidden(Button btn)
    {
        //_rentiList.Clear();

        //foreach (Transform item in model.transform)
        //{
        //    _rentiList.Add(item.GetChild(1));
        //}

        for (int i = 0; i < zuzhiList.Count; i++)
        {
            foreach (Transform trans in zuzhiList)
            {
                if (trans.name == btn.name)
                {
                    //trans.gameObject.SetActive(btn.gameObject.activeSelf);
                    Debug.Log(trans);
                    trans.gameObject.SetActive(!trans.gameObject.activeSelf);

                }
            }
        }
    }

}
