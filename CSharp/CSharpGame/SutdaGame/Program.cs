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

    // 1~10땡
    {"aA" ,201},{"bB" ,202},{"cC" ,203},{"dD" ,204},{"eE" ,205},{"fF" ,206},{"gG" ,207},{"hH" ,208},{"iI" ,209},{"jJ" ,220},

    //암행어사 47
    {"dg", 90},

     // 재경기 94
    //멍텅구리              구사
    {"di" ,50}, {"Di" ,30},{"dI" ,30},{"DI" ,30},

    //땡잡이 37
    {"cg" ,20}, {"Cg" ,20},{"cG" ,20},{"CG" ,20},

    //4등 알리 12
    {"ab" ,106}, {"Ab" ,106},{"aB" ,106},{"AB" ,106},
    //5등 독사 14
    {"ad" ,105}, {"aD" ,105},{"Ad" ,105},{"AD" ,105},
    //6등 구삥 19
    {"ai" ,104}, {"aI" ,104},{"Ai" ,104},{"AI" ,104},
    //7등 장삥 1 10
    {"aj" ,103}, {"aJ" ,103},{"Aj" ,103},{"AJ" ,103},
    //8등 장사 4 10
    {"dj" ,102}, {"dJ" ,102},{"Dj" ,102},{"DJ" ,102},
    //9등 세륙 4 6
    {"df" ,101}, {"dF" ,101},{"Df" ,101},{"DF" ,101},

    //끝계산
    {"a" ,1}, {"b" ,2},{"c" ,3},{"d" ,4},{"e" ,5}, {"f" ,6},{"g" ,7},{"h" ,8},{"i" ,9},{"j" ,10},
    {"A" ,1}, {"B" ,2},{"C" ,3},{"D" ,4},{"E" ,5}, {"F" ,6},{"G" ,7},{"H" ,8},{"I" ,9},{"J" ,10}
};

