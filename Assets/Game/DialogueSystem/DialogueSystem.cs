using Cysharp.Threading.Tasks;
using UnityEngine.AddressableAssets;

namespace Dialogue
{
    public class DialogueSystem 
    {
        public async UniTask CreateDialogue(DialogueItem dialogueItem)
        {
            var dialogueGameObject = await Addressables.InstantiateAsync("CharacterDialogue");
            Dialogue dialogue = dialogueGameObject.GetComponent<Dialogue>();
            dialogue.SetupDialogue(dialogueItem);
            await dialogue.Run();
            Addressables.ReleaseInstance(dialogueGameObject);
        }
    }
}
