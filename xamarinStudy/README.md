# C#
- 마이크로소프트에서 개발한 닷넷(.NET) 프레임워크 기반 범용 목적의 다중 패러다임 프로그래밍 언어

## 닷넷 프레임워크(.NET Framework)
- 웹앱, 모바일 앱, 게임 등을 만들기 위한 오픈소스, 크로스 플랫폼 개발 환경
<img width="471" alt="image" src="https://github.com/uengmim/Xamarin-Study/assets/72143238/744440b8-0f4d-4894-8990-fca1a8672239">

### 범용 프로그래밍 언어
- 다양한 도메인의 소프트웨어를 개발하기 위해 설계된 프로그래밍 언어
- ex) C, C++, java, python, visual basic, kotlin, swift

### 다중 패러다임 언어
- 하나 이상의 프로그래밍 스타일을 지원하는 프로그래밍 언어

#### 명령형(Imperative)
1. 절차적 프로그래밍 언어 - 시간의 흐름에 따라 코드를 작성하는 프로그래밍 스타일 (ex C, 포트란, 베이직)
2. 객체 지향 프로그래밍 언어 - 모든 사물을 객체로 표현, 객체의 속성과 메소드의 호출로 프로그램을 작성함 (ex C++, Java, C#)

#### 선언형(Declarative)
1. 함수형 프로그래밍 언어
2. 논리형 프로그래밍 언어
3. 데이터 흐름형 프로그래밍 언어


## C# 데이터 타입
 - C#을 포함한 모든 닷넷 프로그래밍언어는 닷넷의 Common Type System에 정의된 .NET 데이터 타입을 사용
<img width="389" alt="image" src="https://github.com/uengmim/Xamarin-Study/assets/72143238/a3204d04-d72e-4adb-afa6-69712b5c8ba2">

### 리터럴 데이터
- C# 코드에서 123,true,"ABC"와 같이 값을 직접 써줄 수 있다. 이것을 리터럴이라고 한다. 별도의 접미어 표시가 없으면 C# 컴파일러는 기본적으로 데이터 타입 값을 할당한다.
- 만약 특정 데이터 타입을 지정하고 싶으면 리터럴 데이터 뒤에 1~2자의 타입 지정 접미어를 추가해야한다.
```C#
123    // int 리터럴
12.3   // double 리터럴
"A"    // string 리터럴
'a'    // char 리터럴
true   // bool 리터럴
```
### 접미어(Suffix) 데이터 타입
<img width="318" alt="image" src="https://github.com/uengmim/Xamarin-Study/assets/72143238/5ec3da6c-399a-41a0-85ba-e484d6601f83">

```C#
// Bool
bool b = true;

// Numeric
short sh = -32768;   
int i = 2147483647;  
long l = 1234L;      // L suffix
float f = 123.45F;   // F suffix
double d1 = 123.45; 
double d2 = 123.45D; // D suffix
decimal d = 123.45M; // M suffix

// Char/String
char c = 'A';
string s = "Hello";

// DateTime  2011-10-30 12:35
DateTime dt = new DateTime(2011, 10, 30, 12, 35, 0);
```
* float 데이타 타입은 숫자 뒤에 123.45F와 같이 F를 붙여 double이 아닌 float 타입임을 나타낸다.
* double 데이타 타입은 숫자 뒤에 123.45D과 같이 D를 붙이거나 혹은 아무것도 붙이지 않음으로 해서 double 타입임을 나타낸다.
* decimal 데이타 타입은 숫자 뒤에 123.45M과 같이 M를 붙여 decimal 타입임을 나타낸다.
* char 데이타 타입은 작은따옴표 ' (single quotation)을 사용하여 한 문자를 할당한다.
* string 데이타 타입은 큰따옴표 " (double quotation)을 사용하여 문자열을 할당한다.

### 최댓값 최솟값
- 숫자형 데이터 타입의 최댓값이나 최소값을 알아내가 위해서는 .NET 데이터 타입 클래스들의 MaxValue, MinValue 프로퍼티를 사용한다.
```C#
int i = int.MaxValue;
float f = float.MinValue;
```

### NULL
- 어떤 변수가 어떤 데이터도 가지고 있지 않다는 의미로 사용
- C#에서는 소문자 null로 표현

### Nullable Type
- 정수(int)나 날짜(DateTime)와 같은 Value Type은 일반적으로 NULL을 가질 수 없다. C# 2.0에서부터 이러한 타입들에 NULL을 가질 수 있게 하였는데, 이를 Nullable Type 이라 부른다.
- C#에서 물음표(?)를 int나 DateTime 타입명 뒤에 붙이면 즉, int? 혹은 DateTime? 같이 하면 Nullable Type이 된다. 이는 컴파일하면 .NET의 Nullable<T> 타입으로 변환된다. Nullable Type (예: int?) 을 일반 Value Type (예: int)으로 변경하기 위해서는 Nullable의 .Value 속성을 사용한다.
```C#
// Nullable 타입
int? i = null;
i = 101;
            
bool? b = null;

//int? 를 int로 할당
Nullable<int> j = null;
j = 10;
int k = j.Value;
```
## C# 변수
- C# 변수는 메서드 안에서 해당 메서드 안에서 로컬 변수로 선언되거나 클래스 안에서 클래스 내의 멤버들이 사용하는 전역적 변수(Field)로 선언된다.
- 로컬 변수는 해당 메서드 내에서만 사용되며 메서드 호출이 끝나면 소멸된다.
- 반면 전역적 변수(Field)는 클래스의 객체가 살아있으면 계속 존속하며 다른 메서드에서 필드를 참조할 수 있다.
- 로컬 변수는 사용 전에 값을 할당해야 함(기본값을 할당 X)
- 전역 변수(Field)는 값을 할당하지 않으면 기본값이 자동으로 할당 (ex int일 경우 0 할당)
- 모든 변수는 대소문자 구별
```C#
using System;

namespace ConsoleApplication1
{
    class CSVar
    {
        //필드 (클래스 내에서 공통적으로 사용되는 전역 변수)
        int globalVar;
        const int MAX = 1024;

        public void Method1()
        {
            // 로컬변수
            int localVar;

            // 아래 할당이 없으면 에러 발생
            localVar = 100;

            Console.WriteLine(globalVar);
            Console.WriteLine(localVar);
        }
    }

    class Program
    {
        // 모든 프로그램에는 Main()이 있어야 함.
        static void Main(string[] args)
        {
            // 테스트
            CSVar obj = new CSVar();
            obj.Method1();
        }
    }
}
```
### 상수
- c# 상수는 const를 사용하여 정의
**차이점**
1. 상수와 변수 차이점은 변수는 프로그램 중간에 값을 변경할 수 있지만 상수는 초기에 정한 값을 중간에 변경할 수 없다.
2. const는 필드 선언부에서 사용되거나 메서드 내에서 사용될 수 있으며 컴파일시 상수 값이 결정

### 배열
- 배열은 동일한 데이터 타입 요소들로 구성된 데이타 집합으로 인덱스를 통하여 개개의 배열 요소를 엑세스 가능
- 배열은 첫번째 요소가 인덱스 0
```C#
// 1차 배열
string[] players = new string[10];
string[] Regions = { "서울", "경기", "부산" };
int[] array = new int[5];
//배열 변수를 만들지 않고 선언할 수 있지만 이 변수에 새 배열을 할당할 때는 new 연산자를 사용해야 합니다.
int[] array3;
array3 = new int[] { 1, 3, 5, 7, 9 };   // OK
//array3 = {1, 3, 5, 7, 9};   // Error

// 2차 배열 선언 및 초기화
string[,] Depts = {{"김과장", "경리부"},{"이과장", "총무부"}};
int[,] array = new int[4, 2];

// 3차 배열 선언
int[,,] array1 = new int[4, 2, 3];
string[,,] Cubes;
```

### 가변 배열
- 다차원 배열에서 배열 요소 크기가 동일한 Rectangular 배열은 C#에서 [,] 와 같이 괄호안에 콤마로 분리하여 (C 언어 스타일) 다차원을 표현한다.
- 하지만 각 차원별 배열 요소 크기가 가변적인 가변 배열(Jagged Array)의 경우 [][] 와 같이 각 차원마다 괄호를 별도로 사용한다.
**Jagged Array (가변 1차원 배열)**
```C#
//각각 정수의 1차원 배열인 세 개의 요소를 포함하는 1차원 배열의 선언
int[][] jaggedArray = new int[3][];

//jaggedArray를 사용하려면 먼저 해당 요소를 초기화
jaggedArray[0] = new int[5];
jaggedArray[1] = new int[4];
jaggedArray[2] = new int[2];

//이니셜라이저를 사용하여 배열 요소에 값을 채울 수도 있으며, 이 경우 배열 크기가 필요 없음
jaggedArray[0] = new int[] { 1, 3, 5, 7, 9 };
jaggedArray[1] = new int[] { 0, 2, 4, 6 };
jaggedArray[2] = new int[] { 11, 22 };

//배열을 초기화할 수도 있음
int[][] jaggedArray2 = new int[][]
{
new int[] { 1, 3, 5, 7, 9 },
new int[] { 0, 2, 4, 6 },
new int[] { 11, 22 }
};
```
**Jagged Array (가변 다차원 배열)**
```C#
int[][,] jaggedArray4 = new int[3][,]
{
    new int[,] { {1,3}, {5,7} },
    new int[,] { {0,2}, {4,6}, {8,10} },
    new int[,] { {11,22}, {99,88}, {0,9} }
};
```
### 배열 사용
- 배열 사용 예제
```C#
static void Main(string[] args)
{
    int sum = 0;
    int[] scores = { 80, 78, 60, 90, 100 };
    for (int i = 0; i < scores.Length; i++)
    {
        sum += scores[i];
    }
    Console.WriteLine(sum);        
}
//배열의 전달
static void Main(string[] args)
{            
    int[] scores = { 80, 78, 60, 90, 100 };
    int sum = CalculateSum(scores); // 배열 전달: 배열명 사용
    Console.WriteLine(sum);        
}

static int CalculateSum(int[] scoresArray) // 배열 받는 쪽
{
    int sum = 0;
    for (int i = 0; i < scoresArray.Length; i++)
    {
        sum += scoresArray[i];
    }
    return sum;
}
```
### 배열 foreach 사용
**1차원 배열**
```C#
int[] numbers = { 4, 5, 6, 1, 2, 3, -2, -1, 0 };
foreach (int i in numbers)
{
    System.Console.Write("{0} ", i);
}
// Output: 4 5 6 1 2 3 -2 -1 0
```
**차원 배열**
```C#
int[,] numbers2D = new int[3, 2] { { 9, 99 }, { 3, 33 }, { 5, 55 } };
// Or use the short form:
// int[,] numbers2D = { { 9, 99 }, { 3, 33 }, { 5, 55 } };

foreach (int i in numbers2D)
{
    System.Console.Write("{0} ", i);
}
// Output: 9 99 3 33 5 55
```
## C#문자열
- string은 이중부호, char는 단일부호 사용
- 문자열(string)은 문자(character)의 집합체이다. 문자열 안에 있는 각 문자를 엑세스하고 싶으면, 인덱스를 사용하여 문자 요소를 엑세스

### StringBuilder 클래스
- Mutable 타입인 StringBuilder 클래스는 문자열 갱신이 많은 곳에서 자주 사용되는데 이는 이 클래스가 별도 메모리를 생성,소멸하지 않고 일정한 버퍼를 갖고 문자열 갱신을 효율적으로 처리
- 특히 루프 안에서 계속 문자열을 추가 변경하는 코드에서는 string 대신 StringBuilder를 사용
```C#
using System;
using System.Text;

namespace MySystem
{
   class Program
   {
      static void Main(string[] args)
      {                  
         StringBuilder sb = new StringBuilder();
         for (int i = 1; i <= 26; i++)
         {
            sb.Append(i.ToString());
            sb.Append(System.Environment.NewLine);
         }
         string s = sb.ToString();

         Console.WriteLine(s);
      }
   }
}
```
  
## C# enum (열거형)
- C#의 키워드인 enum은 열거형 상수를 표현하기 위힌 것으로 이를 사용하면 상수 숫자들을 보다 의미있는 단어로 표현 가능
- enum의 각 요소는 별도의 지정 없이 첫번째 요소가 0, 두번째가 1, 세번째가 2와 같이 1씩 증가된 값 할당
```C#
public enum Category
{
   Cake,
   IceCream,
   Bread
}
```
- enum 타입은 숫자형 타입과 호환 가능
- 만약 enum 타입의 변수를 int로 캐스팅하면 해당 enum 값을 얻게 된다.
```C#
class Program
{
    enum City
    {
        Seoul,   // 0
        Daejun,  // 1
        Busan = 5,  // 5
        Jeju = 10   // 10
    }
}
```
### flag enum
- enum의 각 멤버들은 **비트**별로 구분되는 값들(예: 1,2, 4, 8)을 갖을 수 있는데 이렇게 enum 타입이 비트 필드를 갖는다는 것을 표시하기 위해 enum 선언문 위에 [flag]라는 Attribute를 지정

 ## C# 연산자
 - C#은 다른 프로그래밍 언어와 비슷하게 수식 연산자, 논리 연산자, 조건 연산자등 다양한 연산자들을 제공
<img width="392" alt="image" src="https://github.com/uengmim/Xamarin-Study/assets/72143238/c01e2fb4-67a1-454c-a5ad-19c821c601f2">

## 조건문
### switch 조건문
- switch문은 조건값이 여러 값들을 가질 경우 각 case 별 다른 문장들을 실행할 때 사용된다. 각각의 경우에 해당하는 값을 case 문 뒤에 지정하며 어떤 경우에도 속하지 않으면 default 문을 사용하여 지정
- 각 case 문 내에서 break를 사용하면 해당 case 블럭의 문장들을 실행하고 switch 문을 빠져나온다.
```C#
switch (category)
{
   case "사과":
      price = 1000;
      break;
   case "딸기":
      price = 1100;
      break;
   case "포도":
      price = 900;
      break;
   default:
      price = 0;
      break;
}
//category 값이 딸기일 때 return 1100
```
## C# 반복문
### for 반복문
- 루프 안에 있는 문장들을 반복적으로 실행할떄 사용 for 루프는 일반적으로 카운터 변수를 이용해 일정 범위 동안 for 루프 안의 블럭을 실행
```C#
class Program
{
    static void Main(string[] args)
    {
        // for 루프
        for (int i = 0; i < 10; i++)
        {
           Console.WriteLine("Loop {0}", i);
        }
    }
}
```
### foreach 반복문
- foreach문은 배열이나 컬렉션에 주로 사용
- 컬렉션의 각 요소를 하나씩 꺼내와서 foreach루프내 블럭을 실행할 때 사용
```C#
static void Main(string[] args)
{
    string[] array = new string[] { "AB", "CD", "EF" };

    // foreach 루프
    foreach (string s in array)
    {
       Console.WriteLine(s);
    }
}
```
- C#에서 for와 foreach를 비교할때 성능적인 면과 가독성 측면을 고러혀는데 경우에 따라 for이 더 빠를 수 있지만 대부분 차이가 크지 않다. foreach는 for보다 훨씬 간결한 코드를 제공한다.
- **루프에서 많이 사용되는 배열인 경우 foreach가 내부적인 최적화를 거쳐 for루프와 동일한 성능이므로 더 간결한 foreach 사용을 권장**

```c#
static void Main(string[] args)
{
    // 3차배열 선언
    string[,,] arr = new string[,,] { 
            { {"1", "2"}, {"11","22"} }, 
            { {"3", "4"}, {"33", "44"} }
    };

    //for 루프 : 3번 루프를 만들어 돌림
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            for (int k = 0; k < arr.GetLength(2); k++)
            {
                Debug.WriteLine(arr[i, j, k]);
            }
        }
    }

    //foreach 루프 : 한번에 3차배열 모두 처리
    foreach (var s in arr)
    {
        Debug.WriteLine(s);
    }
}
```
### While 반복문
- while 조건식이 true인동안 계속 while 블럭을 실행할 때 사용
```C#
static void Main(string[] args)
{
    int i=1;

    // while 루프
    while (i <= 10)
    {
       Console.WriteLine(i);
       i++;
    }
}
```
### Do While 반복문
- do ~ while은 위의 while문과 거의 비슷하나, 마지막 while 조건식까지 가기 전에 do ~ while 사이의 블럭을 미리 한번 실행한다는 점에서 차이가 있음
```C#
static void Main(string[] args)
{
    int i=1;

    // do ~ while 루프
    do
    {
       Console.WriteLine(i);
       i++;
    } while (i < 10);
}
```
## C# yield
- yield는 호출자에게 컬렉션 데이터를 하나씩 리턴할 때 사용
- Enumerator(Iterator) 기능은 집합적인 데이터셋으로부터 데이터를 하나씩 호출자에게 보내주는 역할
- yield는 2가지 방식으로 사용
  1) yield return - 컬렉션 데이터를 하나씩 리턴할 때 사용
  2) yield break - 리턴을 중지하고 Iteration 루프를 빠져 나올 때 사용
