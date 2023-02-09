using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector.vCharacterController;
using Invector.vCharacterController.vActions;

public class SwimAudioProcessor: MonoBehaviour
{
    private vThirdPersonController _tpController;
    private vThirdPersonInput _tpInput;
    [SerializeField] private AK.Wwise.Event _waterSurfaceFloatingEvent;
    [SerializeField] private AK.Wwise.Event _deepDivingEvent;

    private void Start()
    {
        _tpController = GetComponent<vThirdPersonController>();
        _tpInput = GetComponent<vThirdPersonInput>();
    }

    private void PlayWaterSound(string swimType)  // вызывается аниматором
    {
        if (tpInput.cc.inputMagnitude < 0.1)
            return;

        AK.Wwise.Event wwiseEvent = null;

        if (swimType = AudioGlobalTextVariables.Sverhu)
        {
            wwiseEvent = _waterSurfaceFloatingEvent;
        }
        else if (swimType = AudioGlobalTextVariables.Snizu)
        {
            wwiseEvent = _deepDivingEvent;
        }

        AkSoundEngine.SetSwitch(AudioGlobalTextVariables.Swimming, swimType, gameObject);
        wwiseEvent.Post(gameObject);
    }
}
