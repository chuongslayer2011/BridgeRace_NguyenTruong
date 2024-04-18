using Scriptable;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class WinningPosition : MonoBehaviour
{
    [SerializeField] private WinningEffect effect;
    [SerializeField] private ColorData colorData;
    public List<ColorType> colorTypes = new List<ColorType>();
    private Vector3 offset = new Vector3(1, -1.5f, 0.5f);
    private WinningEffect winningPos;
    public void OnTriggerEnter(Collider other)
    {   

        winningPos = Instantiate(effect, transform.position + offset, Quaternion.identity);
        Character charReachFinal = other.GetComponent<Character>();
        charReachFinal.ClearAllBrick();
        colorTypes.Add(charReachFinal.GetColorType());
        colorTypes.Add(LevelManager.instance.GetMostBrickCharacterOnLevel());
        colorTypes.Add(LevelManager.instance.GetSecondMostBrickCharacter());
        effect.SetColorToChar(colorTypes[0], colorTypes[1], colorTypes[2]);
        if (other.CompareTag("Player"))
        {
            StartCoroutine(Result(true));
        }
        if (other.CompareTag("Enemy"))
        {
            StartCoroutine(Result(false));
        }
    }
    private IEnumerator Result(bool isWin)
    {
        
        if (!isWin)
        {
            UIController.instance.Lose();
        }
        else
        {
            yield return new WaitForSeconds(4f);
            UIController.instance.Win();
        }
        Destroy(winningPos.gameObject);
    }
}