```C#
using System;
using System.Collections.Generic;
 
class Program
{
    static IEnumerable<int> GetNumber()
    {
        yield return 10;  // 첫번째 루프에서 리턴되는 값
        yield return 20;  // 두번째 루프에서 리턴되는 값
        yield return 30;  // 세번째 루프에서 리턴되는 값
    }
 
    static void Main(string[] args)
    {
        foreach (int num in GetNumber())
        {
            Console.WriteLine(num);
        }             
    }
}
//실행값
10
20
30
```
## C# 예외 처리 (Exception)
- 모든 닷넷 프로그래밍 언어는 Exception 메커니즘을 따라 예외를 처리
- 객체를 기본으로 처리
- 만약 Exception이 발생하였는데 프로그램 내에서 처리하지 않으면 프로그램은 Chash하여 종료
- try, catch, finally 키워드로 Exception 핸들링
```C#
try
{
   // 실행하고자 하는 문장들
   DoSomething();
}
catch (Exception ex)
{
   // 에러 처리/로깅 등
   Log(ex);
   throw;
}
```
### try-catch-fianlly
- try는 실행하려는 프로그램 명령문을 갖는 블럭 _ 여기서 어떠한 오류가 발생하면 catch문에서 잡힌다.
- 모든 Exception을 잡고 싶을 때는 catch { ... } 와 같이 하거나 catch (Exception ex) { ... }처럼 모든 Exception의 베이스 클래스인 System.Exception를 잡으면 된다.
- 특정 Exception을 잡기 위해서는 해당 Exception Type을 catch하면 된다. 즉, Argument와 관련된 Exception을 잡고 싶으면, catch (ArgumentException ex) { ... } 와 같이 잡게된다.
- catch 블럭은 하나 or 여러개 일 수 있다
- finally는 Exception이 발생했던 발생하지 않았던 상관없이 마지막에 반드시 실행되는 블럭이다.
- 예를 들어, try 블럭에서 SQL Connection객체를 만든 경우, finally 블럭에서 Connection 객체의 Close() 메서드를 호출하면, 에러 발생 여부와 상관없이 항상 Connection객체가 닫히게 된다.
```C#
try
{
   //실행 문장들
}
catch (ArgumentException ex)
{
   // Argument 예외처리
}
catch (AccessViolationException ex)
{
   // AccessViolation 예외처리
}
finally
{
   // 마지막으로 실행하는 문장들
}
```
### throw
- try 블럭에서 Exception이 발생하였는데 이를 catch 문에서 잡었다면, Exception은 이미 처리된 것으로 간주된다. 때때로 catch문에서 기존의 Exception을 다시 상위 호출자로 보내고 싶을 때가 있는데, 이때 throw 를 사용
- trow 문은 크게 3가지로 구별
  1) throw 문 다음에 catch에서 전달받은 Exception 객체를 쓰는 경우
  2) throw 문 다음에 새 Exception 객체를 생성해서 전달하는 경우
  3) throw 문 다음에 아무것도 없는 경우
