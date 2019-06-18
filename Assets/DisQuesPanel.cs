using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DisQuesPanel : MonoBehaviour
{
    EventSystem eventSystem;
    GraphicRaycaster graphicRaycaster;

    public RectTransform quesPanelPre;

    private Button _backBtn;

    void Start()
    {
        graphicRaycaster = GameObject.Find("Canvas").GetComponent<GraphicRaycaster>();

        //_backBtn = GameObject.Find("Canvas/BackBtn").GetComponent<Button>();
        //_backBtn.onClick.AddListener(() =>
        //{
        //    SceneManager.LoadScene("MainMenu");
        //});
    }

    void Update()
    {
        if (CheckGUIRaycastObject()) return;
        DisplayQuesPanel();
    }

    private void DisplayQuesPanel()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "Ques")
                {
                    switch (hit.transform.gameObject.name)
                    {
                        case "Head":
                            CreateQuestionPanel.partBody = PartBody.Head;
                            break;
                        case "Chest":
                            CreateQuestionPanel.partBody = PartBody.Chest;
                            break;
                        case "Loin":
                            CreateQuestionPanel.partBody = PartBody.Loin;
                            break;
                        case "Legs":
                            CreateQuestionPanel.partBody = PartBody.Legs;
                            break;
                    }

                    RectTransform rectTransform = Resources.Load<RectTransform>("UI/QustionPanel");
                    RectTransform rectTrans = Instantiate(rectTransform);
                    rectTrans.SetParent(GameObject.Find("Canvas").transform);
                    rectTrans.localScale = Vector3.one;
                    rectTrans.localRotation = Quaternion.identity;
                    rectTrans.localPosition = Vector3.zero;
                    rectTrans.gameObject.name = "QuestionPanel";
                    rectTrans.gameObject.AddComponent<CreateQuestionPanel>();
                }
            }
        }
    }

    bool CheckGUIRaycastObject()
    {
        PointerEventData eventData = new PointerEventData(eventSystem);
        eventData.pressPosition = Input.mousePosition;
        eventData.position = Input.mousePosition;

        List<RaycastResult> list = new List<RaycastResult>();

        graphicRaycaster.Raycast(eventData, list);
        return list.Count > 0;

    }
}
