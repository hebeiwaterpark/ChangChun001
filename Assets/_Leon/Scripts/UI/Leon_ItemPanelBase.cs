using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Leon_ItemPanelBase : MonoBehaviour
{
    private List<Leon_ItemPanelBase> _childList;            // 子物体集合
    private Vector2 _startSize;                             // 起始大小

    public Button downArrow;                                // 下箭头按钮
    public Sprite down, right, dot;
    public bool isOpen;                                     // 子物体开启状态


    private void Awake()
    {
        _childList = new List<Leon_ItemPanelBase>();
        Debug.Log(_childList.Count+"===============================");
        downArrow = this.transform.Find("ContentPanel/ArrowButton").GetComponent<Button>();
        downArrow.GetComponent<Image>().sprite = right;
        downArrow.onClick.AddListener(() =>
        {
            if (isOpen)
            {
                CloseChild();
                isOpen = false;
            }
            else
            {
                OpenChild();
                isOpen = true;
            }
        });

        _startSize = GetComponent<RectTransform>().sizeDelta;
        isOpen = false;
    }

    /// <summary>
    /// 打开子物体列表
    /// </summary>
    private void OpenChild()
    {
        if (_childList.Count == 0) return;

        foreach (Leon_ItemPanelBase child in _childList)
        {
            child.gameObject.SetActive(true);

            child.gameObject.GetComponent<Leon_ItemPanelBase>()
                .AddParentSize((int)child.gameObject.GetComponent<RectTransform>().sizeDelta.y);
        }

        downArrow.GetComponent<Image>().sprite = down;
    }

    /// <summary>
    /// 关闭子物体列表
    /// </summary>
    private void CloseChild()
    {
        if (_childList.Count == 0) return;
        foreach (Leon_ItemPanelBase child in _childList)
        {
            child.gameObject.SetActive(false);

            child.gameObject.GetComponent<Leon_ItemPanelBase>()
                .AddParentSize(-(int)child.gameObject.GetComponent<RectTransform>().sizeDelta.y);
        }

        downArrow.GetComponent<Image>().sprite = right;
    }

    /// <summary>
    /// 添加子物体到集合
    /// </summary>
    /// <param name="parentItemPanelBase">父物体</param>
    private void AddChild(Leon_ItemPanelBase parentItemPanelBase)
    {
        _childList.Add(parentItemPanelBase);
        if (_childList.Count >= 1) downArrow.GetComponent<Image>().sprite = right;
    }

    /// <summary>
    /// 设置父物体 父物体不为一级菜单
    /// </summary>
    /// <param name="parentItemPanelBase"></param>
    public void SetItemParent(Leon_ItemPanelBase parentItemPanelBase)
    {
        transform.SetParent(parentItemPanelBase.transform);
        parentItemPanelBase.AddChild(this);

        GetComponent<VerticalLayoutGroup>().padding = new RectOffset
            ((int)parentItemPanelBase.downArrow.GetComponent<RectTransform>().sizeDelta.x, 0, 0, 0);

        if (parentItemPanelBase.isOpen)
        {
            GetComponent<Leon_ItemPanelBase>().
                AddParentSize((int)this.gameObject.GetComponent<RectTransform>().sizeDelta.y);
        }
        else
        {
            transform.gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// 增加父物体高度
    /// </summary>
    /// <param name="change"></param>
    private void AddParentSize(int change)
    {
        if (transform.parent.GetComponent<Leon_ItemPanelBase>() != null)
        {
            transform.parent.GetComponent<Leon_ItemPanelBase>().UpdateRectTranSize(change);
            transform.parent.GetComponent<Leon_ItemPanelBase>().AddParentSize(change);
        }
    }

    /// <summary>
    /// 增加一个子物体后更新Panel大小
    /// </summary>
    /// <param name="change"></param>
    private void UpdateRectTranSize(int change)
    {
        this.gameObject.GetComponent<RectTransform>().sizeDelta =
            new Vector2(_startSize.x, this.gameObject.GetComponent<RectTransform>().sizeDelta.y + change);
    }

    /// <summary>
    /// 设置父物体 父物体为一级菜单
    /// </summary>
    /// <param name="tran"></param>
    public void SetBaseParent(Transform tran)
    {
        transform.SetParent(tran);
    }

    /// <summary>
    /// 填充Item数据
    /// </summary>
    public virtual void InitPanelContent(Leon_ItemBeanBase itemBeanBase) { }
}
