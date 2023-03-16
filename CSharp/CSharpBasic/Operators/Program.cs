﻿
// = : 대입연산자
// right값을 left에 대입하는 연산자
// R-Value : 값을 참조하기 위한 (읽기위한) 값
// L-Value : 값을 대입하기 위한 (쓰기위한) 값

int a = 14;
int b = 6;
int c = 0;

// 산술 연산자
// 더하기, 빼기, 곱하기, 나누기, 나머지
//========================================================

//더하기
c = a + b;
Console.WriteLine(c);

//빼기
c = a - b;
Console.WriteLine(c);

//곱하기
c = a * b;
Console.WriteLine(c);

// 나누기
// 정수나눗셈을 했을때는 몫만 반환
c = a / b;
Console.WriteLine(c);

//나머지
//실수나머지를 했을때는 정수나머지연산 결과 반환
c = a % b;
Console.WriteLine(c);

//증감 연산자
//증가, 감소
//=========================================================
c = 0;
//증가 연산
//++c;    //피연산자를 1 증가시키고 해당 피연산자 그대로 반환.  C = C + 1
Console.WriteLine(++c); //전위 연산
//c++;    //임시 변수를 만들고 피연산자 값을 기억한다음 피연산자 값을 1 증가시키고 임시변수값을 반환
Console.WriteLine(c++); //후위 연산
Console.WriteLine(c);

//감소 연산
c--;
--c;

//관계 연산
// 같음, 다름, 크기 비교연산
// 연산결과가 참일경우 true, 거짓일경우 false를 반환함
//=========================================================

//같음
Console.WriteLine( a == b);

//다름
Console.WriteLine(a != b);

//큼
Console.WriteLine(a > b);

//크거나 같음
Console.WriteLine(a >= b);

//작음
Console.WriteLine(a < b);

//작거나 같음
Console.WriteLine(a <= b);

//복합 대입 연산자
// 더해서, 빼서, 곱해서 , 나누어서, 나머지 연산후 대입하는 연산
//=========================================================

c = 20;
c += b; // c = c + b;
c -= b;
c *= b;
c /= b;
c %= b;

