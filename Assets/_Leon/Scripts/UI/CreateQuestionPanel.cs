using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum PartBody
{
    Head=0,
    Chest=1,
    Loin=2,
    Legs=3,
}

public class CreateQuestionPanel:MonoBehaviour
{

    //private static CreateQuestionPanel _instance;
    //public static CreateQuestionPanel Instance
    //{
    //    get
    //    {
    //        if (_instance == null)
    //        {
    //            _instance = new CreateQuestionPanel();
    //        }

    //        return _instance;
    //    }
    //}

    public static PartBody partBody;
    private Button _closeBtn;

    public List<Toggle> selectToggles = new List<Toggle>(); // 选择键
    public List<Text> selectAanswers = new List<Text>();    // 选项


    private Text _quesTxt;                                  // 题目内容
    private Text _tipTxt;                                   // 提示内容
    private Button _tipBtn;                                 // 错误提示按钮
    private Button _submitBtn;                              // 提交按钮

    private string[] _dataQuestion;                         // 题目所有数据
    private List<string> _selectedAans = new List<string>();// 选择的选项
    private List<string> _correctAans = new List<string>(); // 正确答案

    Dictionary<PartBody, string> _quesDic = new Dictionary<PartBody, string>()
    {
        {PartBody.Head,"能够应用于头面部的推拿手法有：*A、㨰法*B、拿法*C、揉法*D、拍法*E、抖法*0*1*3" },
        {PartBody.Chest,"能够应用于胸腹部的推拿手法有：*A、插法*B、拿法*C、㨰法*D、拍法*E、点法*3" },
        {PartBody.Loin, "能够应用于腰骶部的推拿手法有：*A、抖法*B、击法*C、㨰法*D、弹拨法*E、压法*1"},
        {PartBody.Legs,"能够应用于下肢部的推拿手法有：*A按揉法*B叩法*C抖法*D摇法*E扳法*1*3" }
    };

    #region 
    //string[] quesArr =
    //{
    //    "能够应用于头面部的推拿手法有：*A、㨰法*B、拿法*C、揉法*D、拍法*E、抖法*0*1*3",
    //    "能够应用于胸腹部的推拿手法有：*A、插法*B、拿法*C、㨰法*D、拍法*E、点法*3",
    //    "能够应用于腰骶部的推拿手法有：*A、抖法*B、击法*C、㨰法*D、弹拨法*E、压法*1",
    //};
    #endregion
    
    /// <summary>
    /// 初始化和一些按钮监听事件
    /// </summary>
    public void Awake()
    {
        

        _quesTxt = GameObject.Find("Canvas/QuestionPanel/QuestionText").GetComponent<Text>();
        _tipTxt = GameObject.Find("Canvas/QuestionPanel/TipText").GetComponent<Text>();
        _tipTxt.text = null;
        _submitBtn = GameObject.Find("Canvas/QuestionPanel/SubmitBtn").GetComponent<Button>();
        _submitBtn.onClick.AddListener(() => {

            JudgeSelected();
        });
        _tipBtn = GameObject.Find("Canvas/QuestionPanel/TipBtn").GetComponent<Button>();
        _tipBtn.onClick.AddListener(() =>
        {
            _tipTxt.text = null;
            string temp = "";
            for (int i = 0; i < _correctAans.Count; i++)
            {               
                int index = int.Parse(_correctAans[i]);
                temp += selectToggles[index].name + " ";
                _tipTxt.text = "正确答案为：" + temp;
            }
        });
        _tipBtn.gameObject.SetActive(false);

        _closeBtn = GameObject.Find("Canvas/QuestionPanel/CloseBtn").GetComponent<Button>();
        _closeBtn.onClick.AddListener(() =>
        {
            Destroy(this.gameObject);
        });

       

        for (int i = 0; i < 5; i++)
        {
            selectToggles.Add(GameObject.Find("Canvas/QuestionPanel/SelectToggles").transform.GetChild(i).GetComponent<Toggle>());
            selectAanswers.Add(selectToggles[i].transform.GetChild(1).GetComponent<Text>());
        }

        foreach (var item in selectToggles)
        {
            item.isOn = false;
        }
    }

    public void Start()
    {
        ReadQuestion();

        // 把已经选择好的（移除的）选项添加到（移除）选项列表中
        for (int i = 0; i < selectToggles.Count; i++)
        {
            int count = i;
            selectToggles[i].onValueChanged.AddListener(delegate (bool isOn) {

                if (isOn)   // 选择则添加
                {
                    _selectedAans.Add(count.ToString());
                }
                else        // 取消选择则移除
                {
                    _selectedAans.Remove(count.ToString());
                }
                    
            });

        }

        

        
    }

    /// <summary>
    /// 读取试题内容
    /// </summary>
    void ReadQuestion()
    {
        // 决定显示那个部位的试题
        string questions = "";
        switch (partBody)
        {
            case PartBody.Head:
                questions = _quesDic[PartBody.Head];
                break;
            case PartBody.Chest:
                questions = _quesDic[PartBody.Chest];
                break;
            case PartBody.Loin:
                questions = _quesDic[PartBody.Loin];
                break;
            case PartBody.Legs:
                questions = _quesDic[PartBody.Legs];
                break;
        }


        //string questions = quesArr[0];
        _dataQuestion = questions.Split("*"[0]);
        
        _quesTxt.text = _dataQuestion[0];

        for (int i = 0; i < selectAanswers.Count; i++)
        {
            selectAanswers[i].text = _dataQuestion[i + 1];
        }

        for (int i = selectToggles.Count+1; i < _dataQuestion.Length; i++)
        {
            _correctAans.Add(_dataQuestion[i]);
        }
    }

    /// <summary>
    /// 判断选择是否正确
    /// </summary>
    void JudgeSelected()
    {
        if (_correctAans.Count == _selectedAans.Count)
        {
            foreach (var item in _selectedAans)
            {
                if (_correctAans.Contains(item))
                {
                    _tipTxt.text = "恭喜你，回答正确！";
                }
                else
                {
                    _tipTxt.text = "对不起，你回答错误！请查看提示";
                    _tipBtn.gameObject.SetActive(true);
                    break;
                }
            }
        }
        else
        {
            _tipTxt.text = "对不起，你回答错误！请查看提示";
            _tipBtn.gameObject.SetActive(true);
        }
    }
}
