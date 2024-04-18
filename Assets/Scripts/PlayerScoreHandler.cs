

using UnityEngine;

public class PlayerScoreHandler : IScoreHandler
{
    private int _score;

    public int GetScore()
    {
        return _score;
    }

    public void HandleCoinCollection(Collider2D other, GameObject coinObject)
    {
        if (other.gameObject.tag == "coin")
        {
            _score += 100;
            Object.Destroy(coinObject);
        }
    }
}