```C#
try
{
    // 실행 문장들
    Step1();
    Step2();
    Step3();
}
catch(IndexOutOfRangeException ex)
{
    // 새로운 Exception 생성하여 throw
    throw new MyException("Invalid index", ex);
}
catch(FileNotFoundException ex)
{    
    bool success = Log(ex);
    if (!success)
    {
        // 기존 Exception을 throw
        throw ex;
    }
}
catch(Exception ex)
{    
    Log(ex);
    // 발생된 Exception을 그대로 호출자에 전달
    throw;
}
```
```C#
string connStr = "Data Source=(local);Integrated Security=true;";
string sql = "SELECT COUNT(1) FROM sys.objects";
SqlConnection conn = null; 
try
{
    conn = new SqlConnection(connStr);
    conn.Open();
    SqlCommand cmd = new SqlCommand(sql, conn);
    object count = cmd.ExecuteScalar();
    Console.WriteLine(count);                
}
catch (SqlException ex)
{
    Console.WriteLine(ex.Message);
}
//항상 실행되어 Close 메서드를 실행하여 Connection을 닫
finally
{
    if (conn != null && 
        conn.State == System.Data.ConnectionState.Open)
    {
        conn.Close();
    }
}
```
## C# 네임스페이스
- 많은 클래스들을 충돌없이 보다 편리하게 관리 및 사용하기 위해 닷넷에서 네임스페이스를 사용
- 클래스들이 대개 네임스페이스 안에서 정의
```C#
namespace MyNamespace
{
   class A
   {
   }
   
   class B
   {
   }
}
```
- 네임 스페이스 참조 방식으로는 두가지 방식
  1) 클래스 명 앞에 네임 스페이스 전부를 적는 경우 (ex_  System.Console.WriteLine();)
  2) 프로그램 맨 윗단에 해당 using을 사용하여 C#에서 사용하고자 하는 네임스페이스를 설정하고 직접 클래스 사용 (ex_ using System; / Console.WriteLine();)
