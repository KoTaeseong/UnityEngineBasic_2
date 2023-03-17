
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
Console.WriteLine("=======산술 연산자========");

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
Console.WriteLine("=======증감 연산자========");

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
Console.WriteLine("=======관계 연산========");

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

// 논리 연산자
// 논리형의 피연산자들을 대상으로 연산을 수행
// or, and, xor, not
// 논리연산자는 A와 B 둘다 읽어 데이터 낭비가 될 수 있다.
//=========================================================
Console.WriteLine("=======논리연산========");

bool A = true;
bool B = false;

//or 
// A 와 B 둘중 하나라도 ture이면 ture반환, 나머지 경우 false 반환
// A가 ture여도 B까지 읽고 반환
Console.WriteLine( A | B);

//and
// A 와 B 둘다 ture이면 ture반환, 나머지 경우 false 반환
// A가 false여도 B까지 읽고 반환
Console.WriteLine( A & B);

//xor
// A 와 B 둘중 하나만 ture이면 ture반환, 나머지 경우 false 반환
Console.WriteLine( A ^ B);

//not
// 피연산자가 ture면 false, false면 ture반환
Console.WriteLine(!A);

//조건부 논리연산자
// Conditional or, Conditional and
//=========================================================
Console.WriteLine("=======조건부 논리연산자========");

// Conditional or
// A가 true일 경우 B를 읽지 않고 ture를 반환
Console.WriteLine(A || B);

// Conditional and
// A가 false일 경우 B를 읽지 않고 false를 반환
Console.WriteLine(A && B);

//비트 연산자
// 정수형에 대해서만 연산을 수행한다
//=========================================================
Console.WriteLine("=======비트 연산자========");

// or
Console.WriteLine( a | b);
// a == 14 == 2^3 + 2^2 + 2^1 == ...0000 1110
// b ==  6 ==       2^2 + 2^1 == ...0000 0110
// result                     == ...0000 1110 == 14         

// and
Console.WriteLine(a & b);
// a == 14 == 2^3 + 2^2 + 2^1 == ...0000 1110
// b ==  6 ==       2^2 + 2^1 == ...0000 0110
// result                     == ...0000 0110 == 6        

// xor
Console.WriteLine(a ^ b);
// a == 14 == 2^3 + 2^2 + 2^1 == ...0000 1110
// b ==  6 ==       2^2 + 2^1 == ...0000 0110
// result                     == ...0000 1000 == 8         

// not
Console.WriteLine(~a);
// a == 14 == 2^3 + 2^2 + 2^1 == 0000 0000  0000 0000  0000 0000  0000 1110
// result                     == 1111 1111  1111 1111  1111 1111  1111 0001
// 2의 보수                   == 1111 1111  1111 1111  1111 1111  1111 0010 == -14
// 2의 보수의 2의 보수        == 0000 0000  0000 0000  0000 0000  0000 1110

// 2의 보수 : 이진법에서 모든 자릿수를 반전하고 + 1
Console.WriteLine(a);
Console.WriteLine(-a); // -a == ~a + 1

// shift - left
Console.WriteLine(a << 1);
// a == 14 == 2^3 + 2^2 + 2^1 == 0000 0000  0000 0000  0000 0000  0000 1110
// result                     == 0000 0000  0000 0000  0000 0000  0001 1100 == 28

// shift - right
Console.WriteLine(a >> 2);
// a == 14 == 2^3 + 2^2 + 2^1 == 0000 0000  0000 0000  0000 0000  0000 1110
// result                     == 0000 0000  0000 0000  0000 0000  0000 0011 == 3
