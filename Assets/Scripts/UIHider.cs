using TMPro;
using UnityEngine;

public class UIHider : MonoBehaviour
{
    [SerializeField] GameObject uiHider;
    private bool uiHiding = false;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.H))
        {
            if (uiHiding==false)
            {
                uiHider.SetActive(true);
                uiHiding = true;
            }
            else
            {
                uiHiding = false;
                uiHider.SetActive(false);
            }
            
        }
    }
}
