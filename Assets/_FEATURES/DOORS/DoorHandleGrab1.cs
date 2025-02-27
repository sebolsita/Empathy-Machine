using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace Amused.Interactions
{
    public class DualTriggerDoor : MonoBehaviour
    {
        #region PUBLIC PROPERTIES
        public Transform door; // Assign door transform in Inspector
        public float rotationSpeed = 3f;
        public float leftOpenAngle = -90f;  // Rotation when touched from left side
        public float rightOpenAngle = 90f;  // Rotation when touched from right side
        public Collider leftTrigger;  // Assign the left collider in Inspector
        public Collider rightTrigger; // Assign the right collider in Inspector
        #endregion

        #region PRIVATE VARIABLES
        private bool isMoving = false;  // Prevents multiple triggers at once
        private Coroutine rotateCoroutine;
        #endregion

        #region UNITY METHODS
        private void OnTriggerEnter(Collider other)
        {
            if (isMoving) return;  // Ignore triggers while door is already moving

            if (other.CompareTag("PlayerHand"))
            {
                Debug.Log($"[DualTriggerDoor] PlayerHand detected by: {other.gameObject.name}");
                if (other == leftTrigger)
                {
                    MoveDoor(leftOpenAngle);
                }
                else if (other == rightTrigger)
                {
                    MoveDoor(rightOpenAngle);
                }
            }
        }
        #endregion

        #region PRIVATE METHODS
        private void MoveDoor(float targetAngle)
        {
            if (rotateCoroutine != null) StopCoroutine(rotateCoroutine);
            rotateCoroutine = StartCoroutine(RotateDoor(targetAngle));
        }
        #endregion

        #region COROUTINES
        private IEnumerator RotateDoor(float targetAngle)
        {
            isMoving = true; // Disable trigger detection while moving
            leftTrigger.enabled = false;
            rightTrigger.enabled = false;

            float startAngle = door.localEulerAngles.y;
            float elapsedTime = 0f;

            Debug.Log($"[DualTriggerDoor] Rotating to {targetAngle}°");

            while (elapsedTime < 1f)
            {
                float angle = Mathf.LerpAngle(startAngle, targetAngle, elapsedTime);
                door.localEulerAngles = new Vector3(0, angle, 0);
                elapsedTime += Time.deltaTime * rotationSpeed;
                yield return null;
            }

            door.localEulerAngles = new Vector3(0, targetAngle, 0);
            Debug.Log($"[DualTriggerDoor] Rotation complete. New angle: {door.localEulerAngles.y}");

            isMoving = false; // Re-enable trigger detection
            leftTrigger.enabled = true;
            rightTrigger.enabled = true;
        }
        #endregion
    }
}
