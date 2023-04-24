Random random = new Random();

List<string> mDeck = new List<string>();            //덱
List<string> mDrawCardList = new List<string>();    //뽑은 카드 리스트들
List<string> mMyHand = new List<string>();          //유저의 카드 정보
List<string> mComputer1 = new List<string>();       //컴퓨터의 카드 정보
List<string> mComputer2 = new List<string>();
List<string> mComputer3 = new List<string>();

Dictionary<string, int> jokbo = new Dictionary<string, int>()   //족보
{
    // 1~10땡
    {"aA" ,101},{"bB" ,102},{"cC" ,103},{"dD" ,104},{"eE" ,105},{"fF" ,106},{"gG" ,107},{"hH" ,108},{"iI" ,109},{"jJ" ,110},
    // 38광땡      13광땡      18광땡
    {"ch" ,201},{"ac" ,202},{"ah" ,203},
    //
};


//덱 생성
void CreateDeck(ref List<string> tDeck)
{
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
}

//카드 비교
void CheckCard(List<string> tCard)
{

}


//덱 생성
CreateDeck(ref mDeck);

//카드 뽑기
DrawCard(ref mDeck, ref mMyHand);
DrawCard(ref mDeck, ref mComputer1);
DrawCard(ref mDeck, ref mComputer2);
DrawCard(ref mDeck, ref mComputer3);

//카드 출력
DisplayMyHand(mMyHand);








