
public class HUD : MenuBase
{
    public UnityEngine.UI.Text scoreText;

    public override void SwitchState(bool stateEnable)
    {
        gameObject.SetActive(stateEnable);
    }

    public void UpdateScore(int newValue)
    {
        scoreText.text = newValue.ToString();
    }
}