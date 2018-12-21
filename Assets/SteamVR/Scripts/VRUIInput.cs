using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(SteamVR_LaserPointer))]
public class VRUIInput : MonoBehaviour
{
    SteamVR_LaserPointer laserPointer;
    Button btn;
    private int deviceIndex = -1;
    private SteamVR_Controller.Device controller;
    bool pointerOnButton = false;
    GameObject myEventSystem;
    // Use this for initialization
    void Start()
    {
        myEventSystem = GameObject.Find("EventSystem");
        laserPointer = GetComponent<SteamVR_LaserPointer>();
        laserPointer.PointerIn += LaserPointer_PointerIn;
        laserPointer.PointerOut += LaserPointer_PointerOut;
    }
    private void SetDeviceIndex(int index)
    {
        deviceIndex = index;
        controller = SteamVR_Controller.Input(index);
    }
    private void LaserPointer_PointerOut(object sender, PointerEventArgs e)
    {

        if (btn != null)
        {
            pointerOnButton = false;
            myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null);
            btn = null;
        }
    }

    private void LaserPointer_PointerIn(object sender, PointerEventArgs e)
    {

        if (e.target.gameObject.GetComponent<Button>() != null && btn == null)
        {

            btn = e.target.gameObject.GetComponent<Button>();
            btn.Select();
            Debug.Log(btn.tag.ToString());
            pointerOnButton = true;

        }
    }

    void Update()
    {
        if (pointerOnButton)
        {
            if (controller.GetPressUp(SteamVR_Controller.ButtonMask.Touchpad))
            {
                Debug.Log("123");
                btn.onClick.Invoke();
            }
        }
    }



}
