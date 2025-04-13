using System.Collections.Generic;
using UnityEngine;

namespace Dialogue
{
    [CreateAssetMenu(fileName = "DialogueItem")]
    public class DialogueItem : ScriptableObject
    {
        [System.Serializable]
        public struct DialogueContainer
        {
            public Speaker speaker;
            public string phrase;
        }

        [SerializeField] private List<DialogueContainer> dialoguePhrase = default;

        public List<DialogueContainer> DialoguePhrase => dialoguePhrase;
    }
}
