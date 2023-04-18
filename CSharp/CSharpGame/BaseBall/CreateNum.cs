using System.Text;


namespace Baseball
{
    internal class CreateNum
    {

        public static string Create()
        {
            Random _random = new Random();
            StringBuilder _num = new StringBuilder();
            _num.Clear();
            int[] numArray = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int count = 0;

            while (count < 3)
            {
                int ArrayNum = _random.Next() % 10;
                if (count == 0 &&
                    numArray[ArrayNum] != -1 &&
                    numArray[ArrayNum] != 0)
                {
                    _num.Append(numArray[ArrayNum]);
                    numArray[ArrayNum] = -1;
                    count++;
                }
                else if (count != 0 &&
                         numArray[ArrayNum] != -1)
                {
                    _num.Append(numArray[ArrayNum]);
                    numArray[ArrayNum] = -1;
                    count++;
                }
            }

            return _num.ToString();
        }
    }
}