Dictionary<string, string> mJokbo2 = new Dictionary<string, string>()   //족보
{
    // 18광땡      13광땡      38광땡
    {"ch" ,"1,8광땡"},{"ac" ,"1,3광땡"},{"ah" ,"3,8광땡"},

    // 1~10땡
    {"aA" ,"1,1떙"},{"bB" ,"2,2땡"},{"cC" ,"2,3땡"},{"dD" ,"4,4떙"  },{"eE" ,"5,5땡"},{"fF" ,"6,6땡"},{"gG" ,"7,7땡"},{"hH" ,"8,8땡"},{"iI" ,"9,9땡"},{"jJ" ,"10,10장땡"},

    //암행어사 47
    {"dg", "7,4암행어사"},

     // 재경기 94
    //멍텅구리              구사
    {"id" ,"4,9멍텅구리"}, {"iD" ,"4,9파토"},{"Id" ,"4,9파토"},{"ID" ,"4,9파토"},

    //땡잡이 37
    {"cg" ,"3,7땡잡이"}, {"Cg" ,"3,7땡잡이"},{"cG" ,"3,7땡잡이"},{"CG" ,"3,7땡잡이"},

    //4등 알리 12
    {"ab" ,"1,2알리"}, {"Ab" ,"1,2알리"},{"aB" ,"1,2알리"},{"AB" ,"1,2알리"},
    //5등 독사 14
    {"ad" ,"1,4독사"}, {"aD" ,"1,4독사"},{"Ad" ,"1,4독사"},{"AD" ,"1,4독사"},
    //6등 구삥 19
    {"ai" ,"1,9구삥"}, {"aI" ,"1,9구삥"},{"Ai" ,"1,9구삥"},{"AI" ,"1,9구삥"},
    //7등 장삥 1 10
    {"aj" ,"1,10장삥"}, {"aJ" ,"1,10장삥"},{"Aj" ,"1,10장삥"},{"AJ" ,"1,10장삥"},
    //8등 장사 4 10
    {"dj" ,"4,10장사"}, {"dJ" ,"4,10장사"},{"Dj" ,"4,10장사"},{"DJ" ,"4,10장사"},
    //9등 세륙 4 6
    {"df" ,"46세륙"}, {"dF" ,"46세륙"},{"Df" ,"46세륙"},{"DF" ,"46세륙"},

    
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
    
    string mycard = tHand[0] + tHand[1];
    if (mJokbo2.ContainsKey(mycard))
    {
        Console.Write($"{mJokbo2[mycard]} ");
    }
    

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

    string mycard = tHand[0] + tHand[1];
    if (mJokbo2.ContainsKey(mycard))
    {
        Console.Write($"{mJokbo2[mycard]} ");
    }

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

//특정 족보 있는지 체크
bool CheckNum2(int[] tArray, int tValue)
{
    for (int i = 0; i < tArray.Length; i++)
    {
        if (tArray[i] == tValue)
        {
            
            return true;
        }
    }
    return false;
}

//범위 체크
bool CheckNum3(int[] tArray, int tMinValue, int tMaxValue)
{
    for (int i = 0; i < tArray.Length; i++)
    {
        if (tArray[i] >= tMinValue &&
            tArray[i] <= tMaxValue)
        {
            return true;
        }
    }
    return false;
}


void Batting(int[] tArray)
{
    int tIndex = 0;

    //멍텅구리 체크
    if (CheckNum(tArray, 50,out tIndex))
    {
        //38광땡 18,13광땡 10땡 체크
        if (CheckNum3(tArray, 210,1000))
        {
            //있다면
            tArray[tIndex] = 3;
        }
        else 
        {
            //없다면
            Console.WriteLine("재경기");
            return;
        }
    }
    //파토 체크
    if (CheckNum(tArray,30,out tIndex))
    {
        //1땡 이상 있는지 체크
        if(CheckNum3(tArray,201,1000))
        {
            //있다면
            tArray[tIndex] = 3;
        }
        else
        {
            //없다면
            Console.WriteLine("재경기");
            return;
        }
    }
    //암행어사
    if (CheckNum(tArray,90,out tIndex))
    {
        //광땡 체크
        if (CheckNum2(tArray,500))
        {
            //있다면
            tArray[tIndex] = 501;
        }
        else
        {
            //없다면
            tArray[tIndex] = 1;
        }
    }
    //땡잡이
    if (CheckNum(tArray,20,out tIndex))
    {
        //1~9떙 체크
        if (CheckNum3(tArray,201,209))
        {
            //있다면
            tArray[tIndex] = 210;
        }
        else
        {
            //없다면
            tArray[tIndex] = 0;
        }
    }


    //최종 비교
    for (int i = 0; i < tArray.Length; i++)
    {
        Console.Write($"{tArray[i]} ");
    }
    Console.WriteLine();


    //값들을 리스트에 넣음
    List<int> list = new List<int>();
    for (int i = 0; i < tArray.Length; i++)
    {
        list.Add(tArray[i]);
    }
    //정렬
    list.Sort();
    //최고값
    int tt = list[list.Count - 1];
    //최고값을 가진 플레이어 찾기
    int tPlayer = 0;
    for (int i = 0; i < tArray.Length; i++)
    {
        if (tArray[i] == tt)
        {
            tPlayer = i;
            break;
        }
    }

    if (tPlayer == 0)
    {
        Console.WriteLine("당신이 이겼습니다");
    }
    else
    {
        Console.WriteLine($"{tPlayer}컴퓨터가 이겼습니다.");
    }
}


//=======================================================

while (true)
{
    Console.Clear();


    SettingTable(ref mDeck, ref mArray);    //덱 생성

    //본인
    DrawCard(ref mDeck, ref mMyHand);       //카드 뽑기
    //mMyHand[0] = "d";
    //mMyHand[1] = "g";
    DisplayMyHand(mMyHand);                 //뽑은 카드 출력
    CheckJokbo(mMyHand,0);                  //족보 확인

    //컴퓨터1
    DrawCard(ref mDeck, ref mComputer1);
    //mComputer1[0] = "a";
    //mComputer1[1] = "h";
    DisplayCPUHand(mComputer1);
    CheckJokbo(mComputer1,1);

    //컴퓨터2
    DrawCard(ref mDeck, ref mComputer2);
    DisplayCPUHand(mComputer2);
    CheckJokbo(mComputer2,2);

    //컴퓨터3
    DrawCard(ref mDeck, ref mComputer3);
    DisplayCPUHand(mComputer3);
    CheckJokbo(mComputer3,3);


    Batting(mArray);                        //최종 비교



    Console.ReadLine();
}










