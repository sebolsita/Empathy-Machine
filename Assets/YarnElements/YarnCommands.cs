using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class YarnCommands : MonoBehaviour
{
    public DialogueRunner dialogueRunner;

    public void StartNextOnboardingStage(string nextOnboardingStage)
    {
        dialogueRunner.StartDialogue(nextOnboardingStage);
    }
}