### C# 구조체
- C#에서 struct를 사용하면 Value Type을 만들고 class를 사용하면 Reference Type을 만든다.
- 기본 데이터형들은 struct으로 구성되어 있음(ex_int, double,float, bool 등) -> Value Type
- Class를 정의하여 만들며 상속이 가능, 복잡한 데이타나 행위를 정의하는 곳 -> Reference Type
```C#
// System.Int32 (Value Type)
public struct Int32 
{ 
   //....
}

// System.String (Reference Type)
public sealed class String 
{
   //....
}
```
### struct 구조체
- 구조체를 생성하고 Value Type을 정의하기 위해 사용
- 경우에 따라 클래스보다 상대적으로 가벼운 오버헤드를 지닌 구조체기 필요할 수 있다.
- **struct 구조체는 클래스와 같이 거의 비슷한 구조를 가지고 있지만 상속은 할 수 없다.**
- 상속은 할 수 없어도 인터페이스는 구현 가능
<img width="357" alt="image" src="https://github.com/uengmim/Xamarin-Study/assets/72143238/b5695da9-42db-437c-996d-704cc1d39514">

```C#
using System;

namespace AccessModifier
{
    class WaterHeater
    {
        protected int temperature;

        public void SetTemperature(int temperature)
        {
            // 온도 -5~42 예외처리
            if (temperature < -5 || temperature > 42)
            {
                throw new Exception("Out of temperature range");
            }

            // 외부에서 접근할 수 없기 때문에 public 메서드를 통해 접근
            this.temperature = temperature; 
        }

        internal void TurnOnWater()
        {
            Console.WriteLine("Turn on water: {0}", temperature);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                WaterHeater heater = new WaterHeater();
                heater.SetTemperature(20);
                heater.TurnOnWater();

                heater.SetTemperature(-2);
                heater.TurnOnWater();

                heater.SetTemperature(50);
                heater.TurnOnWater();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
```
## C# class
- Class는 Reference Type을 정의하는데 사용
- 클래스는 메서드 (Method), 속성 (Property), 필드 (Field), 이벤트 (Event) 등을 멤버로 포함하는 소프트웨어 단위로서 보통 이 클래스 정의로부터 객체 (Object)를 생성해서 사용
- 클래스를 정의할 때 중요한 멤버는 공용(public) 메서드와 속성인데, 이 public 멤버들은 외부 객체와의 상호작용을 위해 사용

 1) 메서드 : 클래스에서 실제 행동을 일으키는 코드 블럭. 대개 동사 or 동사 + 명사로 메서드 명을 정함 ex) Calculate(), DeleteData()
 2) 속성 : 클래스의 내부 데이터를 외부에서 사용할 수 있게 하거나 외분에서 클래스 내부의 데이터를 간단하게 설정할 때 사용
 3) 필드 : 클래스의 내부 데이터는 필드에 저장하며 필드들은 클래스 객체의 상태를 유지하는데 이용. 클래스는 동일하더라도 클래스로부터 생성된 여러 객체들은 다른 필드값을 가짐에 다라 서로 다른 객체 상태를 가짐
 4) 이벤트 : 이벤트는 객체 내부의 특정 상태나 어떤 일이 일어나는 이벤트를 외부로 전달하는데 사용

