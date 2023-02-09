using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector.vCharacterController;

public class BreathingAudioProcessor : MonoBehaviour
{
    private vThirdPersonController _tpController;
    private vThirdPersonInput _tpInput;
    private AK.Wwise.Event _breathEvent;

    // Start is called before the first frame update
    private void Start()
    {
        _tpController = GetComponent<vThirdPersonController>();
        _tpInput = GetComponent<vThirdPersonInput>();
        _breathEvent.Post(gameObject);
    }

    // Update is called once per frame
    private void Update()
    {
        AkSoundEngine.SetRTPCValue(AudioGlobalTextVariables.Stamina, tpController.currentStamina, gameObject);

        if (tpInput.cc.inputMagnitude > 0.1)
        {
            if (tpController.isSprinting)
            {
                AkSoundEngine.SetSwitch(AudioGlobalTextVariables.Locomotion, AudioGlobalTextVariables.Running, gameObject);
            }
            else
            {
                AkSoundEngine.SetSwitch(AudioGlobalTextVariables.Locomotion, AudioGlobalTextVariables.Walking, gameObject);
            }
        }
        else
        {
            AkSoundEngine.SetSwitch(AudioGlobalTextVariables.Locomotion, AudioGlobalTextVariables.Idle, gameObject);
        }
    }
}
