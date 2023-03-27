// 진행 방식
//
// 말 클래스 필요
// 말 클래스는 달린거리, 이동하기(달리기) 라는 함수를 가진다
//
// 프로그램 시작시
// 말 다섯마리를 만들고
// 각 말의 이름은 "경주마i" (i = 1~5) 로 한다
// 각 말은 초당 10.0f ~ 20.0f의 범위의 거리를 랜덤하게 전진
// 각각의 말은 200.0f 거리에 도달하면 도착으로 간주하고 더이상 전진하지 않고,
// 매 초마다 모든 말들의 상태 ( 도착했다면 "도착함", 달리고 있다면 현재 달린 누적 거리)를 출력 한다
// 모든 말들이 도착했으면 경주를 끝내고 등수 순서대로 말들의 이름을 콘솔창에 출력 한다

using System;
using System.Runtime.InteropServices;
using System.Threading;

using HorseRacing;

Random _random;
double _minSpeed = 10.0f;
double _maxSpeed = 20.0f;
double _posGoal = 200.0f;
int _rank = 1;
bool _isGameFinished = false;
Horse[] horses = new Horse[5];
Horse[] _finishedHorse = new Horse[5];

_random = new Random();

//경주마 생성
for (int i = 0; i < 5; i++)
{
    horses[i] = new Horse($"경주마{i+1}", false, 0.0f);
}


while (_isGameFinished == false)
{
    
    for (int i = 0; i < horses.Length; i++)
    {
        double deltaMovePerSec = (_random.NextDouble() + 1.0) * 10.0;
        horses[i].Move(deltaMovePerSec);

        if (horses[i].Rank == 0)
        {
            if (horses[i].IsFinished == true)
            {
                horses[i].Rank = _rank;
                _finishedHorse[_rank] = horses[i];
                _rank++;
            }
        }

        Console.WriteLine($"{horses[i].Name}의 주행거리 : {(int)horses[i].TotalDistance} 도착여부 : {horses[i].IsFinished} 등수 : {horses[i].Rank}");
    }
    Console.WriteLine();

    if (horses[0].IsFinished &
        horses[1].IsFinished &
        horses[2].IsFinished &
        horses[3].IsFinished &
        horses[4].IsFinished )
    {
        _isGameFinished = true;
    }

    Thread.Sleep(1000);
}

for (int i = 0; i < _finishedHorse.Length; i++)
{
    Console.WriteLine($"{i+1}등 {_finishedHorse[i]}");
}


