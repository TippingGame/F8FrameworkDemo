using F8Framework.Core;
using UnityEngine;

public class XboxInputDevice : InputDeviceBase
{
    public override void OnStartUp()
    {
        RegisterVirtualButton(InputButtonType.MouseLeft);
            
        RegisterVirtualAxis(InputAxisType.Horizontal);
        RegisterVirtualAxis(InputAxisType.Vertical);
        RegisterVirtualAxis(InputAxisType.HorizontalRaw);
        RegisterVirtualAxis(InputAxisType.VerticalRaw);
    }

    public override void OnRun()
    {
        if (Input.GetKeyDown(KeyCode.JoystickButton0))
        {
            SetButtonStart(InputButtonType.MouseLeft);
            SetButtonDown(InputButtonType.MouseLeft);
        }

        if (Input.GetKeyUp(KeyCode.JoystickButton0))
        {
            SetButtonUp(InputButtonType.MouseLeft);
        }
        
        SetAxis(InputAxisType.Horizontal, Input.GetAxis("Horizontal"));
        SetAxis(InputAxisType.Vertical, Input.GetAxis("Vertical"));
        SetAxis(InputAxisType.HorizontalRaw, Input.GetAxisRaw("Horizontal"));
        SetAxis(InputAxisType.VerticalRaw, Input.GetAxisRaw("Vertical"));
    }

    public override void OnShutdown()
    {
        UnRegisterVirtualButton(InputButtonType.MouseLeft);
        
        UnRegisterVirtualAxis(InputAxisType.Horizontal);
        UnRegisterVirtualAxis(InputAxisType.Vertical);
        UnRegisterVirtualAxis(InputAxisType.HorizontalRaw);
        UnRegisterVirtualAxis(InputAxisType.VerticalRaw);
    }
}
