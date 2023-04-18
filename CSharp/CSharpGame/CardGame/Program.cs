

Random random = new Random();

//A(6) 7,8,9,10,J(11),Q(12),K(13)
//클로버(c),다이아(d),하트(h),스페이드(s)
//String[] dec = { "06c", "07c", "08c", "09c", "10c", "11c", "12c", "13c" ,
//                 "06d", "07d", "08d", "09d", "10d", "11d", "12d", "13d" ,
//                 "06h", "07h", "08h", "09h", "10h", "11h", "12h", "13h" ,
//                 "06s", "07s", "08s", "09s", "10s", "11s", "12s", "13s" };
List<string> dec = new List<string>() 
{
    //A(6) 7,8,9,10,J(11),Q(12),K(13)
    //클로버(c),다이아(d),하트(h),스페이드(s)
    "06c", "07c", "08c", "09c", "10c", "11c", "12c", "13c",
    "06d", "07d", "08d", "09d", "10d", "11d", "12d", "13d",
    "06h", "07h", "08h", "09h", "10h", "11h", "12h", "13h",
    "06s", "07s", "08s", "09s", "10s", "11s", "12s", "13s"
};

List<string> mycard = new List<string>();

//덱에서 카드 5장 뽑기
mycard.Clear();
for (int i = 0; i < 5; i++)
{
    int num = random.Next(dec.Count());
    mycard.Add(dec[num]);
    dec.RemoveAt(num);
}


//뽑은 카드 5장을 출력
for (int j = 0; j < mycard.Count; j++)
{
    Console.Write(mycard[j].ToString() + "  ");
}


