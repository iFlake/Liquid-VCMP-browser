#region Remark
/*
    A very dirty piece of code I sketched up
*/
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liquid_VCMP_browser
{
    public class JsonIndenter
    {
        protected string output;
        protected int indentation_level;
        protected bool last_indented = false;
        
        public string Indent(string JSON)
        {
            bool started = true;
            bool instring = false;
            bool inescape = false;

            foreach (char character in JSON)
            {
                if (instring == true)
                {
                    output += character.ToString();
                    if (inescape == true) inescape = false;
                    else
                    {
                        if (character == '\\') inescape = true;
                        else if (character == '\"') instring = false;
                    }
                    continue;
                }

                switch (character)
                {
                    case '"':
                        output += "\"";
                        instring = true;
                        break;

                    case ':':
                        output += ": ";
                        last_indented = false;
                        break;

                    case ',':
                        if (last_indented == true) output = output.Substring(0, output.Length - ((4 * indentation_level) + 1));
                        output += ",";
                        NewLine();
                        last_indented = true;
                        break;

                    case '{':
                    case '[':
                        if (started == false) NewLine();
                        output += character.ToString();
                        ++indentation_level;
                        NewLine();
                        last_indented = true;
                        break;

                    case '}':
                    case ']':
                        --indentation_level;
                        if (last_indented == false) NewLine();
                        else output = output.Substring(0, output.Length - 4);
                        output += character.ToString();
                        NewLine();
                        last_indented = true;
                        break;

                    default:
                        output += character.ToString();
                        last_indented = false;
                        break;
                }
                started = false;
            }

            return output;
        }

        public void NewLine()
        {
            output += "\n" + new string(' ', indentation_level * 4);
        }
    }
}
