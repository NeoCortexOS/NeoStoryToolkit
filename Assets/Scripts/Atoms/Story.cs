using UnityEngine;
using UnityAtoms;
using UnityAtoms.BaseAtoms;

    [System.Serializable]
    public struct Line
    {
        public AudioClip Clip;
        [TextArea(2,5)]
        public string text;
        public float duration;
        
    }
    [CreateAssetMenu(fileName = "New Story", menuName = "Story")]
    public class Story : ScriptableObject
    {
        public Line[] lines;
        public Story nextStory;
    }
