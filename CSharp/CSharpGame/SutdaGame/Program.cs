Random random = new Random();

List<string> mDeck = new List<string>();            //덱
//List<string> mDrawCardList = new List<string>();    //뽑은 카드 리스트들
List<string> mMyHand = new List<string>();          //유저의 카드 정보
List<string> mComputer1 = new List<string>();       //컴퓨터의 카드 정보
List<string> mComputer2 = new List<string>();
List<string> mComputer3 = new List<string>();

int[] mArray = new int[4] // 0:플레어 1: cpu1 2: cpu2 3: cpu3
{
    0,0,0,0,
};

Dictionary<string, int> mJokbo = new Dictionary<string, int>()   //족보
{
    // 18광땡      13광땡      38광땡
    {"ch" ,500},{"ac" ,500},{"ah" ,1000},

    //암행어사 47
    {"dg", 90},

     // 재경기 94
    //멍텅구리              구사
    {"id" ,50}, {"iD" ,30},{"Id" ,30},{"ID" ,30},

    // 1~10땡
    {"aA" ,201},{"bB" ,202},{"cC" ,203},{"dD" ,204},{"eE" ,205},{"fF" ,206},{"gG" ,207},{"hH" ,208},{"iI" ,209},{"jJ" ,210},

    //땡잡이 37
    {"cg" ,20}, {"Cg" ,20},{"cG" ,20},{"CG" ,20},

    //4등 알리 12
    {"ab" ,106}, {"Ab" ,106},{"aB" ,106},{"AB" ,106},
    //5등 독사 14
    {"ad" ,105}, {"aD" ,105},{"Ad" ,105},{"AD" ,105},
    //6등 구삥 19
    {"ai" ,104}, {"aI" ,104},{"Ai" ,104},{"AI" ,104},
    //7등 장삥 1 10
    {"aj" ,103}, {"aJ" ,103},{"Aj" ,1003},{"AJ" ,103},
    //8등 장사 4 10
    {"dj" ,102}, {"dJ" ,102},{"Dj" ,102},{"DJ" ,102},
    //9등 세륙 4 6
    {"df" ,101}, {"dF" ,101},{"Df" ,101},{"DF" ,101},

    //끝계산
    {"a" ,1}, {"b" ,2},{"c" ,3},{"d" ,4},{"e" ,5}, {"f" ,6},{"g" ,7},{"h" ,8},{"i" ,9},{"j" ,10},
    {"A" ,1}, {"B" ,2},{"C" ,3},{"D" ,4},{"E" ,5}, {"F" ,6},{"G" ,7},{"H" ,8},{"I" ,9},{"J" ,10}
};


//덱 생성
void SettingTable(ref List<string> tDeck, ref int[] tValues)
{
    //초기화
    tDeck.Clear();

    for (int i = 0; i < tValues.Length; i++)
    {
        tValues[i] = 0;
    }

    //생성
    tDeck = new List<string>()
            {
                "a","A",    //1
                "b","B",    //2
                "c","C",    //3
                "d","D",    //4
                "e","E",    //5
                "f","F",    //6
                "g","G",    //7
                "h","H",    //8
                "i","I",    //9
                "j","J"    //10
            };
}

//카드 뽑기
void DrawCard(ref List<string> tDeck,ref List<string> tHand)
{
    //초기화
    tHand.Clear();

    //뽑기
    for (int i = 0; i < 2; i++)
    {
        int tIndex = random.Next(tDeck.Count);
        tHand.Add(tDeck[tIndex]);
        tDeck.RemoveAt(tIndex);
    }
    tHand.Sort();
}


//카드 출력
void DisplayMyHand(List<string> tHand)
{
    Console.Write("나의 패 : ");
    foreach (var item in tHand)
    {
        Console.Write(item + " ");
    }
    Console.Write(" ( ");
    foreach (var item in tHand)
    {
        Console.Write(mJokbo[item] + " ");
    }
    Console.Write(" ) ");
    Console.WriteLine();
}
void DisplayCPUHand(List<string> tHand)
{
    Console.Write("컴퓨터의 패 : ");
    foreach (var item in tHand)
    {
        Console.Write(item + " ");
    }
    Console.Write(" ( ");
    foreach (var item in tHand)
    {
        Console.Write(mJokbo[item] + " ");
    }
    Console.Write(" ) ");
    Console.WriteLine();
}


//카드 비교
void CheckJokbo(List<string> tCard, int tPlayer)
{
    //재정렬
    tCard.Sort();

    string tCheck = tCard[0]+tCard[1];
    int tJokbo = 0;

    //만약 족보에 있다면
    if (mJokbo.ContainsKey(tCheck))
    {
        //값을 넣음
        tJokbo = mJokbo[tCheck];
        Console.WriteLine(tJokbo.ToString());
        mArray[tPlayer] = tJokbo;
        
    }
    else //없다면
    {
        //끗 계산
        CheckJokbo2(tCard, tPlayer);
    }
}

//끗 계산
void CheckJokbo2(List<string> tCard, int tPlayer)
{
    int tJokbo = 0;

    //끗 계산
    tJokbo = mJokbo[tCard[0]] + mJokbo[tCard[1]];

    if (tJokbo >= 10)
    {
        tJokbo = Math.Abs(tJokbo - 10);
    }

    Console.WriteLine(tJokbo);
    mArray[tPlayer] = tJokbo;
}

bool CheckNum(int[] tArray, int tValue , out int tIndex)
{
    for (int i = 0; i < tArray.Length; i++)
    {
        if (tArray[i] == tValue)
        {
            tIndex = i;
            return true;
        }
    }
    tIndex = -1;
    return false;
}


void Batting(int[] tArray)
{
    int tIndex = 0;

    //멍텅구리 체크
    if (CheckNum(tArray, 50,out tIndex))
    {
        //38광땡 체크
        if (!CheckNum(tArray, 100,out tIndex))
        {
            //없다면
            Console.WriteLine("재경기");
        }
        else 
        {
            //있다면
            tArray[tIndex] = 3;
        }
    }
    

}


//=======================================================

while (true)
{
    Console.Clear();


    //덱 생성
    SettingTable(ref mDeck, ref mArray);

    //카드 뽑고 확인
    DrawCard(ref mDeck, ref mMyHand);
    DisplayMyHand(mMyHand);
    CheckJokbo(mMyHand,0);

    DrawCard(ref mDeck, ref mComputer1);
    DisplayCPUHand(mComputer1);
    CheckJokbo(mComputer1,1);

    DrawCard(ref mDeck, ref mComputer2);
    DisplayCPUHand(mComputer2);
    CheckJokbo(mComputer2,2);

    DrawCard(ref mDeck, ref mComputer3);
    DisplayCPUHand(mComputer3);
    CheckJokbo(mComputer3,3);

    


    Console.ReadLine();
}










