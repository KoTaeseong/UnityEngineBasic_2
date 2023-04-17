using System.Text;

Random _random;
_random = new Random();
bool game = true;


//컴퓨터 숫자 3자리 정하기
int[] numArray = {0,1,2,3,4,5,6,7,8,9 };
int count = 0;
StringBuilder num = new StringBuilder();
while (count < 3)
{
    int ArrayNum = _random.Next() % 10;
    if (count == 0 &&
        numArray[ArrayNum] != -1 &&
        numArray[ArrayNum] != 0)
    {
        num.Append(numArray[ArrayNum]);
        numArray[ArrayNum] = -1;
        count++;
    }
    else if (count != 0 && 
             numArray[ArrayNum] != -1)
    {
        num.Append(numArray[ArrayNum]);
        numArray[ArrayNum] = -1;
        count++;
    }
}
//Console.WriteLine(num);


Console.WriteLine("컴퓨터가 값을 생각했어요");
Console.WriteLine("컴퓨터가 생각한 값을 맞춰보세요.(3자리)");

while (game)
{
    string input = Console.ReadLine();


    int Boll = 0;
    int Strike = 0;
    int Out = 0;

    for (int i = 0; i < num.Length; i++)
    {
        bool OutCheck = true;

        for (int j = 0; j < input.Length; j++)
        {
            if (num[i] == input[j])
            {
                if (i == j)
                {
                    Strike++;
                    OutCheck = false;
                }
                else
                {
                    Boll++;
                    OutCheck = false;
                }
            }
        }
        if (OutCheck)
        {
            Out++;
        }
    }

    Console.WriteLine($"스트라이크 : {Strike}, 볼 : {Boll}, 아웃 : {Out}");

    if (Strike ==3)
    {
        game= false;
    }

}

Console.WriteLine("컴퓨터가 생각한 값을 맞추셨습니다.");
Console.WriteLine($"정답은 {num}");





