using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Empathy.Example.Syntax
{
    public class CodeStructureExample : MonoBehaviour
    {

        #region PUBLIC PROPERTIES
        // This region is for all public properties, which are variables that can be accessed from other scripts. Typically Get and Set methods are used to access these variables.
        public bool IsPublic { get; set; } // public should be Capitalized, camelCase.

        #endregion

        [SerializeField] private float _privateFloat; // This is a private variable that is serialized, meaning it can be seen and changed in the inspector.
        public UnityEvent OnComplete; // This is a UnityEvent, should always start with On and be followed by a description of what the event is for.
        public UnityEvent<string> OnStringEvent; // This is a UnityEvent with a string parameter. Meaning when the event is invoked, it will pass a string to any listeners.


        // Non Inspector Properties (Constants first)
        private const float _CONSTANT_FLOAT = 1.0f; // This is a constant float, meaning it will never change. Should be all caps with underscores between words.
        private Button _privateButton;




        #region UNITY METHODS

        // Awake should be used to check for any missing references, and to initialize any variables that need to be initialized before Start is called.
        private void Awake()
        {

        }

        // On Enable should be used to subscribe to any events that need to be subscribed to when the object is enabled.
        private void OnEnable()
        {
            _privateButton.onClick.AddListener(HandleOnButtonClick);
        }


        // Start should be used to initialize any variables that need to be initialized after Awake is called.
        private void Start()
        {

        }

        // On Disable should be used to unsubscribe from any events that need to be unsubscribed from when the object is disabled.
        private void OnDisable()
        {
            _privateButton.onClick.RemoveListener(HandleOnButtonClick);
        }

        // Update should be used to update any variables that need to be updated every frame.
        private void Update()
        {

        }

        #endregion


        #region PUBLIC METHODS

        // Public methods should be used to perform actions that can be called from other scripts.
        public void PublicMethod()
        {
            // Do something
        }

        #endregion


        #region EVENT HANDLERS

        // Event handlers should be used to handle events that are subscribed to in OnEnable. Should start with Handle, and be private in most cases.
        private void HandleOnButtonClick()
        {
            // Do something
        }

        #endregion


        #region PRIVATE METHODS

        // Private methods should be used to perform actions that are only called from within this script.
        private void PrivateMethod()
        {
            // Do something
        }

        #endregion


        #region COROUTINES

        // Coroutines should be used to perform actions that need to be performed over time.
        private IEnumerator CoroutineExample()
        {
            yield return new WaitForSeconds(1.0f);
        }

        #endregion


    }
}