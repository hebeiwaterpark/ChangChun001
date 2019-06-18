using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Xml;
using System.IO;

public class Leon_PullDownList : MonoBehaviour
{

    private List<GameObject> _itemPanelList;
    #region 菜单内容
    //private string[] list02 = { "单式手法", "复式手法", "其他手法", "手法考核", "常用腧穴" };
    private string[] list02 = { "单式手法",  "手法考核", "常用腧穴" };
    private string[] list03 = { "摆动类手法", /*"摩擦类手法", "挤压类手法", "振颤类手法", "叩击类手法", */"运动关节类手法" };
    private string[] list033 = { "手法选择", "动作要领" };
    private string[] list0333 = { "颈项部腧穴", "腰骶部腧穴" };
    //private string[] list04 = { "扳法", "摇法", "背法", "拔伸法" };
    private string[] list04 = { "滚法", /*"一指禅推法"*/ };
    private string[] list044 = { "扳法", /*"摇法", "背法", "拔伸法"*/ };
    private string[] list055 = { "颈部扳法", /*"胸背部扳法", "腰部扳法", "肩关节扳法"*/ };
    //private string[] list05 = { "颈部扳法", "胸背部扳法", "腰部扳法", "肩关节扳法", "肘关节扳法", "直腿抬高扳法" };
    private string[] list05 = { "操作方法", "动作要领", "注意事项", "临床应用", "操作视频", "自损之处", "VR解析" };
    private string[] list06 = { "颈部斜扳法", "颈椎旋转定位扳法", "寰枢关节旋转扳法" };
    #endregion


    public GameObject itemPanelPre;
    public GameObject opPanel;
    public GameObject opModel;
    public Button btn;

    int i = 0;

    private void Awake()
    {
        _itemPanelList = new List<GameObject>();
        opPanel.SetActive(false);
        opModel.SetActive(false);

        //AnalysisXML.GetContent("item.xml");
    }

