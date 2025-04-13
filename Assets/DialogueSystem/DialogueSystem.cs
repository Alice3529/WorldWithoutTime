using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Dialogue
{
    public class DialogueSystem : MonoBehaviour
    {
        public async UniTaskVoid CreateDialogue(DialogueItem dialogueItem)
        {
            var dialogueGameObject = await Addressables.InstantiateAsync("CharacterDialogue");
            Dialogue dialogue = dialogueGameObject.GetComponent<Dialogue>();
            dialogue.SetupDialogue(dialogueItem);
            await dialogue.Run();
            Addressables.ReleaseInstance(dialogueGameObject);
        }
    }
}
