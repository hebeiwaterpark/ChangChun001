using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoginManager : MonoBehaviour
{
    public InputField userName;
    public InputField passWord;
    public Button loginBtn;

    public Text tipTxt;

    void Start()
    {
        //http://www.mxtong.net.cn/GateWay/Services.asmx/DirectSend?UserID=998131&Account=admin&Password=ANJD6L&Phones=18630523825;&Content=123&SendTime=&SendType=1&PostFixNumber=
        loginBtn.onClick.AddListener(() =>
        {
            string usr = userName.gameObject.transform.GetChild(2).GetComponent<Text>().text;
            string pwd = passWord.gameObject.transform.GetChild(2).GetComponent<Text>().text;


            if (usr.Equals("123") && pwd.Equals("123"))
            {
                SceneManager.LoadScene("MenuScene");
            }
            else
            {
                tipTxt.text = "用户名或密码匹配！";
            }
        });
    }
}