    void GetContent(string fileName)
    {
        string path = Application.dataPath + @"\XML\" + fileName;
        if (File.Exists(path))
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(path);
            XmlNodeList nodeList = xmlDoc.SelectSingleNode("item").ChildNodes;
            foreach (XmlElement node1 in nodeList)
            {
                GameObject itemPanel01 = Instantiate(itemPanelPre);
                _itemPanelList.Add(itemPanel01);
                itemPanel01.GetComponent<Leon_ItemPanelBase>().SetBaseParent(this.transform);
                itemPanel01.GetComponent<Leon_ItemPanelBase>().InitPanelContent(new Leon_ItemBean(node1.GetAttribute("Name")/*, 1*/));
                if (node1.HasChildNodes)
                {
                    foreach (XmlElement node2 in node1)
                    {
                        GameObject itemPanel02 = Instantiate(itemPanelPre);
                        //_itemPanelList.Add(itemPanel02);
                        itemPanel02.GetComponent<Leon_ItemPanelBase>().SetItemParent(_itemPanelList[i].GetComponent<Leon_ItemPanelBase>());
                        itemPanel02.GetComponent<Leon_ItemPanelBase>().InitPanelContent(new Leon_ItemBean(node2.GetAttribute("Name")/*, 2*/));
                    }
                }
            }
        }
        i++;
    }

    private void Start()
    {
        #region
        //DirectoryInfo info = new DirectoryInfo(Application.dataPath + @"\XML");
        //FileInfo[] fis = info.GetFiles();

        //for (int i = 0; i < fis.Length / 2; i++)
        //{
        //    Debug.Log(fis[i].ToString());
        //    GetContent(fis[i].ToString());
        //}

        //btn.onClick.AddListener(() =>
        //{
        //text.text = "这里是测试";
        //GetContent("item.xml");
        //GetContent("item1.xml");
        //});
        #endregion

        #region 生成菜单
        // 生成一级菜单
        for (int i = 0; i < list02.Length; i++)
        {
            GameObject itemPanel01 = Instantiate(itemPanelPre);
            _itemPanelList.Add(itemPanel01);
            itemPanel01.GetComponent<Leon_ItemPanelBase>().SetBaseParent(this.transform);
            itemPanel01.GetComponent<Leon_ItemPanelBase>().InitPanelContent(new Leon_ItemBean(list02[i]/*, 1*/));
            if (list02[i] == "常用腧穴")
            {
                itemPanel01.gameObject.AddComponent<Button>().onClick.AddListener(() =>
                {
                    SceneManager.LoadScene("AcupointScene");
                });
            }
        }

        // 生成二级菜单
        for (int i = 0; i < list03.Length; i++)
        {
            GameObject itemPanel02 = Instantiate(itemPanelPre);
            //_itemPanelList.Add(itemPanel02);
            itemPanel02.GetComponent<Leon_ItemPanelBase>().SetItemParent(_itemPanelList[0].GetComponent<Leon_ItemPanelBase>());
            itemPanel02.GetComponent<Leon_ItemPanelBase>().InitPanelContent(new Leon_ItemBean(list03[i]/*, 2*/));
        }

        for (int i = 0; i < list033.Length; i++)
        {
            GameObject itemPanel02 = Instantiate(itemPanelPre);
            //_itemPanelList.Add(itemPanel02);
            itemPanel02.GetComponent<Leon_ItemPanelBase>().SetItemParent(_itemPanelList[1].GetComponent<Leon_ItemPanelBase>());
            itemPanel02.GetComponent<Leon_ItemPanelBase>().InitPanelContent(new Leon_ItemBean(list033[i]/*, 2*/));
            itemPanel02.transform.GetChild(0).GetChild(1).gameObject.AddComponent<Button>().onClick.AddListener(() =>
            {
                //Leon_OpPanel.opContent = itemPanel02.transform.GetChild(0).GetChild(1).GetComponent<Text>().text;
                //opPanel.SetActive(true);
                //opModel.SetActive(true);
                //opModel.GetComponent<Animator>().SetInteger("Play", 1);

                SceneManager.LoadScene("InspectionScene");
            });
        }

        for (int i = 0; i < list0333.Length; i++)
        {
            GameObject itemPanel02 = Instantiate(itemPanelPre);
            //_itemPanelList.Add(itemPanel02);
            itemPanel02.GetComponent<Leon_ItemPanelBase>().SetItemParent(_itemPanelList[2].GetComponent<Leon_ItemPanelBase>());
            itemPanel02.GetComponent<Leon_ItemPanelBase>().InitPanelContent(new Leon_ItemBean(list0333[i]/*, 2*/));
        }

        // 生成三级菜单
        for (int i = 0; i < list04.Length; i++)
        {
            GameObject itemPanel03 = Instantiate(itemPanelPre);
            //_itemPanelList.Add(itemPanel03);
            itemPanel03.GetComponent<Leon_ItemPanelBase>().SetItemParent(_itemPanelList[0].transform.GetChild(1).GetComponent<Leon_ItemPanelBase>());
            itemPanel03.GetComponent<Leon_ItemPanelBase>().InitPanelContent(new Leon_ItemBean(list04[i]/*, 3*/));
            itemPanel03.transform.GetChild(0).GetChild(1).gameObject.AddComponent<Button>().onClick.AddListener(() =>
            {
                Leon_OpPanel.opContent = itemPanel03.transform.GetChild(0).GetChild(1).GetComponent<Text>().text;
                opPanel.SetActive(true);
                //opModel.SetActive(true);
                //opModel.GetComponent<Animator>().SetInteger("Play", 1);
            });
        }

        for (int i = 0; i < list044.Length; i++)
        {
            GameObject itemPanel03 = Instantiate(itemPanelPre);
            //_itemPanelList.Add(itemPanel03);
            itemPanel03.GetComponent<Leon_ItemPanelBase>().SetItemParent(_itemPanelList[0].transform.GetChild(2).GetComponent<Leon_ItemPanelBase>());
            itemPanel03.GetComponent<Leon_ItemPanelBase>().InitPanelContent(new Leon_ItemBean(list044[i]/*, 3*/));
        }

        // 生成四级菜单（加按钮）
        //for (int i = 0; i < list05.Length; i++)
        //{
        //    GameObject itemPanel04 = Instantiate(itemPanelPre);
        //    //_itemPanelList.Add(itemPanel04);
        //    itemPanel04.GetComponent<Leon_ItemPanelBase>().SetItemParent(_itemPanelList[0].transform.GetChild(1).GetChild(1).GetComponent<Leon_ItemPanelBase>());
        //    itemPanel04.GetComponent<Leon_ItemPanelBase>().InitPanelContent(new Leon_ItemBean(list05[i], 4));
        //}

        for (int i = 0; i < list055.Length; i++)
        {
            GameObject itemPanel04 = Instantiate(itemPanelPre);
            //_itemPanelList.Add(itemPanel04);
            itemPanel04.GetComponent<Leon_ItemPanelBase>().SetItemParent(_itemPanelList[0].transform.GetChild(2).GetChild(1).GetComponent<Leon_ItemPanelBase>());
            itemPanel04.GetComponent<Leon_ItemPanelBase>().InitPanelContent(new Leon_ItemBean(list055[i]/*, 4*/));
            itemPanel04.transform.GetChild(0).GetChild(1).gameObject.AddComponent<Button>().onClick.AddListener(() =>
            {
                Leon_OpPanel.opContent = itemPanel04.transform.GetChild(0).GetChild(1).GetComponent<Text>().text;
                opPanel.SetActive(true);
                opModel.SetActive(true);
                opModel.GetComponent<Animator>().SetInteger("Play", 1);
            });
        }

        // 生成五级菜单(加按钮)
        //for (int i = 0; i < list05.Length; i++)
        //{
        //    GameObject itemPanel05 = Instantiate(itemPanelPre);
        //    //_itemPanelList.Add(itemPanel05);
        //    itemPanel05.GetComponent<Leon_ItemPanelBase>().SetItemParent(_itemPanelList[0].transform.GetChild(2).GetChild(1).GetChild(1).GetComponent<Leon_ItemPanelBase>());
        //    itemPanel05.GetComponent<Leon_ItemPanelBase>().InitPanelContent(new Leon_ItemBean(list05[i], 5));

        //    foreach (Transform item in itemPanel05.transform)
        //    {
        //        item.gameObject.AddComponent<Button>().onClick.AddListener(() =>
        //        {

        //        });
        //    }
        //}

        //// 生成六级菜单
        //for (int i = 0; i < 3; i++)
        //{
        //    GameObject itemPanel06 = Instantiate(itemPanelPre);
        //    _itemPanelList.Add(itemPanel06);
        //    itemPanel06.GetComponent<Leon_ItemPanelBase>().SetItemParent(_itemPanelList[16].GetComponent<Leon_ItemPanelBase>());
        //    itemPanel06.GetComponent<Leon_ItemPanelBase>().InitPanelContent(new Leon_ItemBean(list06[i], 6));
        //    itemPanel06.transform.GetChild(0).GetChild(1).gameObject.AddComponent<Button>().onClick.AddListener(() =>
        //    {
        //        // 弹出操作按钮
        //        string content = itemPanel06.transform.GetChild(0).GetChild(1).GetComponent<Text>().text;
        //        Leon_OpPanel.opContent = content;

        //        opPanel.SetActive(true);
        //    });
        //}
        #endregion
    }
}
