using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// 处理菜单节点
/// </summary>
public class GetList : MonoBehaviour
{
    #region old
    //private static GetList instance;
    //private GetList()
    //{

    //}
    //public static GetList Instance()
    //{
    //    if (instance == null)
    //    {
    //        instance = new GetList();
    //    }
    //    return instance;
    //}
    #endregion
    /// <summary>
    /// 存储对应的节点物体
    /// </summary>
    private Dictionary<string, GameObject> getNameGameobjectDic = new Dictionary<string, GameObject>();

    private string[] list01 = { "摆动类手法", "摩擦类手法", "挤压类手法", "振颤类手法", "叩击类手法", "运动关节类手法", "复合类手法", "其他类手法" };
    private void Start()
    {
        #region 主菜单
        GetUI(list01, this.transform);
        #endregion
        #region 摆动类手法菜单
        GetChildUI(new string[] {"滚法", "一指禅推法" }, "摆动类手法");
        GetChildUI(new string[] { "操作方法", "动作要领", "注意事项", "临床应用", "操作视频", "危险之处", "VR动画解析" }, "滚法");
        #endregion
        #region 挤压类手法菜单
        GetChildUI(new string[] { "压法", "点法" }, "挤压类手法");

        #endregion
        #region 摩擦类手法菜单
        GetChildUI(new string[] { "擦法", "推法" }, "摩擦类手法");

        #endregion
        #region 振颤类手法菜单
        GetChildUI(new string[] { "抖法" }, "振颤类手法");
        GetChildUI(new string[] { "抖腿大师法" }, "抖法");
        #endregion
        #region 叩击类手法菜单
        GetChildUI(new string[] { "击法" }, "叩击类手法");

        #endregion 
        #region 复合类手法菜单
        GetChildUI(new string[] { "弹拨法" , "勾点法" }, "复合类手法");

       #endregion
        #region 运动关节子菜单
        GetChildUI(new string[] { "扳法", "摇法", "背法", "拨伸法" }, "运动关节类手法");
        GetChildUI(new string[] { "颈部扳法", "胸背部扳法", "腰部扳法", "肩关节扳" }, "扳法");
        GetChildUI(new string[] { "操作方法", "动作要领", "注意事项", "临床应用", "操作视频", "危险之处", "VR动画解析" }, "颈部扳法");
        #endregion


    }


    /// <summary>
    /// 一级菜单
    /// </summary>
    /// <param name="str">菜单名称</param>
    /// <param name="partent">父节点</param>   
    public void GetUI(string[] str,Transform partent)
    {
        GameObject prefab = Resources.Load<GameObject>("ItemPanel");
        for (int i = 0; i < str.Length; i++)
        {
            GameObject obj = GameObject.Instantiate(prefab);
            obj.name = str[i];
            if (!getNameGameobjectDic.ContainsKey(str[i]))
            {
                getNameGameobjectDic.Add(str[i], obj);
            }
                  
            obj.GetComponent<Leon_ItemPanelBase>().SetBaseParent(partent);
            
            obj.GetComponent<Leon_ItemPanelBase>().InitPanelContent(new Leon_ItemBean(str[i]));

            if (str[i] == "常用腧穴")
            {
                obj.gameObject.AddComponent<Button>().onClick.AddListener(() =>
                {
                    SceneManager.LoadScene("AcupointScene");
                });
            }
        }



    }
    /// <summary>
    /// 子菜单
    /// </summary>
    /// <param name="str">子菜单名字</param>
    /// <param name="getName">子菜单父节点名称</param>
    public void GetChildUI(string[] str,string getName )
    {
        GameObject prefab = Resources.Load<GameObject>("ItemPanel");
        for (int i = 0; i < str.Length; i++)
        {
            GameObject obj = GameObject.Instantiate(prefab);
            obj.name = str[i];
            if (!getNameGameobjectDic.ContainsKey(str[i]))
            {
                getNameGameobjectDic.Add(str[i], obj);
            }           
            obj.GetComponent<Leon_ItemPanelBase>().SetItemParent(getNameGameobjectDic[getName].GetComponent<Leon_ItemPanelBase>());
            
            obj.GetComponent<Leon_ItemPanelBase>().InitPanelContent(new Leon_ItemBean(str[i]));
        }


    }



}