```C#
public class MyCustomer
{
    // 필드
    private string name;
    private int age;

    // 이벤트 
    public event EventHandler NameChanged;

    // 생성자 (Constructor)
    public MyCustomer()
    {
        name = string.Empty;
        age = -1;
    }

    // 속성
    public string Name
    {
        get { return this.name; }
        set 
        {
            if (this.name != value)
            {
                this.name = value;
                if (NameChanged != null)
                {
                    NameChanged(this, EventArgs.Empty);
                }
            }                
        }
    }
    public int Age
    {
        get { return this.age; }
        set { this.age = value; }
    }

    // 메서드
    public string GetCustomerData()
    {
        string data = string.Format("Name: {0} (Age: {1})", 
                    this.Name, this.Age);
        return data;
    }
}
```
### Partial 클래스
- 하나의 클래스를 2개 이상의 파일에 나누어 정의할 수 있는 기능
- Windows Form을 만들면 자동으로 동일 클래스를 2개의 파일에 나누어 저장

## Nullable 타입의 도입
- C#에서 정수, 부동자릿수, 구조체 등의 Value Type은 NULL을 가질 수 없다.
- ex) 정수 int i가 있으면 i에는 null 할당 X
  1) 프로그램에서 사용될 거 같지 않은 특정 값을 추정하여 할당 ex) int i = int.MaxValue;
  2) 또 하나의 변수를 두어 i가 missing임을 나타냄 ex) bool iHasValue = false;
