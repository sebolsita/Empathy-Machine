using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

namespace Amused.Interactions
{
    public class DoorInteraction : MonoBehaviour
    {
        #region PUBLIC PROPERTIES
        public Transform door; // Assign the door in inspector
        public float rotationSpeed = 2f; // Adjust for smoothness
        public float openAngle = -120f;
        public float closedAngle = 0f;
        #endregion

        #region PRIVATE VARIABLES
        private bool isGrabbed = false;
        private Coroutine rotateCoroutine;
        private XRGrabInteractable grabInteractable;
        #endregion

        #region UNITY METHODS
        private void Awake()
        {
            grabInteractable = GetComponent<XRGrabInteractable>();
            grabInteractable.selectEntered.AddListener(StartOpening);
            grabInteractable.selectExited.AddListener(StopOpening);
        }
        #endregion

        #region EVENT HANDLERS
        private void StartOpening(SelectEnterEventArgs args)
        {
            isGrabbed = true;
            if (rotateCoroutine != null) StopCoroutine(rotateCoroutine);
            rotateCoroutine = StartCoroutine(RotateDoor(openAngle));
        }

        private void StopOpening(SelectExitEventArgs args)
        {
            isGrabbed = false;
            if (rotateCoroutine != null) StopCoroutine(rotateCoroutine);
            rotateCoroutine = StartCoroutine(RotateDoor(closedAngle));
        }
        #endregion

        #region COROUTINES
        private IEnumerator RotateDoor(float targetAngle)
        {
            float startAngle = door.localEulerAngles.y;
            float elapsedTime = 0f;

            while (elapsedTime < 1f) // Adjust duration as needed
            {
                float angle = Mathf.LerpAngle(startAngle, targetAngle, elapsedTime);
                door.localEulerAngles = new Vector3(0, angle, 0);
                elapsedTime += Time.deltaTime * rotationSpeed;
                yield return null;
            }

            door.localEulerAngles = new Vector3(0, targetAngle, 0);
        }
        #endregion
    }
}
