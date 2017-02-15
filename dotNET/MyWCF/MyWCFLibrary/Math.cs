namespace MyWCFLibrary
{
    class Math : IMath
    {
        public string Add(string num1, string num2)
        {
            return (int.Parse(num1) + int.Parse(num2)).ToString();
        }

        public string Multiply(string num1, string num2)
        {
            return (int.Parse(num1) * int.Parse(num2)).ToString();
        }
    }
}
