using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using Cysharp.Threading.Tasks;

namespace Dialogue
{
    public class Dialogue : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI dialogueBar = default;
        [SerializeField] private DialogueItem dialogueItem = default;
        [SerializeField] private Button nextButton = default;
        [SerializeField] private TextMeshProUGUI nextButtonText = default;
        [SerializeField] private string closeText = default;
        [SerializeField] private Button closeButton = default;

        private int phraseCount = default;
        private string phrase = default;

        private UniTaskCompletionSource completionSource = default;

        public void SetupDialogue(DialogueItem dialogueItem)
        {
            this.dialogueItem = dialogueItem;
        }

        public async UniTask Run()
        {
            this.completionSource = new UniTaskCompletionSource();

            this.nextButton.OnClickAsObservable()
                .Subscribe( _ => this.NextButtonActions())
                .AddTo(this);

            this.closeButton.OnClickAsObservable()
                .Subscribe(_ => this.CloseDialogue())
                .AddTo(this);

            this.nextButton.gameObject.SetActive(false);
            this.CreateSentence().Forget();
            await this.completionSource.Task;
            this.completionSource = null;
        }

        private void NextButtonActions()
        {
            if (this.phraseCount >= this.dialogueItem.DialoguePhrase.Count)
            {
                this.CloseDialogue();
                return;
            }
            this.CreateSentence().Forget();
        }

        private async UniTaskVoid CreateSentence()
        {
            this.phrase = this.dialogueItem.DialoguePhrase[this.phraseCount];
            this.nextButton.gameObject.SetActive(false);
            await this.PrintText();
            this.phraseCount++;
            this.nextButton.gameObject.SetActive(true);

            if (this.phraseCount == this.dialogueItem.DialoguePhrase.Count)
            {
                this.nextButtonText.text = this.closeText;
            }
        }

        private async UniTask PrintText()
        {
            this.dialogueBar.text = "";
            foreach (char symbol in this.phrase)
            {
                this.dialogueBar.text += symbol;  
                await UniTask.Delay(50, cancellationToken: this.GetCancellationTokenOnDestroy());  
            }
        }
        
        private void CloseDialogue()
        {
            this.completionSource.TrySetResult();
            this.gameObject.SetActive(false);
        }
    }
}
