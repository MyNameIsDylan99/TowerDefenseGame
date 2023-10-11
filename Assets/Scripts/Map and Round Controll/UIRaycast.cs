using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIRaycast : MonoBehaviour
{
    GraphicRaycaster m_Raycaster;

    PointerEventData m_PointerEventData;

    EventSystem m_EventSystem;

    public bool CheckForButton()
    {
        m_PointerEventData = new PointerEventData(m_EventSystem);
        m_PointerEventData.position = Input.mousePosition;
        List<RaycastResult> results = new List<RaycastResult>();
        m_Raycaster.Raycast(m_PointerEventData, results);
        if (results.Count > 0)
        {
            foreach (RaycastResult result in results)
            {
                if(result.gameObject.GetComponent<Button>()!=null)
                {
                    return true;
                }
            }
        }
        return false;
    }
    // Start is called before the first frame update
    void Start()
    {
        m_Raycaster = GetComponent<GraphicRaycaster>();
        m_EventSystem = GetComponent<EventSystem>();
    }



}
