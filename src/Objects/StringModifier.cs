

namespace Wyvern.Objects
{
    public class StringModifier
    {
        public static string Modify(string input, object Context)
        {
            if (input.IndexOf("{") == -1)
            {
                return input;
            }
            else
            {
                string[] parts = input.Split('{');
                string output = "";
                for (int i = 0; i < parts.Length; i++)
                {
                    if (i == 0)
                    {
                        output += parts[i];
                    }
                    else
                    {
                        string[] subparts = parts[i].Split('}');
                        if (subparts.Length == 1)
                        {
                            output += subparts[0];
                        }
                        else
                        {
                            string key = subparts[0];
                            string value = "";
                            if (Context.GetType().GetProperty(key) != null)
                            {
                                value = Context.GetType().GetProperty(key).GetValue(Context).ToString();
                            }
                            else
                            {
                                value = "";
                            }
                            output += value;
                            output += subparts[1];
                        }
                    }
                }
                return output;
            }
        }
    }
}