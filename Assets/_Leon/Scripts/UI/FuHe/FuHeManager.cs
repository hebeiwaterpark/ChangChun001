using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FuHeManager : MonoBehaviour
{
    public static FuHeManager Instance;
    /// <summary>
    /// 存储对应的节点物体
    /// </summary>
    private Dictionary<string, GameObject> getNameGameobjectDic = new Dictionary<string, GameObject>();
    /// <summary>
    /// 关闭图片的btn
    /// </summary>
    private Button closeImageBtn;
    private GameObject canvas;
    /// <summary>
    /// 手法的ui
    /// </summary>
    public GameObject UIImage;
    /// <summary>
    /// 图片加载路径
    /// </summary>
    private string resourcesUrl = "shoufa/";

    private void Awake()
    {
        Instance = this;
        canvas = GameObject.Find("Canvas");
        UIImage = canvas.transform.Find("UIImage").gameObject;
        closeImageBtn = canvas.transform.Find("UIImage/close").GetComponent<Button>();
    }
    // Start is called before the first frame update
    void Start()
    {
        #region 主菜单
        GetUI(new string[] { "弹拨法", "勾点法" }, this.transform);
        #endregion

        closeImageBtn.onClick.AddListener(() =>
        {
            UIImage.gameObject.SetActive(false);

        });
    }
    /// <summary>
    /// a加载对应的图片
    /// </summary>
    public void LoadImage(string name)
    {
        Sprite sp = Resources.Load<Sprite>(resourcesUrl + name);
        // Debug.Log(sp.name+"***********");
        if (sp == null)
        {
            UIImage.gameObject.SetActive(false);
        }
        else
        {
            UIImage.GetComponent<Image>().sprite = sp;
            UIImage.gameObject.SetActive(true);
        }
    }
    /// <summary>
    /// 一级菜单
    /// </summary>
    /// <param name="str">菜单名称</param>
    /// <param name="partent">父节点</param>   
    public void GetUI(string[] str, Transform partent)
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

          
        }



    }
    /// <summary>
    /// 子菜单
    /// </summary>
    /// <param name="str">子菜单名字</param>
    /// <param name="getName">子菜单父节点名称</param>
    public void GetChildUI(string[] str, string getName)
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
