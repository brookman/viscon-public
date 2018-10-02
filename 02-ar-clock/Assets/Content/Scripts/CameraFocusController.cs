using UnityEngine;
using Vuforia;

public class CameraFocusController : MonoBehaviour
{
    private bool enableTorch = false;
    private bool mVuforiaStarted = false;

    void Start()
    {
        VuforiaARController vuforia = VuforiaARController.Instance;

        if (vuforia != null)
            vuforia.RegisterVuforiaStartedCallback(StartAfterVuforia);
    }

    public void ToogleTorch()
    {
        enableTorch = !enableTorch;
        UpdateCameraSettings();
    }

    private void StartAfterVuforia()
    {
        mVuforiaStarted = true;
        UpdateCameraSettings();
    }

    void OnApplicationPause(bool pause)
    {
        if (!pause)
        {
            // App resumed
            if (mVuforiaStarted)
            {
                // App resumed and vuforia already started
                // but lets start it again...
                UpdateCameraSettings(); // This is done because some android devices lose the auto focus after resume
                // this was a bug in vuforia 4 and 5. I haven't checked 6, but the code is harmless anyway
            }
        }
    }

    private void UpdateCameraSettings()
    {
        var result = CameraDevice.Instance.SetFlashTorchMode(enableTorch);

        if (enableTorch && result)
        {
            Debug.Log("Torch enabled");
        }
        else if (enableTorch && !result)
        {
            Debug.Log("Can't enable torch");
        }

        if (CameraDevice.Instance.SetFocusMode(CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO))
        {
            Debug.Log("Autofocus set");
        }
        else
        {
            // never actually seen a device that doesn't support this, but just in case
            Debug.Log("this device doesn't support auto focus");
        }
    }
}