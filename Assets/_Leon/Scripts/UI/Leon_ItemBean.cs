using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leon_ItemBean : Leon_ItemBeanBase
{
    public string Name { get; set; }
    public int Age { get; set; }
    public Leon_ItemBean(string _name/*,int _age*/)
    {
        this.Name = _name;
        //this.Age = _age;
    }
}
