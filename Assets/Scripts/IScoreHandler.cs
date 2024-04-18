// Score Handler

using UnityEngine;

public interface IScoreHandler
{
    int GetScore();
    void HandleCoinCollection(Collider2D other, GameObject coinObject);
}


