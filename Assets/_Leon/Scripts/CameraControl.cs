using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 20180313
/// 这个脚本绑到相机上
/// w a s d 平移相机
/// 左键 没用
/// 中键 缩放 长按拖动
/// 右键 旋转视角
/// </summary>
public class CameraControl : MonoBehaviour
{
    public float near = 20.0f;
    public float far = 100.0f;

    public float sensitivityX = 2f;
    public float sensitivityY = 2f;
    public float sensitivetyZ = 0f;
    public float sensitivetyMove = 10f;
    public float sensitivetyMouseWheel = 50F;
    public int speed = 10;

    //public Camera camera;
    public Transform modelTrans;

    private float moveSpeed;
    private float sinQ;
    void Awake()
    {
        //camera = Camera.main;
    }

    /// <summary>
    /// 相机平移原理，用sin来计算
    /// camera ------------>
    ///        !↘ sinQ     ↑
    ///        !  ↘        ↑
    ///        !    ↘      ↑ f
    ///        !      ↘    ↑
    ///        !        ↘  ↑
    ///        ↓          ↘ moveSpeed
    ///        
    ///  sinQ = f/moveSpeed;
    ///  moveSpeed 作用与transform本身用 Translate来移动
    ///  f向上的力，用来抵消moveSpeed斜向下移动的向下的力，来实现平移
    /// </summary>
    void Update()
    {
        moveSpeed = speed * Time.deltaTime;
        sinQ = Mathf.Sin(Mathf.Deg2Rad * transform.localEulerAngles.x);

        #region WSAD键功能
        //w键前进  
        //if (Input.GetKey(KeyCode.W))
        //{
        //    //向上的力
        //    float f = transform.localEulerAngles.x > 0 ? sinQ * moveSpeed : sinQ * moveSpeed * -1;
        //    transform.Translate(0, 0, moveSpeed);
        //    transform.position = new Vector3(transform.position.x, transform.position.y + f, transform.position.z);
        //}
        ////s键后退  
        //if (Input.GetKey(KeyCode.S))
        //{
        //    float f = transform.localEulerAngles.x > 0 ? sinQ * moveSpeed * -1 : sinQ * moveSpeed;
        //    transform.Translate(0, 0, -1 * moveSpeed);
        //    transform.position = new Vector3(transform.position.x, transform.position.y + f, transform.position.z);
        //}
        ////a键后退  
        //if (Input.GetKey(KeyCode.A))
        //{
        //    transform.Translate(new Vector3(-1 * moveSpeed, 0, 0));
        //}
        ////d键后退  
        //if (Input.GetKey(KeyCode.D))
        //{
        //    transform.Translate(new Vector3(moveSpeed, 0, 0));
        //}
        #endregion


        if (Input.GetMouseButton(2))
        {
            transform.Translate(Vector3.left * Input.GetAxis("Mouse X")*Time.deltaTime*speed);
            transform.Translate(Vector3.down * Input.GetAxis("Mouse Y") * Time.deltaTime * speed);
        }

        // 滚轮实现镜头缩进和拉远  
        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            //camera.fieldOfView =this.camera.fieldOfView - Input.GetAxis("Mouse ScrollWheel")*sensitivetyMouseWheel; 
            //camera.fieldOfView = Mathf.Clamp(this.camera.fieldOfView, near, far); 
            Camera.main.transform.Translate(Vector3.forward * Input.GetAxis("Mouse ScrollWheel") * sensitivetyMouseWheel*Time.deltaTime);
        }

        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray,out hit))
            {
                if (hit.transform.tag == "model")
                {
                    
                    modelTrans = hit.transform;
                    //foreach (Transform item in modelTrans)
                    //{
                    //    item.Rotate(Vector3.up * 200 * Time.deltaTime * axis);
                    //}
                }
                else
                {
                    return;
                }
                
            }

            float axis = Input.GetAxis("Mouse X");
            if(modelTrans!=null) modelTrans.Rotate(Vector3.up * 200 * Time.deltaTime * axis);

        }

        if (Input.GetMouseButtonUp(0))
        {
            modelTrans = null;
        }

        //鼠标实现视角转动，类似第一人称视角  
        if (Input.GetMouseButton(1))
        {
            float rotationX = Input.GetAxis("Mouse X") * sensitivityX;
            float rotationY = Input.GetAxis("Mouse Y") * sensitivityY;
            transform.Rotate(-0, rotationX, 0);
            transform.Rotate(-rotationY, 0, 0);
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, 0);
        }

        //键盘按钮←和→实现视角水平旋转  

        if (Input.GetAxis("Horizontal") != 0)
        {
            float rotationZ = Input.GetAxis("Horizontal") * sensitivetyZ;
            transform.Rotate(0, 0, rotationZ);
        }
    }
}


