using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Yarn.Unity;

public class YarnCommands : MonoBehaviour
{
    public DialogueRunner dialogueRunner;

    public GameObject stageOneTargetObject, stageTwoTargetObject, stageThreeTargetObject;

    public Animator talkingInstructorAni, idleDoctorAni;

    public void Start()
    {
        dialogueRunner = FindObjectOfType<DialogueRunner>();
    }

    //Onboarding//

    [YarnCommand("activate_onboarding_stage_one")]
    public void ActivateOnboardingStageOne()
    {
        stageOneTargetObject.SetActive(true);
    }

    [YarnCommand("activate_onboarding_stage_two")]
    public void ActivateOnboardingStageTwo()
    {
        stageTwoTargetObject.SetActive(true);
    }

    [YarnCommand("activate_onboarding_stage_three")]
    public void ActivateOnboardingStageThree()
    {
        stageThreeTargetObject.SetActive(true);
    }

    [YarnCommand("activate_simulation")]
    public void ActivateSimulation()
    {
        SceneManager.LoadScene("Simulation");
    }

    [YarnCommand("restart_onboarding")]
    public void RestartOnboarding()
    {
        SceneManager.LoadScene("Onboarding");
    }

    [YarnCommand("exit_application")]
    public void ExitApplication()
    {
        Application.Quit();
    }


    public void StartNextOnboardingStage(string stage)
    {
        dialogueRunner.StartDialogue(stage);

        Debug.Log("Onboarding event " + stage + " has been started");
    }

    //Animations//

    [YarnCommand("talking_instructor_animation")]
    public void TalkingNPCAnimation()
    {
        talkingInstructorAni.SetInteger("isTalking", 1);
    }

    [YarnCommand("stop_talking_instructor_animation")]
    public void StopTalkingNPCAnimation()
    {
        talkingInstructorAni.SetInteger("isTalking", 0);
    }

    
}
