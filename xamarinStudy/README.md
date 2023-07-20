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


## 데이터 타입
 - C#을 포함한 모든 닷넷 프로그래밍언어는 닷넷의 Common Type System에 정의된 .NET 데이터 타입을 사용
<img width="389" alt="image" src="https://github.com/uengmim/Xamarin-Study/assets/72143238/a3204d04-d72e-4adb-afa6-69712b5c8ba2">

### C# 리터럴 데이터
- C# 코드에서 123,true,"ABC"와 같이 값을 직접 써줄 수 있다. 이것을 리터럴이라고 한다. 별도의 접미어 표시가 없으면 C# 컴파일러는 기본적으로 데이터 타입 값을 할당한다.
- 만약 특정 데이터 타입을 지정하고 싶으면 리터럴 데이터 뒤에 1~2자의 타입 지정 접미어를 추가해야한다.
```
123    // int 리터럴
12.3   // double 리터럴
"A"    // string 리터럴
'a'    // char 리터럴
true   // bool 리터럴
```
### C# 접미어(Suffix) 데이터 타입
<img width="318" alt="image" src="https://github.com/uengmim/Xamarin-Study/assets/72143238/5ec3da6c-399a-41a0-85ba-e484d6601f83">

```
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
```
int i = int.MaxValue;
float f = float.MinValue;
```

### NULL
- 어떤 변수가 어떤 데이터도 가지고 있지 않다는 의미로 사용
- C#에서는 소문자 null로 표현

### Nullable Type
- 정수(int)나 날짜(DateTime)와 같은 Value Type은 일반적으로 NULL을 가질 수 없다. C# 2.0에서부터 이러한 타입들에 NULL을 가질 수 있게 하였는데, 이를 Nullable Type 이라 부른다.
- C#에서 물음표(?)를 int나 DateTime 타입명 뒤에 붙이면 즉, int? 혹은 DateTime? 같이 하면 Nullable Type이 된다. 이는 컴파일하면 .NET의 Nullable<T> 타입으로 변환된다. Nullable Type (예: int?) 을 일반 Value Type (예: int)으로 변경하기 위해서는 Nullable의 .Value 속성을 사용한다.
```
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
```
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
### C# 상수
- c# 상수는 const를 사용하여 정의
**차이점**
1. 상수와 변수 차이점은 변수는 프로그램 중간에 값을 변경할 수 있지만 상수는 초기에 정한 값을 중간에 변경할 수 없다.
2. const는 필드 선언부에서 사용되거나 메서드 내에서 사용될 수 있으며 컴파일시 상수 값이 결정

### C# 배열
- 배열은 동일한 데이터 타입 요소들로 구성된 데이타 집합으로 인덱스를 통하여 개개의 배열 요소를 엑세스 가능
- 배열은 첫번째 요소가 인덱스 0
```
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
```
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
```
int[][,] jaggedArray4 = new int[3][,]
{
    new int[,] { {1,3}, {5,7} },
    new int[,] { {0,2}, {4,6}, {8,10} },
    new int[,] { {11,22}, {99,88}, {0,9} }
};
```
### C# 배열 사용
- 배열 사용 예제
```
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
```
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
