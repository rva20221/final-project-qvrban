using System;
using UnityEngine;

namespace HintSystem
{
    [Serializable]
    public class Hint
    {
        public int Id;
        public string Header;
        public string Text;

        public Hint(int id, string header, string text)
        {
            Id = id;
            Header = header;
            Text = text;
        }
    }
}