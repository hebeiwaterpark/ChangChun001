using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpManager : MonoBehaviour
{
    // 要操作部位
    [HideInInspector]
    public static string opContent = "";

    public GameObject model;
    public Image gunImg;

    public Image displayImg;

    public Button gunBtn;
    public Button jingBtn;
    public Button closeOpPanel;


    Animator animator;

    void Start()
    {
        gunImg.gameObject.SetActive(false);

        animator = model.GetComponent<Animator>();
        animator.SetInteger("Play", 1);

        gunBtn.onClick.AddListener(() =>
        {
            opContent = "滚法";

        });

        jingBtn.onClick.AddListener(() =>
        {
            opContent = "颈部扳法";
        });

        closeOpPanel.onClick.AddListener(() =>
        {
            if (!displayImg.IsActive()) return;

            displayImg.gameObject.SetActive(false);
        });

        displayImg.gameObject.SetActive(false);

    }

    void Update()
    {
        AnimatorStateInfo animatorInfo;

        //要在update获取
        animatorInfo = animator.GetCurrentAnimatorStateInfo(0);

        //normalizedTime：0-1在播放、0开始、1结束 New State 0为状态机动画的名字
        if ((animatorInfo.normalizedTime >= 1.0f) && (animatorInfo.IsName("New State 0")))
        {
            //完成后的逻辑 	
            //Debug.Log("播放完成.");
            //audioSource.Play();
            animator.SetInteger("Play", 1);
        }

        if (opContent == "滚法")
        {
            gunBtn.GetComponent<Image>().color = new Color(0, 182, 243, 255);
            gunBtn.transform.GetChild(0).GetComponent<Text>().color = Color.white;

            jingBtn.GetComponent<Image>().color = Color.white;
            jingBtn.transform.GetChild(0).GetComponent<Text>().color = Color.black;
        }
        else if (opContent == "颈部扳法")
        {
            jingBtn.GetComponent<Image>().color = new Color(0, 182, 243, 255);
            jingBtn.transform.GetChild(0).GetComponent<Text>().color = Color.white;

            gunBtn.GetComponent<Image>().color = Color.white;
            gunBtn.transform.GetChild(0).GetComponent<Text>().color = Color.black;
        }
    }

    public void DisplayContent(string content)
    {
        if (opContent == "") return;
        displayImg.gameObject.SetActive(true);
        Sprite sprite = Resources.Load<Sprite>("Texture/" + opContent + "/" + content);
        displayImg.GetComponent<Image>().sprite = sprite;
    }

    public void PlayVRAniamtion()
    {
        if (opContent == "滚法")
        {
            model.SetActive(false);
            gunImg.gameObject.SetActive(true);

        }else if (opContent == "颈部扳法")
        {
            model.SetActive(true);
            animator.SetInteger("Play", 0);
        }
        
    }

}
