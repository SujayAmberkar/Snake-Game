using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerScore : MonoBehaviour
{
    public int score = 0;

    [PunRPC]
    public void UpdateScore(int newScore) {
    score = newScore;
  }
}
