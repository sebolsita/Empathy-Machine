using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Yarn.Unity;

public class YarnCommands : MonoBehaviour
{
    public InMemoryVariableStorage yarnInMemoryStorage;

    public DialogueRunner dialogueRunner;

    public GameObject stageOneTargetObject, stageTwoTargetObject, stageThreeTargetObject;

    public Animator talkingInstructorAni,talkingInstructor2Ani, idleDoctorAni, talkingInterpreterAni, walkingNurseAni;

    public GameObject briefingRoomTarget;

    public GameObject player;

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

    //Animations

    //Instructor1

    [YarnCommand("talking_instructor_animation")]
    public void TalkingInstructorAnimation()
    {
        talkingInstructorAni.SetInteger("isInstructorTalking", 1);
    }

    [YarnCommand("stop_talking_instructor_animation")]
    public void StopTalkingInstructorAnimation()
    {
        talkingInstructorAni.SetInteger("isInstructorTalking", 0);
    }

    //Instructor2

    [YarnCommand("talking_instructor2_animation")]

    public void TalkingInstructor2Animation()
    {
        talkingInstructor2Ani.SetInteger("isInstructor2Talking", 1);
    }

    [YarnCommand("stop_talking_instructor2_animation")]

    public void StopTalkingInstructor2Animation()
    {
        talkingInstructor2Ani.SetInteger("isInstructor2Talking", 0);
    }

    //Doctor

    [YarnCommand("talking_doctor_animation")]
    public void TalkingDoctorAnimation()
    {
        talkingInstructorAni.SetInteger("isDoctorTalking", 1);
    }

    [YarnCommand("stop_talking_doctor_animation")]
    public void StopTalkingDoctorAnimation()
    {
        talkingInstructorAni.SetInteger("isDoctorTalking", 0);
    }

    //Interpreter

    [YarnCommand("talking_interpreter_animation")]
    public void TalkingInterpreterAnimation()
    {
        talkingInstructorAni.SetInteger("isInterpreterTalking", 1);
    }

    [YarnCommand("stop_talking_interpreter_animation")]
    public void StopTalkingInterpreterAnimation()
    {
        talkingInstructorAni.SetInteger("isInterpreterTalking", 0);
    }

    //Nurse

    [YarnCommand("nurse_reached_trigger")]

    public void NurseReachedTrigger()
    {
        walkingNurseAni.SetInteger("hasNurseReachedTrigger", 1);
    }

    //Teleports

    //Briefing Room

    [YarnCommand("teleport_to_briefing_room")]

    public void TeleportToBriefingRoom()
    {
        player.transform.position = briefingRoomTarget.transform.position;
    }
}