### Nullable의 사용
- C#에서는 ValueType에도 null을 할당할 수 있는 Nullable타입을 지원
- Value값을 가지고 있으면서 NULL 상태를 체크할수 있는 HasValue를 가지고 있는 struct
- int?와 같이 Value Type 뒤에 물음표를 붙이면 해당 정수형 타입이 Nullable 정수형 타입을 의미. 즉 Null 할당 가
```C#
int? i = null;
bool? b = null;
int?[] a = new int?[100];
```
### Nullable<T> 타입
- int?,bool? 와 같은 T?의 표현은 Nullable<T>와 같은 표현
- Nullable<T>는 ㄱ밧을 가지고 있는지 체크하는 HasValue 속성과 실제 값을 나타내는 Value 속성을 가지고 있음
- 레퍼런스 타입은 이미 NUll을 허용하기 때문에 Nullable 쓸 필요 X
```C#
double _Sum = 0;
DateTime _Time;
bool? _Selected;

public void CheckInput(int? i, double? d, DateTime? time, bool? selected)
{
    if (i.HasValue && d.HasValue)
        this._Sum = (double)i.Value + (double)d.Value;

    // time값이 있는 체크.
    if (!time.HasValue)
        throw new ArgumentException();
    else
        this._Time = time.Value;

    // 만약 selected가 NULL이면 false를 할당
    this._Selected = selected ?? false;
}
```
### Nullable 정적 클래스
- 정적 클래스는 두개의 Nullable 객체를 비교(Compare(), Equals())하거나 특정 Nullable 타입이 어떤 Value 타입에 기반을 두고 있는지 알아내는(GetUnderingType()) 기능
  (Compare()은 큰지 작은지 같은지를 비교하는 반면, Equals()는 같은지 아닌지만 비교)

