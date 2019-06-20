using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Leon_Login : MonoBehaviour
{
    public InputField userName;
    public InputField passWord;
    public Button loginBtn;

    public Text tipTxt;

    void Start()
    {
        loginBtn.onClick.AddListener(() =>
        {
            string usr = userName.gameObject.transform.GetChild(2).GetComponent<Text>().text;
            string pwd = passWord.gameObject.transform.GetChild(2).GetComponent<Text>().text;

            Debug.Log(usr + " " + pwd);
            if (usr.Equals("123") && pwd.Equals("123"))
            {
                SceneManager.LoadScene("MainMenu");
            }
            else
            {
                tipTxt.text = "用户名或密码不匹配！";
            }
        });
    }

    
}
                                                                                                     