/*
    abstract class
    추상 클래스, 해당 클래스는 추상을 위한 용도로 정의된 클래스이므로 객체화가 안된다. 

    protected : 이 클래스를 상속받는 하위 클래스(자식클래스) 만 접근 가능한 제한자.
    abstract : 함수 앞에 붙으면 이 함수를 맴버로 가지는 클래스를
    상속받은 자식클래스타입에서 이 함수의 구현부를 정의하도록 하는 키워드

    interface는 default접근제한자가 public이다
    프로퍼티, 함수, 이벤트 멤버들을 추상화하기위한 용도이므로 기본적으로 멤버들 선언만함

    함수(생성자) 오버로딩
    함수 오버로딩 : 동일한 이름이지만, 파라미터의 종류가 다른 함수를 정의하는 기능

    지역변수는 상위에 선언된 동일한 이름의 모든 변수를 가린다

    virtual 키워드 : 가상키워드
    함수를 구현하고 해당 함수를 하위타입에서 재정의 할 수 있도록 허용함

    override 키워드 : 재정의 키워드
    추상멤버를 다시 정의하고 싶을 때 쓰는 키워드

    base 키워드 : 상위타입 참조
 
*/


using Inheritance;
using System.Security.Cryptography;

Knight knight = new Knight(200, 50);
Goblin goblin = new Goblin(100, 20);
Wizard wizard = new Wizard(150, 100);


//공변성 (Covariance)
//하위타입을 기반타입으로 참조가 가능한 성질
Creature[] creatures = new Creature[3];
creatures[0] = knight;
creatures[1] = goblin;
creatures[2] = wizard;

for (int i = 0; i < creatures.Length; i++)
{
    Console.WriteLine(creatures[i].Lv);
}

knight.Attack(goblin);

knight.SayHi();
wizard.SayHi();

Character character1 = knight;
Character character2 = wizard;
character1.SayHi();
character2.SayHi();