## C# 메서드
- 클래스 내에서 코드블럭을 실행시키는 함수를 메서드라고 부름
- 메서드는 하나의 리턴값을 가지며 리턴 값이 없을 경우 리턴 타입을 void로 표시
- public이나 private 같은 접근 제한자를 리턴 타입 앞에 둘 수 있다.
```C#
public int GetData(int a, string b, bool c)
{
}
```
### Pass by Value
- 메서드에 인수를 전달할 때 디폴트로 값을 복사해서 전달하는 Pass by Value 방식을 따름
- 전달된 인수를 메서드 내에서 변경한다해도 메서드가 끝나고 함수가 리턴된 후 전달된 인수의 값은 호출자에서 원래 값 그대로 유지



## System
### System의 구성 요소
- System : 여러 프로그램이 결합하여 지정된 역할을 수행하는 체계
- Program : 독립적으로 단일 역할을 수행하는 요소
- Assembly : Program을 구성하는 단위 기능의 집합체 
- Type : Assembly를 구성하는 단위 기능
- Variable : Type을 구성하는 변경이 가능한 변수 (메모리의 값의 변경이 가능)
- Constant : Type을 구성하는 변경이 불가능한 상수 (메모리의 값의 변경이 불가능)
- Static Variable : Program 전체에 값이 공유되는 정적 변수
- Literal : “abcd”, 1234 등 실제 값들 (변수와 상수에 넣어지는 값들)

