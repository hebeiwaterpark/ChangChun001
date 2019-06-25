using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartController : MonoBehaviour
{
    public void EventFunc()
    {

        SceneManager.LoadScene("LoginScene");
        #region 其他类手法菜单
        // GetChildUI(new string[] { "插法", "捩法" }, "其他类手法");

        #endregion
        #region 手法考核菜单
        //GetChildUI(new string[] { "手法选择", "动作要领" }, "手法考核");
        //GetChildUI(new string[] { "部位", "病症" }, "手法选择");
        #endregion
        #region 常用腧穴菜单
        //GetChildUI(new string[] { "颈项部腧穴", "腰骶部腧穴" }, "常用腧穴");

        #endregion
        //Debug.Log("this is a invalid file");



        //SHA256 shaM = new SHA256Managed();

    }
}
