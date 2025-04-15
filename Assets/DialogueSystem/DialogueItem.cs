using System.Collections.Generic;
using UnityEngine;

namespace Dialogue
{
    [CreateAssetMenu(fileName = "DialogueItem")]
    public class DialogueItem : ScriptableObject
    {
        [SerializeField] private List<string> dialoguePhrase = default;
        public List<string> DialoguePhrase => this.dialoguePhrase;
    }
}
