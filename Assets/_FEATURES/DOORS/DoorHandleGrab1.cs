using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace Amused.Interactions
{
    public class SimpleDoorTouch : MonoBehaviour
    {
        #region PUBLIC PROPERTIES
        public Transform door; // Assign the door in Inspector
        public float openAngle = -120f;
        public float closedAngle = 0f;
        public float rotationSpeed = 3f;
        #endregion

        #region PRIVATE VARIABLES
        private bool isOpen = false;
        private Coroutine rotateCoroutine;
        #endregion

        #region UNITY METHODS
        private void OnTriggerEnter(Collider other)
        {
            Debug.Log($"[SimpleDoorTouch] Trigger entered by: {other.gameObject.name}");

            if (other.CompareTag("PlayerHand"))
            {
                Debug.Log("[SimpleDoorTouch] PlayerHand detected! Toggling door.");
                ToggleDoor();
            }
            else
            {
                Debug.Log($"[SimpleDoorTouch] Ignored object: {other.gameObject.name}");
            }
        }
        #endregion

        #region PRIVATE METHODS
        private void ToggleDoor()
        {
            Debug.Log($"[SimpleDoorTouch] Toggling door. Current State: {(isOpen ? "Open" : "Closed")}");

            if (rotateCoroutine != null) StopCoroutine(rotateCoroutine);
            rotateCoroutine = StartCoroutine(RotateDoor(isOpen ? closedAngle : openAngle));
            isOpen = !isOpen;
        }
        #endregion

        #region COROUTINES
        private IEnumerator RotateDoor(float targetAngle)
        {
            float startAngle = door.localEulerAngles.y;
            float elapsedTime = 0f;

            Debug.Log($"[SimpleDoorTouch] Starting rotation to {targetAngle}°.");

            while (elapsedTime < 1f)
            {
                float angle = Mathf.LerpAngle(startAngle, targetAngle, elapsedTime);
                door.localEulerAngles = new Vector3(0, angle, 0);
                elapsedTime += Time.deltaTime * rotationSpeed;
                yield return null;
            }

            door.localEulerAngles = new Vector3(0, targetAngle, 0);
            Debug.Log($"[SimpleDoorTouch] Door rotation complete. New angle: {door.localEulerAngles.y}");
        }
        #endregion
    }
}