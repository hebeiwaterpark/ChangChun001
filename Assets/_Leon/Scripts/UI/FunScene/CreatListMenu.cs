using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CreatListMenu : MonoBehaviour
{

    public GameObject itemPanelPre;

    private List<GameObject> _listMenu1 = new List<GameObject>();
    private List<GameObject> _listMenu2 = new List<GameObject>();
    private List<GameObject> _listMenu3 = new List<GameObject>();

    private string[] list01 = { "摆动类手法", "摩擦类手法", "挤压类手法", "振颤类手法", "叩击类手法", "运动关节类手法" };
    private string[] list02 = { "摆动类手法",/* "摩擦类手法", "挤压类手法", "振颤类手法", "叩击类手法", */"运动关节类手法" };
    private string[] list03 = { "滚法", "一指禅推法" };

    void Start()
    {


        #region old
        //1
        //for (int i = 0; i < list01.Length; i++)
        //{
        //    GameObject itemPanel01 = Instantiate(itemPanelPre);
        //    _listMenu1.Add(itemPanel01);
        //    itemPanel01.GetComponent<Leon_ItemPanelBase>().SetBaseParent(this.transform);
        //    itemPanel01.GetComponent<Leon_ItemPanelBase>().InitPanelContent(new Leon_ItemBean(list01[i]/*, 1*/));
        //    if (list01[i] == "常用腧穴")
        //    {
        //        itemPanel01.gameObject.AddComponent<Button>().onClick.AddListener(() =>
        //        {
        //            SceneManager.LoadScene("AcupointScene");
        //        });
        //    }
        //}

        //// 2
        //for (int i = 0; i < list02.Length; i++)
        //{
        //    GameObject itemPanel02 = Instantiate(itemPanelPre);
        //    _listMenu2.Add(itemPanel02);
        //    itemPanel02.GetComponent<Leon_ItemPanelBase>().SetItemParent(_listMenu1[0].GetComponent<Leon_ItemPanelBase>());
        //    itemPanel02.GetComponent<Leon_ItemPanelBase>().InitPanelContent(new Leon_ItemBean(list02[i]/*, 2*/));
        //}

        //// 3
        //for (int i = 0; i < list03.Length; i++)
        //{
        //    GameObject itemPanel02 = Instantiate(itemPanelPre);
        //    _listMenu3.Add(itemPanel02);
        //    itemPanel02.GetComponent<Leon_ItemPanelBase>().SetItemParent(_listMenu2[0].GetComponent<Leon_ItemPanelBase>());
        //    itemPanel02.GetComponent<Leon_ItemPanelBase>().InitPanelContent(new Leon_ItemBean(list03[i]/*, 2*/));
        //}
        #endregion


    }




}
