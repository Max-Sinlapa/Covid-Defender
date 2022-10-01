using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Selected_Mode : MonoBehaviour
{
    private GameObject Current_Selected;
    private Vector3 buildPOS;
    
    [Header("Event")]
    [SerializeField] protected UnityEvent m_Left_Mouse_Click = new();
    [SerializeField] protected UnityEvent m_Right_Mouse_Click = new();
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
            Instantiate(Current_Selected, buildPOS , transform.rotation);
            
        }
    }

    public void CancelBuild()
    {
        Destroy(Current_Selected);
        Current_Selected = null;
    }

    public void SelectedTower_1(GameObject turrent)
    {
        Current_Selected = Instantiate(turrent);
        
    }
    
    public void SelectedTower_2(GameObject turrent)
    {
        Current_Selected = Instantiate(turrent);
        
    }


}
