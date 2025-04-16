using LevelCompletedDialogs;

namespace Characters.PlayerCharacter
{
    public class PlayerHealth : Health
    {
        public override void Death()
        {
            Game.Instance.GearSystem.Reset();
            LevelCompletedDialog.LoseDialog().Forget();
            Destroy(this.gameObject);
        }
    }
}
