
/*
    <변수>

    변수 선언 
        자료형 변수이름;
    변수를 선언한다는 것 : 메모리상에 자료형 크기만큼의 공간을 할당함.
    변수의 초기화 : 변수 선언 시 대입연산자로 초기화 할 값을 대입해줌.
*/

int a = 8;              // 4byte 부호가 있는 정수형
short short1 = 1332;    // 2byte 부호가 있는 정수형
long long1 = 1321;      // 8byte 부호가 있는 정수형
float hight = 22.4f;    // 4byte 실수형
double weight = 42.1f;  // 8byte 실수형

// 자료형 앞에 'u'를 붙이면 부호를 없앤다
uint uint1 = 1;         // 4byte 부호가 없는 정수형

char gender = 'A';      // 2byte 문자형 (아스키코드표에 따라 정수형으로 계산함).  65 = 2^6 * 1 + 2^0 * 1
string name = "Luke";   // 문자열형, 문자 하나당 2byte + 마지막에 null 문자
