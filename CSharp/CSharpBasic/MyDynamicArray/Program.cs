using Collections;
using System.Collections;   //오프젝트 타입 콜렉션
using System.Collections.Generic;   //제너릭 타입 콜렉션
using System.Globalization;

//yield
//IEnumerator / IEnumerable 로 반복기를 구현할때 MoveNext()에 해당하는 기능을 구현해줄때 사용
IEnumerator MakeToastWorkflow()
{
    Console.WriteLine("토스트만들기() : 1. 인덕션을 켠다");
    yield return null;
    Console.WriteLine("토스트만들기() : 2. 인덕션에 팬을 올린다");
    yield return null;
    Console.WriteLine("토스트만들기() : 3. 팬에 버터를 두른다");
    yield return null;
    Console.WriteLine("토스트만들기() : 4. 팬에 식빵을 올린다");
}

IEnumerator<string> MakeToastWorkflow2()
{
    yield return "토스트만들기() : 1. 인덕션을 켠다";
    yield return "토스트만들기() : 2. 인덕션에 팬을 올린다";
    yield return "토스트만들기() : 3. 팬에 버터를 두른다";
    yield return "토스트만들기() : 4. 팬에 식빵을 올린다";
}

IEnumerable<int> WorkflowSample()
{
    yield return 1;
    yield return 2;
    yield return 3;
    yield return 4;
}

bool Match(int x)
{
    return x > 4;
}
#region Dynamic Array
MyDynamicArray myDynamicArray = new MyDynamicArray();
myDynamicArray.Add(5);
myDynamicArray.Add(3);
myDynamicArray.Add(9);
myDynamicArray.Add(7);
int tmpIndex = myDynamicArray.FindIndex(7);

if (myDynamicArray.Remove(tmpIndex))
{
    Console.WriteLine($"{tmpIndex} of myDynamicArray has removed");
}
//myDynamicArray.RemoveAt(tmpIndex);
for (int i = 0; i < myDynamicArray.Count; i++)
{
    Console.WriteLine(myDynamicArray[i]);
}

int tmpValue = (int)myDynamicArray.Find(x => (int)x > 4);
//tmpValue = myDynamicArray.Find(Match);

//object : C# 모든 타입에 기반이 되는 타입
object obj = (object)1; // boxing : (object 타입 변환, 힙 영역에 object 타입 객체를 만들고 값을 할당)
obj = "안녕";
obj = 'a';
tmpValue = (char)obj; // unboxing : (object) 객체의 데이터를 내가 원하는 자료형으로 형변환 하는것)
Object obj2 = (Object)1;

//generic타입은 박싱 언박싱의 단점을 보완하기 위해 나왔다 /C#에서 권장함
MyDynamicArray<Dummy> dummies = new MyDynamicArray<Dummy>();
MyDynamicArray<float> floats = new MyDynamicArray<float>();

floats.Add(3.2f);
floats.Add(2.5f);
floats.Add(7.3f);
floats.Add(2.1f);

//using 구문 : IDisposable 객체의 Dispose() 호출을 보장하는 구문.
using (IEnumerator<float> enumerator = floats.GetEnumerator())
using (IEnumerator<Dummy> enumerator2 = dummies.GetEnumerator())
{
    while (enumerator.MoveNext())
    {
        Console.WriteLine(enumerator.Current);
    }
    enumerator.Reset();
}

foreach (float item in floats)
{
    Console.WriteLine(item);
}
//for문은 자료에 직접 조작이 가능하지만 foreach문은 불가능하다

IEnumerator toastEnumerator = MakeToastWorkflow();
while (toastEnumerator.MoveNext()) { }
IEnumerator toastEnumerator2 = MakeToastWorkflow2();
while (toastEnumerator2.MoveNext())
{
    Console.WriteLine( toastEnumerator2.Current);
}
IEnumerable<int> eSample = WorkflowSample();
foreach (var item in eSample)
{
    Console.WriteLine(item);
}


ArrayList arrayList = new ArrayList();
arrayList.Add(3);
arrayList.Add("철수");
arrayList.Contains(3);

List<Dummy> list = new List<Dummy>();
list.Add(new Dummy());
list.Find(dummy => dummy.x < 0);


#endregion

#region Linked List
MyLinkedListOfT<int> myLinkedList = new MyLinkedListOfT<int>();
myLinkedList.AddFirst(1);
myLinkedList.AddFirst(5);
Node<int> node = myLinkedList.Find(1);
myLinkedList.AddAfter(node, 2);

foreach (var item in myLinkedList)
{
    Console.WriteLine($"linked list item : {item}");
}

#endregion\

#region Dictionary

MyDictionaryOfT<string, int> myDictionary = new MyDictionaryOfT<string, int>();

myDictionary.Add("Luke", 80);
myDictionary.Add("Jason", 40);
myDictionary.Add("Bernd", 70);

if (myDictionary.TryGetValue("Luke",out int value))
{
    Console.WriteLine($"Luke score : {value}");
}

Console.WriteLine(myDictionary["Rachel"]);
//Console.WriteLine(myDictionary["Karl"]);

#endregion

#region HashSet

HashSet<int> numbers = new HashSet<int>();
if (numbers.Add(1))
{
    Console.WriteLine("Added 1");
}
if (numbers.Add(1))
{
    Console.WriteLine("Added 1");
}

#endregion

#region Queue

//선입선출 (First - In, First - Out : FIFO)
Queue<int> queue = new Queue<int>();
queue.Enqueue(1);
int first = queue.Dequeue();
if (queue.Count > 0)
{
    Console.WriteLine(queue.Peek());
}

#endregion

#region Stack

//후입선출(Last - In, First - Out : LIFO)
Stack<int> stack = new Stack<int>();
stack.Push(first);
if (stack.Count >0)
{
    Console.WriteLine(queue.Peek());
    stack.Pop();
}

#endregion

class Dummy : IComparable<Dummy>
{
    public int x, y, z;

    public int CompareTo(Dummy? other)
    {
        //삼항 연산자
        // 어떤조건 ? 조건이 참일때 값 : 조건이 거짓일때 값
        return other != null && x == other.x && y == other.y && z == other.z ? 0 : -1;

        //if (other == null)
        //    return -1;
        //if (x == other.x &&
        //    y == other.y &&
        //    z == other.z)
        //    return 0;
        //else
        //    return 1;
    }
}
