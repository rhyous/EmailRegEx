using Rhyous.StringLibrary;
using System.Text.RegularExpressions;

namespace EmailRegEx
{
    public static class EmailValidator
    {
        // This one just makes sure there are characters before and after the @
        public static string SimpleEmailPattern1 = @".+@.+";

        // This one makes sure the are characters before and after the @ as well as a character before and after the . in the domain.
        public static string SimpleEmailPattern2 = @".+@.*+\..+";

        /*
         ^ Start of word - no space at start
         [\w!#$%&'*+\-/=?\^_`{|}~]+	At least one valid local-part character not including a period.
         (\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*	Any number (including zero) of a group that starts with a single period and has at least one valid local-part character after the period.
         @	The @ character
         (	Start group 1
         (	Start group 2
         ([\-\w]+\.)+	At least one group of at least one valid word character or hyphen followed by a period
         [\w]{2,4}	Any two to four valid top level domain characters.
         )	End group 2
         |	an OR statement
         (	Start group 3
         ([0-9]{1,3}\.){3}[0-9]{1,3}	A simple regular expression for an IP Address.
         )	End group 3
         )	End group 1
         $  End of line - no space at end
         Note: IP Address not allowed
         */
        public static string ComplexEmailPattern1 = @"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*"
                                   + "@"
                                   + @"(([\w]+\.)+[a-zA-Z]{2,4})$";

        /*
         ^ Start of word - no space at start
         [\w!#$%&'*+\-/=?\^_`{|}~]+	At least one valid local-part character not including a period.
         (\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*	Any number (including zero) of a group that starts with a single period and has at least one valid local-part character after the period.
         @	The @ character
         (	Start group 1
         (	Start group 2
         ([\-\w]+\.)+	At least one group of at least one valid word character or hyphen followed by a period
         [\w]{2,4}	Any two to four valid top level domain characters.
         )	End group 2
         |	an OR statement
         (	Start group 3
         ([0-9]{1,3}\.){3}[0-9]{1,3}	A simple regular expression for an IP Address.
         )	End group 3
         )	End group 1
         $  End of line - no space at end
         */
        public static string ComplexEmailPattern2 = @"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*"
                                   + "@"
                                   + @"((([\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$";


        /*
         ^ Start of word - no space at start         
         [\w!#$%&'*+\-/=?\^_`{|}~]+	At least one valid local-part character not including a period.
         (\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*	Any number (including zero) of a group that starts with a single period and has at least one valid local-part character after the period.
         @	The @ character
         (	Start group 1
             (	Start group 2
                 ([\w]+([\-\w]*[\w]+)*\.)+	At least one group of at least one valid word character or hyphen followed by a period but not starting or ending with a hyphen
                 [\w]{2,4}	Any two to four valid top level domain characters.
             )	End group 2
             |	an OR statement
             (	Start group 3
                ((([01]?[0-9]{1,2}|2[0-4][0-9]|25[0-5]).){3}[01]?[0-9]{1,2}|2[0-4][0-9]|25[0-5]))$	 A simple regular expression for an IP Address.
             )	End group 3
         )	End group 1
         $  End of line - no space at end
         */
        public static string ComplexEmailPattern3 = @"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*"
                                  + "@"
                                  + @"((([\w]+([-\w]*[\w]+)*\.)+[a-zA-Z]{2,4})|"
                                  + @"((([01]?[0-9]{1,2}|2[0-4][0-9]|25[0-5]).){3}[01]?[0-9]{1,2}|2[0-4][0-9]|25[0-5]))\z";

        public static string ComplexEmailPattern4 = @"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*"
                                  + "@"
                                  + @"((([\w]+([-\w]*[\w]+)*\.)+[a-zA-Z]+)|"
                                  + @"((([01]?[0-9]{1,2}|2[0-4][0-9]|25[0-5]).){3}[01]?[0-9]{1,2}|2[0-4][0-9]|25[0-5]))\z";

        public static string HackedDotComPattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
                                  + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
                                  + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

        public static string ComplexEmailPatternOldFromStackOverflow = @"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*"
                                    + "@"
                                    + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$";

        static EmailValidator()
        {
            Pattern = ComplexEmailPattern4;
        }

        public static string Pattern { get; set; }

        public static bool IsValid(string inEmail, string inPattern = null)
        {
            string pattern = Pattern;
            if (inPattern != null)
                pattern = inPattern;
            //var emailWithoutDiacritics = inEmail.RemoveDiacritics();
            return Regex.IsMatch(inEmail, pattern);
        }
    }
}
