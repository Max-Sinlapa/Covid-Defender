using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Selected_Mode : MonoBehaviour
{
    private GameObject Current_Selected;
    private Vector3 buildPOS;
    public Money_System money;
    [SerializeField]public int Tower_1_Prize;
    [SerializeField]public int Tower_2_Prize;
    [SerializeField]public int Tower_3_Prize;
    
    [Header("Event")]
    [SerializeField] protected UnityEvent m_Left_Mouse_Click = new();
    [SerializeField] protected UnityEvent m_Right_Mouse_Click = new();
    [SerializeField] protected UnityEvent m_Buy_Tower = new();
    [SerializeField] protected UnityEvent m_Can_Not_Buy = new();

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Current_Selected != null)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
                if (hit.rigidbody != null)
                {
                    Vector3 rayDir = ray.direction;
                    rayDir = rayDir.normalized;
                    
                    Current_Selected.transform.position = hit.point;
                    buildPOS = hit.point;
                }
        }


        if (Input.GetMouseButtonDown(1))
            m_Right_Mouse_Click.Invoke();
        if (Input.GetMouseButtonDown(0))
            m_Left_Mouse_Click.Invoke();
    }

    public void BuildTower()
    {
        if (Current_Selected != null)
        {
            if (Current_Selected.CompareTag("Tower_1"))
                if (Money_System.m_CurrentMoney < Tower_1_Prize)
                {
                    Debug.Log("Not Enough Money");
                    m_Can_Not_Buy.Invoke();
                    return;
                }
            
            if (Current_Selected.CompareTag("Tower_2"))
                if (Money_System.m_CurrentMoney < Tower_2_Prize)
                {
                    Debug.Log("Not Enough Money");
                    m_Can_Not_Buy.Invoke();
                    return;
                }
            
            if (Current_Selected.CompareTag("Tower_3"))
                if (Money_System.m_CurrentMoney < Tower_3_Prize)
                {
                    Debug.Log("Not Enough Money");
                    m_Can_Not_Buy.Invoke();
                    return;
                }
            
            
            //----------------------------------------------------------------
            Instantiate(Current_Selected, buildPOS , Current_Selected.transform.rotation);
            //----------------------------------------------------------------
            
            
            ///////////////// Buy_Tower
            if (Current_Selected.CompareTag("Tower_1"))
            {
                Money_System.DecreaseMoney(Tower_1_Prize);
                m_Buy_Tower.Invoke();
                CancelBuild();
                //Debug.Log("BUY");
                
            }

            else if (Current_Selected.CompareTag("Tower_2"))
            {
                Money_System.DecreaseMoney(Tower_2_Prize);
                m_Buy_Tower.Invoke();
                CancelBuild();
            }

            else if (Current_Selected.CompareTag("Tower_3"))
            {
                Money_System.DecreaseMoney(Tower_3_Prize);
                m_Buy_Tower.Invoke();
                CancelBuild();
            }
            ///////////////// Buy_Tower
        }
    }

    public void CancelBuild()
    {
        Destroy(Current_Selected);
        Current_Selected = null;
        //Debug.Log("Cancel");
    }

    public void SelectedTower_1(GameObject turrent)
    {
        Current_Selected = Instantiate(turrent);
    }
    
    public void SelectedTower_2(GameObject turrent)
    {
        Current_Selected = Instantiate(turrent);
    }
    
    public void SelectedTower_3(GameObject turrent)
    {
        Current_Selected = Instantiate(turrent);
    }

                                        
}
