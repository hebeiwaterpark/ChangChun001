using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Leon_OpPanel : MonoBehaviour
{
    private static Leon_OpPanel _instance;
    public static Leon_OpPanel Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new Leon_OpPanel();
            }

            return _instance;
        }
    }

    // 要操作部位
    [HideInInspector]
    public static string opContent = "";

    public Button closeOpPanel;
    public List<Button> opBtns = new List<Button>();

    public Image displayImg;

    Animator animator;
    AudioSource audioSource;

    void Start()
    {
        animator = GetComponent<Leon_PullDownList>().opModel.GetComponent<Animator>();
        audioSource = GetComponent<Leon_PullDownList>().opModel.GetComponent<AudioSource>();

        closeOpPanel.onClick.AddListener(() =>
        {
            if (!displayImg.IsActive()) return;

            displayImg.gameObject.SetActive(false);
        });

        displayImg.gameObject.SetActive(false);
        foreach (Button btn in opBtns)
        {
            
            btn.onClick.AddListener(() =>
            {
                if (btn.transform.GetChild(0).GetComponent<Text>().text == "操作视频")
                {

                }
                else if (btn.transform.GetChild(0).GetComponent<Text>().text == "VR动画解析")
                {
                    //Animator animator = GetComponent<Leon_PullDownList>().opModel.GetComponent<Animator>();
                    animator.SetInteger("Play", 0);

                }
                else
                {
                    displayImg.gameObject.SetActive(true);
                    Sprite sprite = Resources.Load<Sprite>("Texture/" + opContent + "/" + btn.transform.GetChild(0).GetComponent<Text>().text);
                    displayImg.GetComponent<Image>().sprite = sprite;
                }
                    
            });

            
        }
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
            audioSource.Play();
            animator.SetInteger("Play", 1);                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        
        } 
       
    }


    public void Operation(string opContent)
    {

    }
}
