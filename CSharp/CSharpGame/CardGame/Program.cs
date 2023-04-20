

using System.Diagnostics;
using System.Runtime.CompilerServices;

Random random = new Random();

List<string> dec = new List<string>();
List<string> mycard = new List<string>();
List<int> mycard_onlynum = new List<int>();
List<char> mycard_onlychar = new List<char>();

bool game = true;

static void CreateDec(ref List<string> tDec)
{
    tDec.Clear();
    tDec = new List<string>()
          {
              //A(6) 7,8,9,10,J(11),Q(12),K(13)
              //클로버(c),다이아(d),하트(h),스페이드(s)
              "06c", "07c", "08c", "09c", "10c", "11c", "12c", "13c",
              "06d", "07d", "08d", "09d", "10d", "11d", "12d", "13d",
              "06h", "07h", "08h", "09h", "10h", "11h", "12h", "13h",
              "06s", "07s", "08s", "09s", "10s", "11s", "12s", "13s"
          };
}

static void DisplayMyCard(List<string> mycard)
{
    for (int j = 0; j < mycard.Count; j++)
    {
        Console.Write(mycard[j].ToString() + "  ");
    }
    Console.WriteLine();
}

static void DrawCard(Random random, List<string> dec, List<string> mycard)
{
    //덱에서 카드 5장 뽑기
    mycard.Clear();
    for (int i = 0; i < 5; i++)
    {
        int rnum = random.Next(dec.Count());
        mycard.Add(dec[rnum]);
        dec.RemoveAt(rnum);
    }

    DisplayMyCard(mycard);
}

static void ChangeMyCard(Random random, List<string> dec, List<string> mycard)
{
    Console.WriteLine("카드를 교환하시겠습니까? : Y / N");
    string? input = Console.ReadLine();
    //지정된 번호의 카드를 교환
    if (input == "Y" || input == "y")
    {
        Console.WriteLine("몇번째 카드들을 교환하시겠습니까? : ex)12345 ");
        input = Console.ReadLine();
        if (input != null)
        {
            for (int i = 0; i < input.Length; i++)
            {
                int num = Convert.ToInt32(input[i]) - 48;
                int rnum = random.Next(dec.Count());
                mycard[num - 1] = dec[rnum];
                dec.RemoveAt(rnum);
            }
        }
    }

    DisplayMyCard(mycard);
}

static void CardInfoSort(List<string> mycard, List<int> mycard_onlynum, List<char> mycard_onlychar)
{
    //카드의 숫자를 담음
    for (int i = 0; i < mycard.Count; i++)
    {
        mycard_onlynum.Add(Convert.ToInt32(mycard[i].Substring(0, 2)));
    }
    //정렬
    mycard_onlynum.Sort();

    //카드의 문자를 담음
    for (int i = 0; i < mycard.Count; i++)
    {
        mycard_onlychar.Add(Convert.ToChar(mycard[i].Substring(2, 1)));
    }
    //정렬
    mycard_onlychar.Sort();
}

static void CheckMyCard(List<string> mycard, List<int> mycard_onlynum, List<char> mycard_onlychar)
{
    //플러시
    if (mycard_onlychar[0] == mycard_onlychar[4])
    {
        Console.WriteLine("플러시");
    }

    //스트레이트
    int strateCount = 0;
    for (int i = 0; i < mycard.Count - 1; i++)
    {
        if (mycard_onlynum[i] + 1 == mycard_onlynum[i + 1])
        {
            strateCount++;
            if (strateCount == 4)
            {
                Console.WriteLine("스트레이트");
            }
        }
        else
        {
            break;
        }
    }

    //원,투,트리플,풀하우스,포카드
    int count = 0;
    for (int i = 0; i < mycard.Count - 1; i++)
    {
        for (int j = i + 1; j < mycard.Count; j++)
        {
            if (mycard_onlynum[i] == mycard_onlynum[j])
            {
                count++;
            }
        }
    }

    switch (count)
    {
        case 1:
            Console.WriteLine("원페어");
            break;
        case 2:
            Console.WriteLine("투페어");
            break;
        case 3:
            Console.WriteLine("트리플");
            break;
        case 4:
            Console.WriteLine("풀하우스");
            break;
        case 6:
            Console.WriteLine("포카드");
            break;
    }
}




while (game)
{
    Console.Clear();
    Console.WriteLine("카드를 뽑겠습니까? Y / N");
    string input = Console.ReadLine();
    if (input == "Y" || input == "y")
    { }
    else
    {
        break;
    }
            

    //덱 구축
    CreateDec(ref dec);

    //카드 5장 뽑기
    DrawCard(random, dec, mycard);
    //mycard.Add("06s");
    //mycard.Add("07e");
    //mycard.Add("08a");
    //mycard.Add("09s");
    //mycard.Add("10d");

    //카드 교환
    ChangeMyCard(random, dec, mycard);

    //카드정보정렬
    CardInfoSort(mycard, mycard_onlynum, mycard_onlychar);

    //비교
    CheckMyCard(mycard, mycard_onlynum, mycard_onlychar);


    Console.WriteLine("계속하시겠습니까? Y/N");
    input = Console.ReadLine();
    if (input == "Y" || input == "y")
    { }
    else
    {
        break;
    }
}





