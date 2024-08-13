using Study.Arguments.Arguments.Base;

namespace Study.Arguments.Arguments
{
    public class OutputLoginUser
    {
        public string Token { get; set; }
        public OutputUser OutputUser { get; set; }

        public OutputLoginUser() { }

        public OutputLoginUser(string token, OutputUser outputUser)
        {
            Token = token;
            OutputUser = outputUser;
        }
    }
}