### System의 설명 요소
- Manifest : Assembly의 구조와 속성 및 식별 정보를 서술해 놓은 것 (Assembly 설명서)
- Attribute : Assembly를 구성하는 Type의 속성

### 자료 구조
- Scalar [Legasy : array(메모리 상에 데이터가 연속적으로 저장), List(메모리 상에 데이터가 비연속적으로 저장), Tree(이진 트리), Hashset], [객체 지향적 : Collection(Array와 유사), Dictionary(Value 형태의 값을 저장할 수 있는 자료 구조)], [함수 지향적 : Enumerable(셀 수 있는 집합), Queryable(데이터를 요청하여 받을 수 있음 ex) mssql 등)]
- Vector [Legasy : Queue, Stack], [객체 지향적 : Bag(넣고 빼는 것이 가능, 거의 사용 X)]

### 객체의 구성 요소(매커니즘)
- Method : 객체의 기능
- Property : 객체의 특성
- Virtual : 객체의 기능 중 자식들이 자신만의 고유 기능을 가질 수 있는 것
- Abstract : 실체가 없는 개념적으로 존재 하는 것
- Override : 자식들이 자신만의 고유 기능으로 다시 정의하는 것
- New : 객체를 메모리에 로드하여 실체를 가지게 하는 것 (객체를 생성)

### Imate 구성
- XNCORE -  Assembly 동적 로딩
- XNCOMMON - imate config 로딩, Data Provide(정보 관리) -> imate config loader(xaml로 구성)[중요 : **XNConfiguration : imate 구성 정보(Section으로 나눔)**, XNConfigurationManager : 구성 정보 관리(NEW), imatecc IMATESERVER에서 사용]
- DPAC - Data Provide 추상 Class -> IDPF - Data Provider 인터페이스
- DPCORE - Data Provide 핵심 구현
- DIM - Data interface Module, Data Provide에 대한 추상 계층 제공
- RFCDIM - RFC Interface Module
- imateRFCSERVER - RFC server



IMATEDB2 만들기 (DPORA, DPSQL, DPSAP) ibm
