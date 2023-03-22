// using 키워드
// namespace 를 가져다 쓰기위함
using ClassObjectInstance;
using Variables;

//new 키워드
//동적할당키워드

SwordMan swordMan1 = new SwordMan();
SwordMan swordMan2 = new SwordMan();
int a = 3;

// . 멤버접근연산자
swordMan1.Name = "타락파워전사";
swordMan1.Lv = 1;

swordMan2.Name = "똠양꿍 ";
swordMan2.Lv = 2;

swordMan1.Slash();
swordMan2.Slash();

ClassObjectInstance.SwordMan sw1 = new ClassObjectInstance.SwordMan();
ClassObjectInstance.UISystems.Characters.SwordMan nw2 = new ClassObjectInstance.UISystems.Characters.SwordMan();


/*
CMan human1 = new CMan();
CMan human2 = new CMan();
CMan human3 = new CMan();

human1.Name = "김아무개";
human1.Age = 216;
human1.Height = 123.1f;
human1.Weight = 300.0f;
human1.Use = false;
human1.Display();

human2.Name = "이아무개";
human2.Age = 39;
human2.Height = 323.0f;
human2.Weight = 232.2f;
human2.Use = true;
human2.Display();

human3.Name = "최아무개";
human3.Age = 142;
human3.Height = 53.1f;
human3.Weight = 144.4f;
human3.Use = true;
human3.Display();
*/

CMan human1 = new CMan("김아무개", 216, 123.1f, 300.0f, false);
CMan human2 = new CMan("이아무개", 39, 323.0f, 232.0f, true);
CMan human3 = new CMan("최아무개", 142, 53.1f, 144.4f, true);

Console.WriteLine("\n");

human1.PrintInfo();
human2.PrintInfo();
human3.PrintInfo();