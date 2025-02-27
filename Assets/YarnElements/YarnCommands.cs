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

    public GameObject briefingRoomTarget, officeRoomTarget, waitingRoomTarget;

    public GameObject player;

    public GameObject survey;

    public GameObject patientHistory;

    public GameObject note;

    public CameraFader cameraFader;

    [Header("Inner Monologue")]
    public AudioSource innerMonologue1A;
    public AudioSource innerMonologue1B;
    public AudioSource innerMonologue2A;
    public AudioSource innerMonologue2B;
    public AudioSource innerMonologue3A;
    public AudioSource innerMonologue3B;
    public AudioSource innerMonologue4A;
    public AudioSource innerMonologue4B;
    public AudioSource innerMonologue5A;
    public AudioSource innerMonologue5B;
    public AudioSource innerMonologue6A;
    public AudioSource innerMonologue6B;
    public AudioSource innerMonologue7A;
    public AudioSource innerMonologue7B;
    public AudioSource innerMonologue8A;
    public AudioSource innerMonologue8B;
    public AudioSource innerMonologue9A;
    public AudioSource innerMonologue9B;
    public AudioSource innerMonologue10A;
    public AudioSource innerMonologue10B;
    public AudioSource innerMonologue11A;
    public AudioSource innerMonologue11B;

    [Header("Doctor Lines")]
    public AudioSource doctorQuestionOne;
    public AudioSource doctorQuestionTwo;
    public AudioSource doctorQuestionThree;
    public AudioSource doctorQuestionFour;
    public AudioSource doctorQuestionFive;
    public AudioSource doctorQuestionSix;
    public AudioSource doctorQuestionSeven;
    public AudioSource doctorQuestionEight;

    [Header("Player ResponsesA")]
    public AudioSource playerResponse1A;
    public AudioSource playerResponse2A;
    public AudioSource playerResponse3A;
    public AudioSource playerResponse4A;
    public AudioSource playerResponse5A;
    public AudioSource playerResponse6A;
    public AudioSource playerResponse7A;
    public AudioSource playerResponse8A;
    public AudioSource playerResponse9A;
    public AudioSource playerResponse10A;

    [Header("Player ResponsesB")]
    public AudioSource playerResponse1B;
    public AudioSource playerResponse2B;
    public AudioSource playerResponse3B;
    public AudioSource playerResponse4B;
    public AudioSource playerResponse5B;
    public AudioSource playerResponse6B;
    public AudioSource playerResponse7B;
    public AudioSource playerResponse8B;

    public AudioSource doorOpen;

    public GameObject door;



    public void Start()
    {
        dialogueRunner = FindObjectOfType<DialogueRunner>();
    }

    //Onboarding//

    [YarnCommand("door_open")]

    public void DoorOpen()
    {
        door.transform.Rotate(0, 90, 0);
        doorOpen.Play();
    }

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

    [YarnCommand("deactivate_onboarding_stage_one")]
    public void DeactivateOnboardingStageOne()
    {
        stageOneTargetObject.SetActive(false);
    }

    [YarnCommand("deactivate_onboarding_stage_two")]
    public void DeactivateOnboardingStageTwo()
    {
        stageTwoTargetObject.SetActive(false);
    }

    [YarnCommand("activate_simulationA")]
    public void LoadScenarioScene()
    {
        cameraFader.FadeToScene(2f, "ScenariosV3");
    }

    [YarnCommand("activate_simulationB")]

    public void LoadScenarioSceneB()
    {
        cameraFader.FadeWithDelay();
        player.transform.position = waitingRoomTarget.transform.position;
    }

    [YarnCommand("activate_survey_scene")]

    public void LoadSurveyScene()
    {
        SceneManager.LoadScene("StartEndV7");
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

    [YarnCommand("play_nurse_walk_in")]

    public void PlayNurseWalkIn()
    {
        walkingNurseAni.SetInteger("isNurseWalkingIn", 1);
    }

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

    //Office Room

    [YarnCommand("teleport_to_office")]

    public void TeleportToOffice()
    {
        player.transform.position = officeRoomTarget.transform.position;
    }

    //Spawning

    [YarnCommand("spawn_survey")]

    public void SpawnSurvey()
    {
        Debug.Log("Survey has been spawned");
        survey.SetActive(true);
    }

    [YarnCommand("spawn_patient_history")]

    public void SpawnPatientHistory()
    {
        Debug.Log("Patient history has been spawned");
        patientHistory.SetActive(true);
    }

    [YarnCommand("spawn_note")]

    public void SpawnNote()
    {
        Debug.Log("Note has been spawned");
        note.SetActive(true);

    }


    //InnerMonologue

    [YarnCommand ("play_inner_monologue1B")]

    public void play_inner_monologue1B()
    {
        innerMonologue1B.Play();
    }

    [YarnCommand("play_inner_monologue2B")]

    public void play_inner_monologue2B()
    {
        innerMonologue2B.Play();
    }

    [YarnCommand("play_inner_monologue3B")]

    public void play_inner_monologue3B()
    {
        innerMonologue3B.Play();
    }

    [YarnCommand("play_inner_monologue4B")]

    public void _play_inner_monologue4B()
    {
        innerMonologue4B.Play();
    }

    [YarnCommand("play_inner_monologue5B")]

    public void play_inner_monologue5B()
    {
        innerMonologue5B.Play();
    }

    [YarnCommand("play_inner_monologue6B")]

    public void play_inner_monologue6B()
    {
        innerMonologue6B.Play();
    }

    [YarnCommand("play_inner_monologue7B")]

    public void play_inner_monologue7B()
    {
        innerMonologue7B.Play();
    }

    [YarnCommand("play_inner_monologue8B")]

    public void play_inner_monologue8B()
    {
        innerMonologue8B.Play();
    }

    [YarnCommand("play_inner_monologue9B")]

    public void play_inner_monologue9B()
    {
        innerMonologue9B.Play();
    }

    [YarnCommand("play_inner_monologue1A")]

    public void play_inner_monologue1A()
    {
        innerMonologue1A.Play();
    }

    [YarnCommand("play_inner_monologue2A")]

    public void play_inner_monologue2A()
    {
        innerMonologue2A.Play();
    }

    [YarnCommand("play_inner_monologue3A")]

    public void play_inner_monologue3A()
    {
        innerMonologue3A.Play();
    }

    [YarnCommand("play_inner_monologue4A")]

    public void play_inner_monologue4A()
    {
        innerMonologue4A.Play();
    }

    [YarnCommand("play_inner_monologue5A")]

    public void play_inner_monologue5A()
    {
        innerMonologue5A.Play();
    }

    [YarnCommand("play_inner_monologue6A")]

    public void play_inner_monologue6A()
    {
        innerMonologue6A.Play();
    }

    [YarnCommand("play_inner_monologue7A")]


    public void play_inner_monologue7A()
    {
        innerMonologue7A.Play();
    }


    [YarnCommand("play_inner_monologue8A")]

    public void play_inner_monologue8A()
    {
        innerMonologue8A.Play();
    }

    [YarnCommand("play_inner_monologue9A")]

    public void play_inner_monologue9A()
    {
        innerMonologue9A.Play();
    }

    [YarnCommand("play_inner_monologue10A")]

    public void play_inner_monologue10A()
    {
        innerMonologue10A.Play();
    }

    [YarnCommand("play_inner_monologue11A")]

    public void play_inner_monologue11A()
    {
        innerMonologue11A.Play();
    }



    //DoctorLinesInterpreterScene
    [YarnCommand("play_doctor_question_one")]
    public void PlayDoctorQuestionOne()
    {
       doctorQuestionOne.Play();
    }

    [YarnCommand("play_doctor_question_two")]
    public void PlayDoctorQuestionTwo()
    {
        doctorQuestionTwo.Play();
    }

    [YarnCommand("play_doctor_question_three")]

    public void PlayDoctorQuestionThree()
    {
        doctorQuestionThree.Play();
    }

    [YarnCommand("play_doctor_question_four")]

    public void PlayDoctorQuestionFour()
    {
        doctorQuestionFour.Play();
    }

    [YarnCommand("play_doctor_question_five")]

    public void PlayDoctorQuestionFive()
    {
        doctorQuestionFive.Play();
    }

    [YarnCommand("play_doctor_question_six")]

    public void PlayDoctorQuestionSix()
    {
        doctorQuestionSix.Play();
    }

    [YarnCommand("play_doctor_question_seven")]

    public void PlayDoctorQuestionSeven()
    {
        doctorQuestionSeven.Play();
    }

    [YarnCommand("play_doctor_question_eight")]

    public void PlayDoctorQuestionEight()
    {
        doctorQuestionEight.Play();
    }


    //PlayerResponseA
    [YarnCommand("player_response_1a")]


    public void PlayerResponse1A()
    {
        playerResponse1A.Play();
    }

    [YarnCommand("player_response_2a")]

    public void PlayerResponse2A()
    {
        playerResponse2A.Play();
    }

    [YarnCommand("player_response_3a")]

    public void PlayerResponse3A()
    {
        playerResponse3A.Play();
    }

    [YarnCommand("player_response_4a")]

    public void PlayerResponse4A() 
    {
        playerResponse4A.Play();
    }

    [YarnCommand("player_response_5a")]
     public void PlayerResponse5A()
    {
        playerResponse5A.Play();
    }

    [YarnCommand("player_response_6a")]

    public void PlayerResponse6A()
    {
        playerResponse6A.Play();
    }

    [YarnCommand("player_response_7a")]

    public void PlayerResponse7A()
    {
        playerResponse7A.Play();
    }

    [YarnCommand("player_response_8a")]

    public void PlayerResponse8A()
    {
        playerResponse8A.Play();
    }

    [YarnCommand("player_response_9a")]

    public void PlayerResponse9A()
    {
        playerResponse9A.Play();
    }

    [YarnCommand("player_response_10a")]

    public void PlayerResponse10A()
    {
        playerResponse10A.Play();
    }

    //PlayerResponseB

    [YarnCommand("player_response_1b")]

    public void PlayerResponse1B()
    {
        playerResponse1B.Play();
    }

    [YarnCommand("player_response_2b")]

    public void PlayerResponse2B()
    {
        playerResponse2B.Play();
    }

    [YarnCommand("player_response_3b")]

    public void PlayerResponse3B()
    {
        playerResponse3B.Play();
    }

    [YarnCommand("player_response_4b")]
    public void PlayerResponse4B()
    {
        playerResponse4B.Play();
    }

    [YarnCommand("player_response_5b")]
    public void PlayerResponse5B()
    {
        playerResponse5B.Play();
    }

    [YarnCommand("player_response_6b")]
    public void PlayerResponse6B()
    {
       playerResponse6B.Play();
    }

    [YarnCommand("player_response_7b")]

    public void PlayerResponse7B()
    {
        playerResponse7B.Play();
    }

    [YarnCommand("player_response_8b")]
    public void PlayerResponse8B()
    {
        playerResponse8B.Play();
    }
}
