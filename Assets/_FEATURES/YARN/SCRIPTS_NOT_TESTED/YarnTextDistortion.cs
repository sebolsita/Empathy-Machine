using System.Collections;
using UnityEngine;
using UnityEngine.UI;
//using Yarn.Unity;

namespace Amused.XR
{
    /// <summary>
    /// This class manages text distortion for Yarn dialogue based on player's gaze direction.
    /// When the player looks away from the doctor, the next lines of dialogue will be distorted.
    /// </summary>
    public class YarnTextDistortion : MonoBehaviour
    {
        #region PUBLIC PROPERTIES

        public bool IsDistorted { get; private set; } = false; // Flag to determine if distortion should be applied

        #endregion

        #region SERIALIZED PRIVATE FIELDS

        [SerializeField] private Text _dialogueText; // Reference to the UI Text displaying Yarn dialogue
        [SerializeField] private Transform _doctorFace; // The transform of the doctor’s face
        [SerializeField] private Camera _playerCamera; // The player's XR camera
        [SerializeField] private float _maxViewAngle = 15f; // Angle threshold for detecting gaze on the doctor
        [SerializeField] private float _distortionDelay = 0.5f; // Delay before distortion applies

        #endregion

        #region PRIVATE FIELDS

        private Coroutine _cachedDistortionCoroutine;

        #endregion

        #region UNITY METHODS

        private void Start()
        {
            if (!_dialogueText || !_doctorFace || !_playerCamera)
            {
                Debug.LogError("[YarnTextDistortion] Missing references! Ensure all fields are assigned.");
            }
        }

        #endregion

        #region PUBLIC METHODS

        /// <summary>
        /// Called externally by Yarn Dialogue system to update the dialogue text.
        /// If distortion is active, the text will be scrambled.
        /// </summary>
        public void UpdateDialogue(string newText)
        {
            if (IsDistorted)
            {
                _dialogueText.text = ScrambleText(newText);
            }
            else
            {
                _dialogueText.text = newText;
            }
        }

        /// <summary>
        /// Toggles text distortion based on player's gaze direction.
        /// </summary>
        public void CheckPlayerGaze()
        {
            bool isLookingAtDoctor = IsLookingAtDoctor();
            if (isLookingAtDoctor != IsDistorted)
            {
                IsDistorted = !isLookingAtDoctor;
                HandleDistortionToggle();
            }
        }

        #endregion

        #region PRIVATE METHODS

        /// <summary>
        /// Checks whether the player is looking directly at the doctor.
        /// </summary>
        private bool IsLookingAtDoctor()
        {
            Vector3 directionToFace = _doctorFace.position - _playerCamera.transform.position;
            float angle = Vector3.Angle(_playerCamera.transform.forward, directionToFace);

            return angle < _maxViewAngle;
        }

        /// <summary>
        /// Handles enabling/disabling distortion with a small delay for smoother transitions.
        /// </summary>
        private void HandleDistortionToggle()
        {
            if (_cachedDistortionCoroutine != null)
            {
                StopCoroutine(_cachedDistortionCoroutine);
            }

            _cachedDistortionCoroutine = StartCoroutine(ApplyDistortionAfterDelay());
        }

        #endregion

        #region COROUTINES

        /// <summary>
        /// Waits for a short delay before applying distortion, ensuring smooth experience.
        /// </summary>
        private IEnumerator ApplyDistortionAfterDelay()
        {
            yield return new WaitForSeconds(_distortionDelay);

            Debug.Log($"[YarnTextDistortion] Distortion toggled: {IsDistorted}");
        }

        #endregion

        #region TEXT PROCESSING

        /// <summary>
        /// Scrambles the letters inside words while keeping the first and last letter intact.
        /// </summary>
        private string ScrambleText(string input)
        {
            string[] words = input.Split(' ');

            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Length > 3)
                {
                    char[] chars = words[i].ToCharArray();
                    for (int j = 1; j < chars.Length - 1; j++)
                    {
                        int swapIndex = Random.Range(1, chars.Length - 1);
                        (chars[j], chars[swapIndex]) = (chars[swapIndex], chars[j]);
                    }
                    words[i] = new string(chars);
                }
            }
            return string.Join(" ", words);
        }

        #endregion
    }
}
