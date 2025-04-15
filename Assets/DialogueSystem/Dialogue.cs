using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using Cysharp.Threading.Tasks;

namespace Dialogue
{
    public class Dialogue : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI characterName = default;
        [SerializeField] private TextMeshProUGUI textBar = default;
        [SerializeField] private DialogueItem dialogueItem = default;

        [SerializeField] private Button nextButton = default;

        private int phraseCount = default;

        private string phrase = default;

        private UniTaskCompletionSource completionSource = new UniTaskCompletionSource();

        public async UniTask Run()
        {
            this.nextButton.OnClickAsObservable()
                .Subscribe(_ => 
                {
                    if (this.phraseCount >= this.dialogueItem.DialoguePhrase.Count)
                    {
                        this.gameObject.SetActive(false);
                        this.completionSource.TrySetResult(); 
                        return;
                    }
                    this.NextSentence().Forget();
                })
                .AddTo(this);

            this.nextButton.gameObject.SetActive(false);
            this.NextSentence().Forget();
            await completionSource.Task;
        }

        public void SetupDialogue(DialogueItem dialogueItem)
        {
            this.dialogueItem = dialogueItem;
        }

        private async UniTaskVoid NextSentence()
        {
            this.phrase = this.dialogueItem.DialoguePhrase[this.phraseCount];
            this.textBar.text = "";
            this.nextButton.gameObject.SetActive(false);
            await this.PrintText();
            this.phraseCount++;
            this.nextButton.gameObject.SetActive(true);

            if (this.phraseCount == this.phrase.Length)
            {
                TextMeshProUGUI nextButtonText = this.nextButton.GetComponentInChildren<TextMeshProUGUI>();
                nextButtonText.text = "Закрыть";
            }
        }

        private async UniTask PrintText()
        {
            foreach (char symbol in this.phrase)
            {
                this.textBar.text += symbol;  
                await UniTask.Delay(50, cancellationToken: this.GetCancellationTokenOnDestroy());  
            }
        }
    }
}
