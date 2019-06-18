using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Leon_ItemPanel : Leon_ItemPanelBase
{
    public override void InitPanelContent(Leon_ItemBeanBase itemBeanBase)
    {
        base.InitPanelContent(itemBeanBase);
        Leon_ItemBean itemBean = itemBeanBase as Leon_ItemBean;
        this.transform.Find("ContentPanel/Text")
            .GetComponent<Text>().text = itemBean.Name/* + itemBean.Age*/;
    }
}
