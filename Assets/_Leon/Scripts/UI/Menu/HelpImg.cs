using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelpImg : MonoBehaviour
{
    private Button _closeBtn;

    // Start is called before the first frame update
    void Start()
    {
        _closeBtn = transform.GetChild(0).GetComponent<Button>();
        _closeBtn.onClick.AddListener(() =>
        {
            this.gameObject.transform.SetAsFirstSibling();
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
