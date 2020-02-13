using System.Text.RegularExpressions;

namespace ConsidKompetens_Web.Helpers
{
  public static class PasswordStrength
  {
    public static bool CheckPasswordComplexity(string password)
    {
      Regex reg = new Regex(@"^(?=.{8})(?=.*[^a-zA-Z])");
      if (reg.IsMatch(password))
      {
        return true;
      }
      return false;
    }
  }
}