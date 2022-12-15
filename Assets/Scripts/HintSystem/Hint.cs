using System;

namespace HintSystem
{
    [Serializable]
    public class Hint
    {
        public int Id;
        public string Text;

        public Hint(int id, string text)
        {
            Id = id;
            Text = text;
        }
    }
}